using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class HungryCatObject : MonoBehaviour
{

    public InputAction InputSystem_Actions;
    private void OnEnable()
    {
        InputSystem_Actions.Enable();
    }

    private void OnDisable()
    {
        InputSystem_Actions.Disable();
    }

    public float speed = 4f;
    public float Duration = 0.5f;

    public Vector3 StartPosition;
    public Vector3 OnScreenPosition;
    public Vector3 ExitPosition;

    private float startTime = 0f;



    private float waitBeforeOnScreen = 2f;
    private float timePassed = 0f;
    private float t = 0f;

    void Start()
    {
        transform.position = StartPosition;
        StartCoroutine(Movement(StartPosition, OnScreenPosition));
    }

    
    
    public IEnumerator Movement(Vector3 positionA, Vector3 positionB)
    {
        yield return new WaitForSeconds(waitBeforeOnScreen);
        {

            while (timePassed < Duration)
            {
                transform.position = Vector3.Lerp(positionA, positionB, t);
                timePassed += Time.deltaTime;
                t = timePassed / Duration;
                yield return null;
            }

            transform.position = positionB;

        }
        
    }

   /// public void OnMultitap() {
      ///  Debug.Log("6767676767");
        ///StartCoroutine(Movement(OnScreenPosition, ExitPosition));
       /// StartCoroutine(Transition());
    ///}

    public IEnumerator Transition() {
        Debug.Log("6767676767");
        yield return StartCoroutine(Movement(OnScreenPosition, ExitPosition));
        yield return new WaitForSeconds(5f);    
        StartCoroutine(Movement(StartPosition, OnScreenPosition));
    }
}




