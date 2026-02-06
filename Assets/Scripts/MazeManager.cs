using System.Collections;
using UnityEngine;
using TMPro;
using System.Threading;

public class MazeManager : MonoBehaviour
{

    public float mazeTimeLimit = 60f; // Time limit for the maze in seconds
    public float startTime;
    public bool isComplete = false; // Flag to check if the maze is completed
    private float trustReward = 10f; // Amount of trust to reward on successful completion

    private float trustPenalty = -5f; // Amount of trust to penalize on failure

    public TMP_Text timerText; // Reference to a TextMeshPro text element to display the timer

    public TMP_Text dialogueText; // Reference to a TextMeshPro text element to display dialogue
    public GameObject dialoguePanel; // Reference to a UI panel for dialogue
    public GameObject dialogueCharacter; // Reference to a UI element for the character portrait in dialogue
    public GameObject transparentScreen;
    void Start()
    {
        startTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isComplete)
        {
            startTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt((mazeTimeLimit - startTime) / 60);
            int seconds = Mathf.FloorToInt((mazeTimeLimit - startTime) % 60);
            string text = string.Format("{0:00}:{1:00}", minutes, seconds);
            timerText.text = text;   
        }
        // timerText.text = Mathf.FloorToInt(mazeTimeLimit - startTime)/60 + ":" + Mathf.FloorToInt(mazeTimeLimit - startTime)%60;
        // Debug.Log("Time: " + Mathf.FloorToInt(startTime) + " seconds");
        // Check if the time limit has been reached and the maze is not completed
        if (startTime >= mazeTimeLimit && !isComplete)
        {
            timerText.text = "00:00";
            Debug.Log("Maze failed!");
            StartCoroutine(PlayDialogue(false)); // Play failure dialogue
            // GameManager.Instance.AddTrust(trustPenalty);
        }
        // Check if the maze is completed successfully within the time limit
        else if (isComplete)
        {
            Debug.Log("Maze completed successfully!");
            StartCoroutine(PlayDialogue(true)); // Play success dialogue
            // GameManager.Instance.AddTrust(trustReward); // Reward trust points to the player
        }
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
    }

    public void CompleteMaze()
    {
        isComplete = true;
    }
}
