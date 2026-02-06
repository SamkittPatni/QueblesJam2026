using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

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
            score += 7;
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
        /*
        if (num == 1)
        {
            // Check User Answer
            DestroyImmediate(customerItem1, true);
            DestroyImmediate(costTag1, true);
            if (true)
            {
                score++;
            }
            StartCoroutine(GameSetUp(customerItem2, costTag2, "68"));
        }
        else if (num == 2)
        {
            // Check User Answer
            DestroyImmediate(customerItem2, true);
            DestroyImmediate(costTag2, true);
            if (true)
            {
                score++;
            }
            StartCoroutine(GameSetUp(customerItem3, costTag3, "69"));
        }
        else if (num == 3)
        {
            // Check User Answer
            if (true)
            {
                score++;
            }
            Debug.Log("Game Over");
        }
        */
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
            Debug.Log("Game Over");
        }
    }

    private IEnumerator WaitLowk(float value, string message)
    {
        paymentText.SetText(message);
        inputUser.text = "bingus";
        yield return new WaitForSeconds(value);
    }
}