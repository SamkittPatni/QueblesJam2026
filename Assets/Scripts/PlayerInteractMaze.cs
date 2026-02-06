using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractMaze : MonoBehaviour
{
    public GameObject mazeManager; // Reference to the MazeManager script
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        mazeManager.GetComponent<MazeManager>().CompleteMaze();
        
    }
}
