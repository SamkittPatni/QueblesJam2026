using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance
    public int week = 1;
    public float trust = 0f;

    public float startTime;

    public float weekDuration = 180f; // Duration of each week in seconds

    private int minutes;
    private int seconds;

    public string timeText;

    public bool playedMinigame = false;

    public bool pauseTimer;

    private Label timerLabel;
    private Label weekLabel;
    private ProgressBar trustBar;

    // Include in TODO LIST
    // 1. Task of the day
    // 2. Talk to customers to gain trust
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Every time the scene loads, increment the week counter
        // week++;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get UIDocument on this game object
        UIDocument uiDocument = GetComponent<UIDocument>();

        // Get the root of the visual tree
        VisualElement root = uiDocument.rootVisualElement;

        // Find element by name
        timerLabel = root.Q<Label>("TimerDisplay");
        weekLabel = root.Q<Label>("WeekDayDisplay");
        trustBar = root.Q<ProgressBar>("TrustBar");

        

        pauseTimer = false;
        playedMinigame = false; // Reset minigame state for the new week
        if (startTime >= weekDuration)
        {
            startTime = 0f;
            week++;   
        }
        
        // Display week day
        weekLabel.text = $"WEEK {week}";

        // Assign trust value to progress bar
        // TODO: change assigning value to {trust} variable
        trustBar.value = 20f;

        // StartCoroutine(EndWeek());
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseTimer)
        {
            startTime += Time.deltaTime;
            minutes = Mathf.FloorToInt((weekDuration - startTime) / 60);
            seconds = Mathf.FloorToInt((weekDuration - startTime) % 60);   
            timeText = string.Format("{0:0}:{1:00}", minutes, seconds);

            // Display timeText inside the TimerDisplay
            timerLabel.text = timeText;

            
        }

        Debug.Log("Week: " + week + " Time: " + minutes + ":" + seconds);
    }

    private IEnumerator EndWeek()
    {
        yield return new WaitForSeconds(180f); // Wait for 180 seconds (3 minute)
        Debug.Log("Week " + week + " ended. Trust: " + trust);
        // Here you can add logic to transition to the next week, reset NPCs, etc.
    }

    public void AddTrust(float amount)
    {
        trust += amount;
    }
}
