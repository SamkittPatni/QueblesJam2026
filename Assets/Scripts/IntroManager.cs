using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject dialogueBox; // Reference to the dialogue box UI element
    public TMP_Text dialogueText; // Reference to the TextMeshPro text element for displaying dialogue
    public GameObject scene2;
    public GameObject spaceShip;
    public GameObject scene3;

    public GameObject turnPoint;

    void Start()
    {
        StartCoroutine(PlayIntro());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator PlayIntro()
    {
        yield return new WaitForSeconds(2f); // Wait for 1 second before starting the intro
        dialogueBox.SetActive(true);
        yield return new WaitForSeconds(0.5f); // Wait for the panel to appear
        dialogueText.text = "Dialogue 1";
        yield return new WaitForSeconds(3f);
        dialogueText.text = "";
        dialogueBox.SetActive(false);
        yield return new WaitForSeconds(1f);
        scene2.SetActive(true);
        yield return new WaitForSeconds(1f);
        turnPoint.SetActive(true);
        spaceShip.SetActive(true);
        yield return new WaitForSeconds(3f);
        dialogueBox.SetActive(true);
        yield return new WaitForSeconds(0.5f); // Wait for the panel to appear
        dialogueText.text = "Dialogue 2";
        yield return new WaitForSeconds(3f);
        dialogueText.text = "";
        dialogueBox.SetActive(false);
        yield return new WaitForSeconds(1f);
        scene3.SetActive(true);
        yield return new WaitForSeconds(2f);
        dialogueBox.SetActive(true);
        yield return new WaitForSeconds(0.5f); // Wait for the panel to appear
        dialogueText.text = "Dialogue 3";
        yield return new WaitForSeconds(3f);
        dialogueText.text = "";
        dialogueBox.SetActive(false);
        SceneManager.LoadScene(1);
        
    }
}
