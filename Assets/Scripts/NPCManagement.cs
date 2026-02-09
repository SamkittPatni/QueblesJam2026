using System.Collections.Generic;
using UnityEngine;

public class NPCManagement : MonoBehaviour
{
    public GameObject[] NPCs;
    private List<Vector3> NPCositions = new List<Vector3> {
        new Vector3(-2.3f, -2.25f, 0),
        new Vector3(-3.16f, 4.04f, 0),
        new Vector3(7.21f, -4.69f, 0),
        new Vector3(13.54f, -0.13f, 0),
        new Vector3(-10.28f, -3.96f, 0)
    };

    public GameObject NPC1Exclamation;
    public GameObject NPC4Exclamation;
    public GameObject NPC5Exclamation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Week: " + GameManager.Instance.GetWeek());
        for (int i = 0; i < NPCs.Length; i++)
        {
            Instantiate(NPCs[i], NPCositions[i], Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.HasPlayedMinigame())
        {
            // If the minigame has been played, hide all exclamation marks
            NPC1Exclamation.SetActive(false);
            NPC4Exclamation.SetActive(false);
            NPC5Exclamation.SetActive(false);
        }
        else
        {
            switch (GameManager.Instance.GetWeek())
        {
            case 1:
                // Initialize NPCs for week 1
                NPC1Exclamation.SetActive(true);
                NPC4Exclamation.SetActive(false);
                NPC5Exclamation.SetActive(false);
                break;
            case 2:
                // Initialize NPCs for week 2
                NPC4Exclamation.SetActive(true);
                NPC1Exclamation.SetActive(false);
                NPC5Exclamation.SetActive(false);
                break;
            case 3:
                // Initialize NPCs for week 3
                NPC5Exclamation.SetActive(true);
                NPC1Exclamation.SetActive(false);
                NPC4Exclamation.SetActive(false);
                break;
            default:
                // Initialize NPCs for other weeks or default state
                break;
        }

        }
    }
}
