using System.Collections.Generic;
using UnityEngine;

public class NPCManagement : MonoBehaviour
{
    public GameObject[] NPCs;
    private List<Vector3> NPCositions = new List<Vector3> {
        new Vector3(-2.3f, -2.25f, 0),
        new Vector3(-3.16f, 4.04f, 0),
        new Vector3(7.9f, -4.39f, 0),
        new Vector3(13.1f, -0.13f, 0),
        new Vector3(-10.28f, -3.96f, 0)
    };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Week: " + GameManager.Instance.week);
        for (int i = 0; i < NPCs.Length; i++)
        {
            Instantiate(NPCs[i], NPCositions[i], Quaternion.identity);
        }
        // switch (GameManager.Instance.week)
        // {
        //     case 1:
        //         // Initialize NPCs for week 1
        //         break;
        //     case 2:
        //         // Initialize NPCs for week 2
        //         break;
        //     case 3:
        //         // Initialize NPCs for week 3
        //         break;
        //     case 4:
        //         // Initialize NPCs for week 4
        //         break;
        //     default:
        //         // Initialize NPCs for other weeks or default state
        //         break;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
