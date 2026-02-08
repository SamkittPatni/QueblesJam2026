using UnityEngine;
using System.Collections;

public class QButtonAppear : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI buttonText;

    [SerializeField] private HungryCatObject catScript;

    [SerializeField] private float bigScaleMult = 1.3f;

    private Vector3 baseScale;
    private Vector3 growScale = new Vector3(0.14f, 0.14f, 0f); // Adjust to your needs
    private Vector3 positionOnScreen = new Vector3(7.61f, -1.07f, 0.0f);
    private Vector3 positionOffScreen = new Vector3(10.25f, -0.98f, 0f);
    ///private Vector3 originalTextScale;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        baseScale = transform.localScale;
        transform.position = positionOffScreen;

        ///StartCoroutine(ButtonRoutine());
        ///
        //originalTextScale = buttonText.transform.localScale;
    }

    void Update()
    {
        StartCoroutine(ButtonRoutine());
    }

    private IEnumerator ButtonRoutine()
    {
        {
            yield return new WaitUntil(() => catScript != null && catScript.CatOnScreen);
            {
                Debug.Log("bruh moment");
                transform.position = positionOnScreen; // mmoves button icon on screen with cat icon.
                buttonText.text = "[Q]"; // makes the button text appear when the cat is on screen.
                while (catScript.CatOnScreen)
                {
                    transform.localScale = growScale;
                    //buttonText.transform.localScale = originalTextScale * bigScaleMult; /// text go big
                    yield return new WaitForSeconds(0.25f);

                    // buttonText.transform.localScale = originalTextScale;
                    transform.localScale = baseScale;
                    yield return new WaitForSeconds(0.25f);
                }
                transform.position = positionOffScreen;
                buttonText.text = ""; // makes the button text disappear when the cat is not on screen.
            }
        }


      }
    }