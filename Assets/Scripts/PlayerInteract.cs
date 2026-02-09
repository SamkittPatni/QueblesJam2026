using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private int currentNPC = -1; // -1 means no NPC in range
    public GameObject dialogueBox; // Reference to the dialogue box UI element
    public TMPro.TMP_Text dialogueText; // Reference to the TextMeshPro text element
    public GameObject transparentScreen;

    public GameObject [] dialogueCharacters; // Array of character portraits for dialogue

    public GameObject interactBackground;
    public TMP_Text interactText;

    public GameObject NPC1Exclamation;
    public GameObject NPC4Exclamation;
    public GameObject NPC5Exclamation;

    private void OnInteract()
    {
        Debug.Log("Current Week: " + GameManager.Instance.GetWeek());
        Debug.Log(GameManager.Instance.HasPlayedMinigame());
        if (!GameManager.Instance.HasPlayedMinigame() && currentNPC != -1)
        {
            if (GameManager.Instance.GetWeek() == 1 && currentNPC == 1)
            {
                // Trigger minigame for week 1
                Debug.Log("Starting minigame for week 1");
                NPC1Exclamation.SetActive(false); // Hide exclamation mark after starting minigame
                StartCoroutine(PlayMinigame(dialogueCharacters[1], dialogue: "Can you get me some tuna cans?", sceneNumber: 2));
                GameManager.Instance.SetPlayedMinigame(true); // Mark the minigame as played for the current week
                return;
            }
            else if (GameManager.Instance.GetWeek() == 2 && currentNPC == 4)
            {
                // Trigger minigame for week 2
                Debug.Log("Starting minigame for week 2");
                NPC4Exclamation.SetActive(false); // Hide exclamation mark after starting minigame
                StartCoroutine(PlayMinigame(dialogueCharacters[10], dialogue: "Can you ring me up?", sceneNumber: 3));
                GameManager.Instance.SetPlayedMinigame(true);
                return;
            }
            else if (GameManager.Instance.GetWeek() == 3 && currentNPC == 5)
            {
                // Trigger minigame for week 3
                Debug.Log("Starting minigame for week 3");
                NPC5Exclamation.SetActive(false); // Hide exclamation mark after starting minigame
                StartCoroutine(PlayMinigame(dialogueCharacters[13], dialogue: "Can you help me find the milk please?", sceneNumber: 4));
                GameManager.Instance.SetPlayedMinigame(true);
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
                    if (!GameManager.Instance.NPC1Interacted)
                    {
                        GameManager.Instance.NPC1Interacted = true;
                        GameManager.Instance.AddTrust(2f); // Example: Increase trust by 10 points on first interaction
                    }
                    // Trigger dialogue for NPC 1
                    if (GameManager.Instance.GetTrust() < 30f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[0], dialogue: "Can't you see I'm busy here? Go do your job instead of slacking off."));
                    }
                    else if (GameManager.Instance.GetTrust() >= 30f && GameManager.Instance.GetTrust() < 65f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[1], dialogue: "Hey I like your hairband! It's certainly a bold choice to wear it to your job. I respect it."));
                    }
                    else if (GameManager.Instance.GetTrust() >= 65f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[2], dialogue: "Do you want to choose tuna cans with me for my cat? I have a FELINE that you'd know best!"));
                    }
                    break;
                case 2:
                    if (!GameManager.Instance.NPC2Interacted)
                    {
                        GameManager.Instance.NPC2Interacted = true;
                        GameManager.Instance.AddTrust(2f); // Example: Increase trust by 10 points on first interaction
                    }
                    // Trigger dialogue for NPC 2
                    if (GameManager.Instance.GetTrust() < 30f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[3], dialogue: "Should I get a cappucino or an americano? Hmm..."));
                    }
                    else if (GameManager.Instance.GetTrust() >= 30f && GameManager.Instance.GetTrust() < 65f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[4], dialogue: "Hey! Is that a cosplay you’re wearing?"));
                    }
                    else if (GameManager.Instance.GetTrust() >= 65f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[5], dialogue: "That’s a nice cosplay - do you want to go to the next Comic Con with me?"));
                    }
                    break;
                case 3:
                    if (!GameManager.Instance.NPC3Interacted)
                    {
                        GameManager.Instance.NPC3Interacted = true;
                        GameManager.Instance.AddTrust(2f); // Example: Increase trust by 10 points on first interaction
                    }
                    // Trigger dialogue for NPC 3
                    if (GameManager.Instance.GetTrust() < 30f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[6], dialogue: "‘Sup. What are you doing here?"));
                    }
                    else if (GameManager.Instance.GetTrust() >= 30f && GameManager.Instance.GetTrust() < 65f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[7], dialogue: "Honestly, I just like looking at the microwave here."));
                    }
                    else if (GameManager.Instance.GetTrust() >= 65f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[8], dialogue: "Do you wanna watch the microwave together?"));
                    }
                    break;
                case 4:
                    if (!GameManager.Instance.NPC4Interacted)
                    {
                        GameManager.Instance.NPC4Interacted = true;
                        GameManager.Instance.AddTrust(2f); // Example: Increase trust by 10 points on first interaction
                    }
                    // Trigger dialogue for NPC 4
                    if (GameManager.Instance.GetTrust() < 30f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[9], dialogue: "Just one more pull... I’ll win today."));
                    }
                    else if (GameManager.Instance.GetTrust() >= 30f && GameManager.Instance.GetTrust() < 65f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[10], dialogue: "Hey, you there. Give me some lucky numbers for today’s lottery."));
                    }
                    else if (GameManager.Instance.GetTrust() >= 65f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[11], dialogue: "If I win big, I promise you’ll get a cut."));
                    }
                    break;
                case 5:
                    if (!GameManager.Instance.NPC5Interacted)
                    {
                        GameManager.Instance.NPC5Interacted = true;
                        GameManager.Instance.AddTrust(2f); // Example: Increase trust by 10 points on first interaction
                    }
                    // Trigger dialogue for NPC 5
                    if (GameManager.Instance.GetTrust() < 30f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[12], dialogue: "*Shimmies in the aisle without a care in the world, oblivious to your presence.*"));
                    }
                    else if (GameManager.Instance.GetTrust() >= 30f && GameManager.Instance.GetTrust() < 65f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[13], dialogue: "They got greens beans potatoes tomatoes…YOU NAAAAAME IT!! What should I have for dinner?"));

                    }
                    else if (GameManager.Instance.GetTrust() >= 65f)
                    {
                        StartCoroutine(PlayDialogue(dialogueCharacters[14], dialogue: "YOOOO COME WATCH ME DANCE!! :D"));
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

    IEnumerator PlayMinigame(GameObject dialogueCharacter, string dialogue, int sceneNumber)
    {
        GameManager.Instance.SetPauseTimer(true); // Pause the week timer when starting the minigame
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
        FindAnyObjectByType<PlayerInput>().gameObject.SetActive(false);
        SceneManager.LoadScene(sceneNumber);        
    }
}
