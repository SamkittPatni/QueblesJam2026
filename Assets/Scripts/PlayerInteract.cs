using UnityEngine;
using System.Collections;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    private int currentNPC = -1; // -1 means no NPC in range
    public GameObject dialogueBox; // Reference to the dialogue box UI element
    public TMPro.TMP_Text dialogueText; // Reference to the TextMeshPro text element
    public GameObject transparentScreen;

    public GameObject [] dialogueCharacters; // Array of character portraits for dialogue

    public GameObject interactBackground;
    public TMP_Text interactText;

    private void OnInteract()
    {
        if (!GameManager.Instance.playedMinigame && currentNPC != -1)
        {
            if (GameManager.Instance.week == 1 && currentNPC == 1)
            {
                // Trigger minigame for week 1
                Debug.Log("Starting minigame for week 1");
                StartCoroutine(PlayMinigame(dialogueCharacters[1], dialogue: "Minigame for week 1!"));
                GameManager.Instance.playedMinigame = true;
                return;
            }
            else if (GameManager.Instance.week == 2 && currentNPC == 4)
            {
                // Trigger minigame for week 2
                Debug.Log("Starting minigame for week 2");
                StartCoroutine(PlayMinigame(dialogueCharacters[10], dialogue: "Minigame for week 2!"));
                GameManager.Instance.playedMinigame = true;
                return;
            }
            else if (GameManager.Instance.week == 3 && currentNPC == 5)
            {
                // Trigger minigame for week 3
                Debug.Log("Starting minigame for week 3");
                StartCoroutine(PlayMinigame(dialogueCharacters[13], dialogue: "Minigame for week 3!"));
                GameManager.Instance.playedMinigame = true;
                return;
            }
        }
        if (currentNPC != -1)
        {
            Debug.Log("Interacting with NPC: " + currentNPC);
            // Here you would trigger the dialogue or interaction logic for the NPC
            switch (currentNPC)
            {
                case 1:
                    // Trigger dialogue for NPC 1
                    if (GameManager.Instance.trust < 30f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[0], dialogue: "Hello, I'm NPC 1. Nice to meet you!"));
                    }
                    else if (GameManager.Instance.trust >= 30f && GameManager.Instance.trust < 65f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[1], dialogue: "It's good to see you again!"));
                    }
                    else if (GameManager.Instance.trust >= 65f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[2], dialogue: "We have already talked twice!"));
                    }
                    break;
                case 2:
                    // Trigger dialogue for NPC 2
                    if (GameManager.Instance.trust < 30f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[3], dialogue: "Hi there, I'm NPC 2. Welcome!"));
                    }
                    else if (GameManager.Instance.trust >= 30f && GameManager.Instance.trust < 65f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[4], dialogue: "Oh, it's you again!"));
                    }
                    else if (GameManager.Instance.trust >= 65f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[5], dialogue: "We have already talked twice!"));
                    }
                    break;
                case 3:
                    // Trigger dialogue for NPC 3
                    if (GameManager.Instance.trust < 30f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[6], dialogue: "Hey, I'm NPC 3. Nice to meet you!"));
                    }
                    else if (GameManager.Instance.trust >= 30f && GameManager.Instance.trust < 65f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[7], dialogue: "It's good to see you again!"));
                    }
                    else if (GameManager.Instance.trust >= 65f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[8], dialogue: "We have already talked twice!"));
                    }
                    break;
                case 4:
                    // Trigger dialogue for NPC 4
                    if (GameManager.Instance.trust < 30f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[9], dialogue: "Hello, I'm NPC 4. Nice to meet you!"));
                    }
                    else if (GameManager.Instance.trust >= 30f && GameManager.Instance.trust < 65f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[10], dialogue: "It's good to see you again!"));
                    }
                    else if (GameManager.Instance.trust >= 65f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[11], dialogue: "We have already talked twice!"));
                    }
                    break;
                case 5:
                    // Trigger dialogue for NPC 5
                    if (GameManager.Instance.trust < 30f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[12], dialogue: "Hi, I'm NPC 5. Welcome!"));
                    }
                    else if (GameManager.Instance.trust >= 30f && GameManager.Instance.trust < 65f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[13], dialogue: "Oh, it's you again!"));

                    }
                    else if (GameManager.Instance.trust >= 65f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[14], dialogue: "We have already talked twice!"));
                    }
                    break;
                default:
                    break;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        interactBackground.SetActive(true);
        interactText.text = "Interact [E]";
        // Set currentNPC to the NPC number based on the tag of the collided object
        if (other.gameObject.CompareTag("NPC1"))
        {
            currentNPC = 1;
        }
        else if (other.gameObject.CompareTag("NPC2"))
        {
            currentNPC = 2;
        }
        else if (other.gameObject.CompareTag("NPC3"))
        {
            currentNPC = 3;
        }
        else if (other.gameObject.CompareTag("NPC4"))
        {
            currentNPC = 4;
        }
        else if (other.gameObject.CompareTag("NPC5"))
        {
            currentNPC = 5;
        }
        Debug.Log("Collided with: " + currentNPC);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        currentNPC = -1; // Reset when exiting NPC range
        interactBackground.SetActive(false);
        interactText.text = "";
    }

    IEnumerator PlayDialogue(GameObject dialogueCharacter, string dialogue)
    {
        transparentScreen.SetActive(true);
        dialogueCharacter.SetActive(true);
        yield return new WaitForSeconds(0.5f); // Wait for the panel to appear
        dialogueBox.SetActive(true);
        yield return new WaitForSeconds(0.5f); // Wait for the dialogue to appear
        dialogueText.text = dialogue;
        yield return new WaitForSeconds(3f); // Display dialogue for 3 seconds
        dialogueText.text = "";
        dialogueBox.SetActive(false);
        transparentScreen.SetActive(false);
        dialogueCharacter.SetActive(false);
    }

    IEnumerator PlayMinigame(GameObject dialogueCharacter, string dialogue)
    {
        transparentScreen.SetActive(true);
        dialogueCharacter.SetActive(true);
        yield return new WaitForSeconds(0.5f); // Wait for the panel to appear
        dialogueBox.SetActive(true);
        yield return new WaitForSeconds(0.5f); // Wait for the dialogue to appear
        dialogueText.text = dialogue;
        yield return new WaitForSeconds(3f); // Display dialogue for 3 seconds
        dialogueText.text = "";
        dialogueBox.SetActive(false);
        transparentScreen.SetActive(false);
        dialogueCharacter.SetActive(false);
        // Here you would load the minigame scene or trigger the minigame logic
        Debug.Log("Minigame would start now!");
    }
}
