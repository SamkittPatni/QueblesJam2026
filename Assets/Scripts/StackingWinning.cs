using UnityEngine;

public class StackingWinning : MonoBehaviour
{
    [SerializeField] private StackingGameManager gameManager;

    public float stabilityTimer = 0f;
    public float requiredStabilityTime = 3f;
    public bool isTouchingBlock = false;
    public bool gameWon = false;
    public void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(stabilityTimer);
        stabilityTimer += Time.deltaTime;
        if (stabilityTimer >= requiredStabilityTime)
        {
            Debug.Log("Winner!");
            gameWon = true;
            gameManager.WinGame(); /// tell game manager to stop game (see gm script)
        }


    }
    ///public void OnTriggerEnter2D(Collider2D collision)
    //{
      ///  Debug.Log("here");
   /// }
///
    /// <summary>
    ///  reset timer
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerExit2D(Collider2D collision)
    {
        stabilityTimer = 0f;
    }
}
