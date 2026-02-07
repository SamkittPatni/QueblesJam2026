using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 moveInput;
    // Speed of the player movement
    public float moveSpeed = 5f;

    public Animator animator;

    void OnMove(InputValue value)
    {
        // Get movement input from Input System
        moveInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        // Move the player based on input
        transform.Translate(new Vector3(moveInput.x, moveInput.y, 0) * Time.deltaTime * moveSpeed);

        bool isMovingNow = moveInput.sqrMagnitude > 0.3f;
        animator.SetBool("isMoving", isMovingNow);

        if (isMovingNow) 
        {
            animator.SetFloat("Horizontal", moveInput.x);
            animator.SetFloat("Vertical", moveInput.y);
        }
    }
}
