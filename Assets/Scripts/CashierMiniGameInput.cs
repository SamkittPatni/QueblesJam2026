using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class CashierMiniGameInput : MonoBehaviour
{
    public TMP_InputField inputUser;
    //private string cashierInput = "";
    //private float finalTotal = 0f;
    //private List<KeyCode> numberKeys = new List<KeyCode>{}; 
    private List<float> NumbersList = new List<float>{0f,1f,2f,3f,4f,5f,6f,7f,8f,9f};
    private bool condition = false;
    void Start()
    {
        inputUser.Select();
    }
    /*
    void Update()
    {
        for (int i = 0; i < NumbersList.Count; i++)
            {
                if (Input.GetKeyDown(numberKeys[i]))
                    {
                        cashierInput += i.ToString();
                        break;
                    }
            }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (cashierInput.Length > 0)
            {
                cashierInput = cashierInput.Remove(cashierInput.Length-1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            float.TryParse(cashierInput, out finalTotal);
            cashierInput = "";
        }
    }
    */
    public void CheckInput(string Input)
    {
        if (Input.Length > 0)
        {
            for (int i = 0; i < NumbersList.Count; i++)
            {
                if (NumbersList[i].ToString() == Input[Input.Length-1].ToString())
                {
                    Debug.Log("If Passed 1");
                    condition = true;
                }
            }
            if (condition==false)
            {
                Debug.Log("If Passed 2");
                inputUser.text = Input.Remove(Input.Length-1);
            }
            condition = false;
        }
        Debug.Log(inputUser.text);
    }
}