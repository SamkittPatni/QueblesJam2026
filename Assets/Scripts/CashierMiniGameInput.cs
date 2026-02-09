using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class CashierMiniGameInput : MonoBehaviour
{
    public TMP_InputField inputUser;

    private List<float> NumbersList = new List<float>{0f,1f,2f,3f,4f,5f,6f,7f,8f,9f};
    private bool condition = false;

    public GameObject customerItem1;
    public GameObject costTag1;
    public GameObject customerItem2;
    public GameObject costTag2;
    public GameObject customerItem3;
    public GameObject costTag3;

    private GameObject currentItem;
    private GameObject currentTag;


    public TMP_Text paymentText;
    private int num = 0;
    private int score = 0;

    private List<float> ItemCost = new List<float>{239f, 450f, 187f};
    private List<float> CustomerMoney = new List<float>{381f, 492f, 957f};
    public TMP_Text dialogueText; // Reference to a TextMeshPro text element to display dialogue
    public GameObject dialoguePanel; // Reference to a UI panel for dialogue
    public GameObject dialogueCharacter; // Reference to a UI element for the character portrait in dialogue
    public GameObject transparentScreen;

    private bool success = false;
    void Start()
    {
        inputUser.interactable=false;
        StartCoroutine(GameSetUp(customerItem1, costTag1, ItemCost[num].ToString()));
    }

    public void CheckInput(string Input)
    {
        if (Input.Length > 0)
        {
            for (int i = 0; i < NumbersList.Count; i++)
            {
                if (NumbersList[i].ToString() == Input[Input.Length-1].ToString())
                {
                    condition = true;
                }
            }
            if (Input.Length == 1 & Input[0].ToString() == "0")
            {
                condition = false;
            }
            if (condition==false)
            {
                inputUser.text = Input.Remove(Input.Length-1);
            }
            condition = false;
        }
    }

    public void CheckEnter(string Input)
    {
        Debug.Log(num);
        if (CustomerMoney[num-1]-ItemCost[num-1]==float.Parse(Input))
        {
            StartCoroutine(WaitLowk(2f, "yay!"));
            score += 2;
        }
        else
        {
            StartCoroutine(WaitLowk(2f, "error"));
            score += -2;
        }

        inputUser.interactable = false;

        CashierMiniGameObject itemScript = currentItem.GetComponent<CashierMiniGameObject>();

        StartCoroutine(itemScript.Movement(itemScript.OnScreenPosition, itemScript.ExitPosition));
        CashierMiniGameObject tagScript = currentTag.GetComponent<CashierMiniGameObject>();
        StartCoroutine(tagScript.Movement(tagScript.OnScreenPosition, tagScript.ExitPosition));
        inputUser.interactable=false;

        StartCoroutine(Transition());
    }

    private IEnumerator GameSetUp(GameObject itemLocal, GameObject costTagLocal, string value)
    {
        currentItem = Instantiate(itemLocal);
        yield return new WaitForSeconds(1f);
        currentTag = Instantiate(costTagLocal);
        yield return new WaitForSeconds(1f);
        paymentText.SetText(value);
        inputUser.interactable = true;
        inputUser.Select();
        num++;
    }

    private IEnumerator Transition()
    {
        yield return new WaitForSeconds(2f);
        if (num==1)
        {
            StartCoroutine(GameSetUp(customerItem2, costTag2, ItemCost[num].ToString()));
        }
        else if (num==2)
        {
            StartCoroutine(GameSetUp(customerItem3, costTag3, ItemCost[num].ToString()));
        }
        else if (num==3)
        {
            
            if (score > 0)
            {
                success = true;
                GameManager.Instance.AddTrust(20f);
            }
            else
            {
                GameManager.Instance.AddTrust(-20f);
                success = false;
            }

            StartCoroutine(PlayDialogue(success));
            Debug.Log("Game Over");
        }
    }

    private IEnumerator WaitLowk(float value, string message)
    {
        paymentText.SetText(message);
        inputUser.text = "bingus";
        yield return new WaitForSeconds(value);
    }

    private IEnumerator PlayDialogue(bool success)
    {
        transparentScreen.SetActive(true);
        dialogueCharacter.SetActive(true);
        yield return new WaitForSeconds(0.5f); // Wait for the panel to appear
        dialoguePanel.SetActive(true);
        yield return new WaitForSeconds(0.5f); // Wait for the dialogue to appear
        if (success)
        {
            dialogueText.text = "Wow, you calculated the change perfectly, no way a cat could do that!";
        }
        else
        {
            dialogueText.text = "I think you shorted me....are you a cat?";
        }
        yield return new WaitForSeconds(3f); // Display dialogue for 3 seconds
        GameManager.Instance.SetPauseTimer(false); // Unpause the week timer after the maze minigame ends
        SceneManager.LoadScene(1);
    }
}