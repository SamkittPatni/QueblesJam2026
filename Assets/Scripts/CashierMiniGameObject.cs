using UnityEngine;
using System.Collections;

public class CashierMiniGameObject : MonoBehaviour
{
    public float speed = 2;
    public float Duration = 5f;
    [Header("Cutscene Settings")]
    public Vector3 StartPosition;
    public Vector3 EndPosition;

    void Start()
    {
        transform.position = StartPosition;
        StartCoroutine(SetUpScene());
    }
    IEnumerator SetUpScene()
    {
        float timePassed = 0f;
        float t = 0f;
        while (timePassed < Duration)
        {
            transform.position = Vector3.Lerp(StartPosition, EndPosition, t);
            timePassed += Time.deltaTime;
            t = timePassed/Duration;
            yield return null;
        }

        transform.position = EndPosition;
    }
}