using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class TransitionManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int sceneToLoad;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSubmit()
    {
        FindAnyObjectByType<PlayerInput>().gameObject.SetActive(false);
        SceneManager.LoadScene(sceneToLoad); // Load the specified scene
    }
}
