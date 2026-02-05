using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
using UnityEngine;
using Unity.VisualScripting;
///https://www.youtube.com/watch?v=VqHaDUXJsyg tutorial

public class StackingGameManager : MonoBehaviour
{
    [SerializeField] private Transform blockPrefab;
    [SerializeField] private Transform blockHolder;

    [SerializeField] private TMPro.TextMeshProUGUI livesText;

    /// <summary>
    ///  variables to handle the game state
    /// </summary>
    private int startingLives = 3;
    private int livesRemaining;
    private bool playing = true;

    public InputAction InputSystem_Actions;
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
    private void OnDrop()
    {
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
    private Transform currentBlock = null;
    private Rigidbody2D currentRigidbody;

    private Vector2 blockStartPosition = new Vector2(0f, 4f);

    private float blockSpeed = 8f;
    private float blockSpeedIncrement = 0.5f; /// makes blocks speed increasingly fast to make it harder
    private int blockDirection = 1; /// set to -1 if you want block to go in the other direction
    private float xLimit = 5; ///block will know to reverse when x>5. block can extend over the edge,making game more interesting
    private float timeBetweenRounds = 1f;



    void Start()
    {
        livesRemaining = startingLives;
        livesText.text = $"{livesRemaining}";
        SpawnNewBlock();
    }

    private void SpawnNewBlock()
    {
        //create a block with the desired properties.
        currentBlock = Instantiate(blockPrefab, blockHolder);
        currentBlock.position = blockStartPosition;
        ///currentBlock.GetComponent<SpriteRenderer>().color = Random.ColorHSV(); /// enable randomly coloured blocks
        currentRigidbody = currentBlock.GetComponent<Rigidbody2D>();
        blockSpeed += blockSpeedIncrement;

    }


    //update is called once per frame
    void Update()
    {
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
    }
    public void RemoveLife()
    {   /// update the lives remaining UI element
        livesRemaining = Mathf.Max(livesRemaining - 1, 0); /// ensures we don't go negative if a lot of blocks fall off at once
        livesText.text = $"{livesRemaining}";
        /// check for end of game
        if (livesRemaining == 0)
        {
            playing = false;
        }
    }
}

