using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private int currentNPC = -1; // -1 means no NPC in range

    private void OnInteract()
    {
        if (currentNPC != -1)
        {
            Debug.Log("Interacting with NPC: " + currentNPC);
            // Here you would trigger the dialogue or interaction logic for the NPC
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
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
    }
}
