using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 moveInput;
    public float moveSpeed = 5f;

    void OnMove(InputValue value)
    {
        // Get movement input from Input System
        moveInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        // Move the player based on input
        transform.Translate(new Vector3(moveInput.x, moveInput.y, 0) * Time.deltaTime * moveSpeed);
    }
}
