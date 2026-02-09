using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance
    public static int week = 1;
    public static float trust = 0f;

    public float startTime;

    public float weekDuration = 90f; // Duration of each week in seconds

    private int minutes;
    private int seconds;

    public string timeText;

    public static bool playedMinigame = false;

    public static bool pauseTimer;

    public GameObject GameUI;

    public bool NPC1Interacted = false;
    public bool NPC2Interacted = false;
    public bool NPC3Interacted = false;
    public bool NPC4Interacted = false;
    public bool NPC5Interacted = false;

    // Include in TODO LIST
    // 1. Task of the day
    // 2. Talk to customers to gain trust
    
    private void Awake()
    {
        if (Instance == null)
        {
            // This is the very first GameManager. Keep it!
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // A GameManager already exists from a previous scene. 
            // Destroy this new one so we don't have duplicates.
            Destroy(gameObject);
        }

        // Every time the scene loads, increment the week counter
        // week++;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get UIDocument on this game object
        

        

        pauseTimer = false;
        playedMinigame = false; // Reset minigame state for the new week
        // if (startTime >= weekDuration)
        // {
        //     startTime = 0f;
        //     week++;   
        // }
        
        // Display week day
        // weekLabel.text = $"WEEK {week}";

        // Assign trust value to progress bar
        // TODO: change assigning value to {trust} variable
        // trustBar.value = 20f;

        // StartCoroutine(EndWeek());
    }

    // Update is called once per frame
    void Update()
    {
        // GameUI = GameObject.Find("GameUI");
        // UIDocument uiDocument = GameUI.GetComponent<UIDocument>();

        // // Get the root of the visual tree
        // VisualElement root = uiDocument.rootVisualElement;

        // // Find element by name
        // timerLabel = root.Q<Label>("TimerDisplay");
        // weekLabel = root.Q<Label>("WeekDayDisplay");
        // trustBar = root.Q<ProgressBar>("TrustBar");
        if (!pauseTimer)
        {
            startTime += Time.deltaTime;
            minutes = Mathf.FloorToInt((weekDuration - startTime) / 60);
            seconds = Mathf.FloorToInt((weekDuration - startTime) % 60);   
            timeText = string.Format("{0:0}:{1:00}", minutes, seconds);

            // Display timeText inside the TimerDisplay

            
        }

        if (startTime >= weekDuration)
        {
            startTime = 0f;
            week++;
            pauseTimer = false; // Reset pause state for the new week
            playedMinigame = false; // Reset minigame state for the new week

            NPC1Interacted = false;
            NPC2Interacted = false;
            NPC3Interacted = false;
            NPC4Interacted = false;
            NPC5Interacted = false;
            
        }

        if (week == 4)
        {
            if (trust < 30f)
            {
                SceneManager.LoadScene(8); // Load bad ending scene
            }
            else if (trust >= 30f && trust < 60f)
            {
                SceneManager.LoadScene(9); // Load neutral ending scene
            }
            else if (trust == 100f)
            {
                SceneManager.LoadScene(10); // Load good ending scene
            }
        }

        
        Debug.Log("Week: " + week + " Time: " + minutes + ":" + seconds);
    }

    public void AddTrust(float amount)
    {
        trust += amount;
        if (trust < 0f)
        {
            trust = 0f; // Ensure trust doesn't go below 0
        }
        else if (trust > 100f)
        {
            trust = 100f; // Ensure trust doesn't exceed 100
        }
    }

    public float GetTrust()
    {
        return trust;
    }

    public int GetWeek()
    {
        return week;
    }

    public bool HasPlayedMinigame()
    {
        return playedMinigame;
    }

    public void SetPlayedMinigame(bool value)
    {
        playedMinigame = value;
    }

    public void SetPauseTimer(bool value)
    {
        pauseTimer = value;
    }
}
