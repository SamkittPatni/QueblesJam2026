using System.Collections;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    public float mazeTimeLimit = 60f; // Time limit for the maze in seconds
    public float startTime;
    public bool isComplete = false; // Flag to check if the maze is completed
    private float trustReward = 10f; // Amount of trust to reward on successful completion
    void Start()
    {
        startTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        startTime += Time.deltaTime;
        // Check if the time limit has been reached and the maze is not completed
        if (startTime >= mazeTimeLimit && !isComplete)
        {
            Debug.Log("Maze failed!");
        }
        // Check if the maze is completed successfully within the time limit
        else if (isComplete)
        {
            Debug.Log("Maze completed successfully!");
            GameManager.Instance.AddTrust(trustReward); // Reward trust points to the player
        }
    }

    public void CompleteMaze()
    {
        isComplete = true;
    }
}
