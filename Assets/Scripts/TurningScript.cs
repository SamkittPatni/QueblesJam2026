using UnityEngine;

public class TurningScript : MonoBehaviour
{
    public GameObject turnPoint; // The point around which the player will turn
    float startTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        startTime += Time.deltaTime;
        if (startTime >= 1f) // Start turning after 1 second
        {
            Quaternion _targetRot = Quaternion.AngleAxis(-90, transform.forward);
            turnPoint.transform.rotation = Quaternion.Lerp(turnPoint.transform.rotation, _targetRot, 1f * Time.deltaTime);
        }
    }
}
