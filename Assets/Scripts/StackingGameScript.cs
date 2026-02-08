using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
///https://www.youtube.com/watch?v=VqHaDUXJsyg tutorial

public class StackingGameManager : MonoBehaviour
{
    [SerializeField] private HungryCatObject catScript;


    [SerializeField] private Transform blockPrefab;
    [SerializeField] private Transform blockHolder;

    [SerializeField] private TMPro.TextMeshProUGUI livesText;
    [SerializeField] private TMPro.TextMeshProUGUI timerText;

    

    /// <summary>
    ///  variables to handle the game state
    /// </summary>
    private int startingLives = 3;
    private int livesRemaining;
    public bool playing;


    private float stackingGameTimeLimit = 45f; /// 10f ~ 13 seconds

    public InputAction InputSystem_Actions;

    public GameObject transparentScreen;
    public GameObject dialoguePanel;
    public GameObject dialogueCharacter;
    public TMPro.TextMeshProUGUI dialogueText;


    private void OnEnable()
    {
        InputSystem_Actions.Enable();
    }

    private void OnDisable()
    {
        InputSystem_Actions.Disable();
    }
    private IEnumerator DelayedSpawn()
    {
        yield return new WaitForSeconds(timeBetweenRounds);
        SpawnNewBlock();
    }
    /*
    private void OnDrop()
    {
        ///Debug.Log("67676767");
        /// stop it moving.
        currentBlock = null; /// if(currentBLock) will no longer recall so the horizontal motion will stop.
                             /// activate the rigidbody to enable gravity to drop it.
        currentRigidbody.simulated = true; /// gravity takes effect and block falls. 

                                           /// spawn next block
        if (playing == true)
        {                                   ///SpawnNewBlock(); ///spawns block immediately
            StartCoroutine(DelayedSpawn());
        }
    }
    */
    private void OnDrop()
{
    // 1. Only allow the drop if we actually have a block to drop
    if (currentBlock != null && playing)
    {
        // Stop the horizontal movement immediately
        // By setting currentBlock to null first, the Update() loop 
        // will stop moving it before the next frame.
        Transform blockToDrop = currentBlock;
        currentBlock = null; 

        // 2. Activate gravity
        Rigidbody2D rb = blockToDrop.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.simulated = true;
        }

        // 3. Spawn next block after the delay
        StartCoroutine(DelayedSpawn());
    }
}
    private Transform currentBlock = null;
    private Rigidbody2D currentRigidbody;

    private Vector2 blockStartPosition = new Vector2(0f, 4f);

    private float blockSpeed = 8f;
    private float blockSpeedIncrement = 0.5f; /// makes blocks speed increasingly fast to make it harder
    private int blockDirection = 1; /// set to -1 if you want block to go in the other direction
    private float xLimit = 5; ///block will know to reverse when x>5. block can extend over the edge,making game more interesting
    private float timeBetweenRounds = 1f;

    private float blockStartTime = 0f;

    private bool success = false;


    void Start()
    {
        playing = true;
        livesRemaining = startingLives;
        livesText.text = $"Lives: {livesRemaining}";
        SpawnNewBlock();

        ////hCatObject.position = catStartPosition;
        ///StartCoroutine(hObjectCat.Movement(hObjectCat.StartPosition, hObjectCat.OnScreenPosition));
    }

    private void SpawnNewBlock()
    {
        //create a block with the desired properties.f
        currentBlock = Instantiate(blockPrefab, blockHolder);
        currentBlock.position = blockStartPosition;
        ///currentBlock.GetComponent<SpriteRenderer>().color = Random.ColorHSV(); /// enable randomly coloured blocks
        currentRigidbody = currentBlock.GetComponent<Rigidbody2D>();
        blockSpeed += blockSpeedIncrement;

    }


    //update is called once per frame
    void Update()
    {
        if (playing == true)
        {
            blockStartTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt((blockStartTime / 60));
            int seconds = Mathf.FloorToInt((blockStartTime % 60));
            string text = string.Format("{0:00}:{1:00}", minutes, seconds);
            timerText.text = text;
        }

        if (blockStartTime >= stackingGameTimeLimit && playing == true)
        {
            playing = false;
            Debug.Log("You ran out of time!");
            GameManager.Instance.AddTrust(-30f); /// lose condition

        }

        ///blockStartTime += Time.deltaTime;
        //if we have a waiting block, move it about.
        if (currentBlock && playing) /// added playing boolean - makes blocks stop spawning if game is over
        {
            float moveAmount = Time.deltaTime * blockSpeed * blockDirection;
            currentBlock.position += new Vector3(moveAmount, 0, 0); /// update current block position by increasing the x value of the position by increasing the x value of the move amount
            if (Mathf.Abs(currentBlock.position.x) > xLimit)
            {
                //set it to the limit so it doesn't go further.
                currentBlock.position = new Vector3(blockDirection * xLimit, currentBlock.position.y, 0);
                blockDirection = -blockDirection; /// reverse block direction by negating it
            }

        }
        /// temporarily assign a key to restart the game
        /// note - no code here as we do not need to add a button to exit the game.
        
        if (!playing)
        {
            StartCoroutine(PlayDialogue(success));
        }
    }
    public void RemoveLife()
    {   /// update the lives remaining UI element
        livesRemaining = Mathf.Max(livesRemaining - 1, 0); /// ensures we don't go negative if a lot of blocks fall off at once
        livesText.text = $"{livesRemaining}";
        /// check for end of game
        if (livesRemaining == 0)
        {
            playing = false;
            GameManager.Instance.AddTrust(-20f); /// lose condition
        }
    }
    public void WinGame()

    {/// win condition
        success = true;
        playing = false;
        GameManager.Instance.AddTrust(20f); // adds trust to overall trust on win
        Debug.Log("You got 20 trust!");
    }

    private void OnMultitap()
    {
        
        if (catScript != null)
        {
            catScript.StartCoroutine(catScript.Transition());
        }
    }

