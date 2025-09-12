using PixelCrushers.DialogueSystem;
using UnityEngine;

public class SimpleTopDownController : MonoBehaviour
{
     public ProximitySelector proximitySelector;
     [Header("Movement Settings")]
    public float moveSpeed = 5f;
     public bool canMove = true;

    [Header("References")]
    [Tooltip("Assign the child GameObject (model) to rotate.")]
    public Transform modelTransform;

     private void Awake()
     {
          proximitySelector = GetComponent<ProximitySelector>();
     }

     // Update is called once per frame
     void Update()
    {
          if(!canMove) return;

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

     public void SetCanMove(bool value)
     {
          canMove = value;
          proximitySelector.enabled = value;
     }

}
