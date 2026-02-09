using UnityEngine;

public class StartTransition : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        // Load the next scene (assuming the next scene is indexed at 1)
        UnityEngine.SceneManagement.SceneManager.LoadScene(11);
    }
}
