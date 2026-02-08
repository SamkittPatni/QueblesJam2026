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

    public bool CatOnScreen = false; /// is referred to in QButtonAppear script

    private float startTime = 0f;

    //public float pulseSpeed = 1f;    // How fast it breathes
    //public float pulseAmount = 0.02f; // How much it grows/shrinks
    //private Vector3 baseScale;
    //private Vector3 scaleChange;

    private float waitBeforeOnScreen = 2f;
    private float timePassed = 0f;
    private float t = 0f;
    [SerializeField] private StackingGameManager gameManager;

    private Coroutine hungerTimer;


    ///void Awake()
    ///{
    /// scaleChange = new Vector3(0.01f, 0.01f, 0f);
    ///}

    void Start()
    {
        transform.position = StartPosition;
        StartCoroutine(ArrivalSequence());
        ////baseScale = transform.localScale;
    }

    void Update()
    {
        if (gameManager.playing == false)
        {
            Movement(OnScreenPosition, ExitPosition)
        }
    }

    public IEnumerator Movement(Vector3 positionA, Vector3 positionB)
    {
        timePassed = 0f;
        t = 0f;
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

    //void Update() 
   // {
        // Calculate the scale change using a Sine wave
        // Mathf.Sin returns a value between -1 and 1
        ////float scaleFactor = Mathf.Sin((Time.time * pulseSpeed) + 1f) * pulseAmount;

        ///float absScaleFactor = Mathf.Abs(scaleFactor);

        ///Debug.Log(absScaleFactor);
        ///if (absScaleFactor > 0.15)
        ///{
            // Apply the scale relative to the base size
        //    transform.localScale = baseScale += new Vector3(absScaleFactor, absScaleFactor, 0f);
        //}

      
        //transform.localScale += scaleChange;

        ///if (transform.localScale.y < 0.1f || transform.localScale.y > 0.12f)
        ///{

//            scaleChange = -scaleChange;
       /// }

 //   }

    public IEnumerator Transition() {
        Debug.Log("6767676767");
        if (hungerTimer != null) 
        {
            StopCoroutine(hungerTimer);
            hungerTimer = null;
        }



        Debug.Log("Scared away! Timer stopped.");
        yield return StartCoroutine(Movement(OnScreenPosition, ExitPosition));
        CatOnScreen = false;
        yield return new WaitForSeconds(5f);

        if (gameManager != null && gameManager.playing)
        {
            StartCoroutine(ArrivalSequence());
        }
        else
        {
            Debug.Log("Game Stopped: Cat will no longer appear.");
        }
    }

    private IEnumerator HungerTimer()
    {
        yield return new WaitForSeconds(5f);


        if (gameManager != null && gameManager.playing == true)
        {
            gameManager.RemoveLastBlock();
            Debug.Log("The cat was too hungry! Block removed.");
        }
    }

    IEnumerator ArrivalSequence()
    {
        if (gameManager == null || !gameManager.playing)
        {
            yield break;
        }

        yield return StartCoroutine(Movement(StartPosition, OnScreenPosition));

        hungerTimer = StartCoroutine(HungerTimer());

        CatOnScreen = true;
    }
}




