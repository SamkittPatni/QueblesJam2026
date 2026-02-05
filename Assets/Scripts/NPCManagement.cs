using System.Collections.Generic;
using UnityEngine;

public class NPCManagement : MonoBehaviour
{
    public GameObject[] NPCs;
    private List<Vector3> NPCositions = new List<Vector3> {
        new Vector3(1.26f, -2.79f, 0),
        new Vector3(-3.16f, 4.04f, 0),
        new Vector3(9.02f, -4.45f, 0),
        new Vector3(11.28f, -0.7f, 0),
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
