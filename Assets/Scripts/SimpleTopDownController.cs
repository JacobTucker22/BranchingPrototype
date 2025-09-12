using UnityEngine;

public class SimpleTopDownController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("References")]
    [Tooltip("Assign the child GameObject (model) to rotate.")]
    public Transform modelTransform;

    // Update is called once per frame
    void Update()
    {
        // Get input from WASD or arrow keys
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        // Create movement vector (XZ plane)
        Vector3 move = new Vector3(moveX, 0f, moveZ).normalized * moveSpeed * Time.deltaTime;

        // Move the root GameObject
        transform.position += move;

        // Rotate the model to face movement direction (if moving)
        Vector3 direction = new Vector3(moveX, 0f, moveZ);
        if (direction.sqrMagnitude > 0.001f && modelTransform != null)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            modelTransform.rotation = targetRotation;
        }
    }
}
