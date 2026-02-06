using UnityEngine;
using System.Collections;

public class CashierMiniGameObject : MonoBehaviour
{
    public float speed = 4f;
    public float Duration = 0.5f;
    [Header("Cutscene Settings")]
    public Vector3 StartPosition;
    public Vector3 OnScreenPosition;
    public Vector3 ExitPosition;

    void Start()
    {
        transform.position = StartPosition;
        StartCoroutine(Movement(StartPosition, OnScreenPosition));
    }
    public IEnumerator Movement(Vector3 positionA, Vector3 positionB)
    {
        float timePassed = 0f;
        float t = 0f;
        while (timePassed < Duration)
        {
            transform.position = Vector3.Lerp(positionA, positionB, t);
            timePassed += Time.deltaTime;
            t = timePassed/Duration;
            yield return null;
        }

        transform.position = positionB;
    }
 
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}