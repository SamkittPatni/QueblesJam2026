using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance
    public int week = 0;
    public float trust = 0f;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Every time the scene loads, increment the week counter
        week++;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(EndWeek());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator EndWeek()
    {
        yield return new WaitForSeconds(180f); // Wait for 180 seconds (3 minute)
        Debug.Log("Week " + week + " ended. Trust: " + trust);
        // Here you can add logic to transition to the next week, reset NPCs, etc.
    }
}
