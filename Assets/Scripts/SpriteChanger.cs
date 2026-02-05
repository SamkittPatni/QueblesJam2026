using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpriteChanger: MonoBehaviour
{
    [SerializeField] private Sprite[] tunaCanSprites;
    [SerializeField] private Sprite newTunaCanSprite;
    void Start()
    {
        newTunaCanSprite = tunaCanSprites[Random.Range(0, tunaCanSprites.Length)];
        gameObject.GetComponent<SpriteRenderer>().sprite = newTunaCanSprite;
    }

}