public void RemoveLastBlock()
{
    for (int i = blockHolder.childCount - 1; i >= 0; i--)
    {
        Transform child = blockHolder.GetChild(i);

        if (child == currentBlock) continue;

        if (child.name.Contains("(Clone)"))
        {
            // get the Rigidbody to check how fast it's moving
            Rigidbody2D rb = child.GetComponent<Rigidbody2D>();

            // stability check: 
            // If the block is moving faster than a tiny amount (0.1), 
            // it's falling or sliding. skip it
            if (rb != null && rb.linearVelocity.magnitude > 0.1f)
            {
                continue; 
            }

            // ff we got here, the block is stable! 
            Debug.Log("The cat ate a stable block: " + child.name);
            Destroy(child.gameObject);
            //RemoveLife();

            if (catScript != null)
            {
                catScript.StartCoroutine(catScript.Transition());
            }
            return; 
        }
    }

    Debug.Log("No stable blocks found for the cat to steal!");
}

    private IEnumerator PlayDialogue(bool success)
    {
        transparentScreen.SetActive(true);
        dialogueCharacter.SetActive(true);
        yield return new WaitForSeconds(0.5f); // Wait for the panel to appear
        dialoguePanel.SetActive(true);
        yield return new WaitForSeconds(0.5f); // Wait for the dialogue to appear
        if (success)
        {
            dialogueText.text = "You completed the maze!";
        }
        else
        {
            dialogueText.text = "Oh no! You failed the maze!";
        }
        yield return new WaitForSeconds(3f); // Display dialogue for 3 seconds
        FindAnyObjectByType<PlayerInput>().gameObject.SetActive(false);
        GameManager.Instance.pauseTimer = false; // Unpause the week timer after the maze minigame ends
        SceneManager.LoadScene(1); // Load the main scene after failure
    }
}

