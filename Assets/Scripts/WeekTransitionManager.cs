using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class WeekTransitionManager : MonoBehaviour
{
    public TMP_Text weekText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weekText.text = "Week " + GameManager.Instance.GetWeek();
        // StartCoroutine(TransitionToNextWeek());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TransitionToNextWeekButton()
    {
        GameManager.Instance.SetPauseTimer(false); // Unpause the timer when transitioning to the next week
        SceneManager.LoadScene(1); // Load the next scene (assuming the next scene is indexed at 1)
    }
}

