using UnityEngine;
using UnityEngine.UIElements;
public class UIUpdate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Label timerLabel;
    private Label weekLabel;
    private ProgressBar trustBar;
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();

        // Get the root of the visual tree
        VisualElement root = uiDocument.rootVisualElement;

        // Find element by name
        timerLabel = root.Q<Label>("TimerDisplay");
        weekLabel = root.Q<Label>("WeekDayDisplay");
        trustBar = root.Q<ProgressBar>("TrustBar");

        weekLabel.text = $"WEEK {GameManager.Instance.GetWeek()}"; // Set initial week display

        // Assign trust value to progress bar
        // TODO: change assigning value to {trust} variable
        trustBar.value = GameManager.Instance.GetTrust();
    }

    // Update is called once per frame
    void Update()
    {
        timerLabel.text = GameManager.Instance.timeText;
        weekLabel.text = $"WEEK {GameManager.Instance.GetWeek()}"; // Update week display
        trustBar.value = GameManager.Instance.GetTrust(); // Update trust bar value
    }
}
