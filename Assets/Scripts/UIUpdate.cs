using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
public class UIUpdate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Label timerLabel;
    private Label weekLabel;
    private ProgressBar trustBar;

    private Label tunaCountLabel;
    private Label todoListLabel;

    UIDocument uiDocument;
    void Start()
    {
        uiDocument = GetComponent<UIDocument>();

        // Get the root of the visual tree
        VisualElement root = uiDocument.rootVisualElement;
        root.pickingMode = PickingMode.Ignore;

        // Find element by name
        timerLabel = root.Q<Label>("TimerDisplay");
        weekLabel = root.Q<Label>("WeekDayDisplay");
        trustBar = root.Q<ProgressBar>("TrustBar");
        tunaCountLabel = root.Q<Label>("TunaCounterNumber");
        todoListLabel = root.Q<Label>("ToDoLis");
        

        weekLabel.text = $"WEEK {GameManager.Instance.GetWeek()}"; // Set initial week display

        // Assign trust value to progress bar
        // TODO: change assigning value to {trust} variable
        trustBar.value = GameManager.Instance.GetTrust();
    }

    void LateUpdate()
    {
        if (uiDocument == null)
            return;

        var pr = GameObject.Find("PanelSettings");
        if (pr != null)
        {
            pr.GetComponent<PanelRaycaster>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timerLabel.text = GameManager.Instance.timeText;
        weekLabel.text = $"WEEK {GameManager.Instance.GetWeek()}"; // Update week display
        trustBar.value = GameManager.Instance.GetTrust(); // Update trust bar value
        tunaCountLabel.text = $"x{GameManager.Instance.GetTunaCount()}"; // Update tuna count display
        switch (GameManager.Instance.GetWeek())
        {
            case 1:
                todoListLabel.text = "-Stack shelf\n-Talk to customers\n-Collect tuna";
                break;
            case 2:
                todoListLabel.text = "-Man the register\n-Talk to customers\n-Collect tuna";
                break;
            case 3:
                todoListLabel.text = "-Direct customers\n-Talk to customers\n-Collect tuna";
                break;
            default:
                todoListLabel.text = "-Talk to customers\n-Collect tuna";
                break;
        }
    }
}
