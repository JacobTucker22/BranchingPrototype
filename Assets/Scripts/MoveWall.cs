using UnityEngine;
using DG.Tweening; // Ensure DOTween is imported

public class MoveWall : MonoBehaviour
{
    [Header("Movement Settings")]
    public bool moveRight = true; // If true, move right; if false, move left
    public int moveDistance = 5;  // Distance to move in units

    [Header("Tween Settings")]
    public float moveDuration = 1f; // Duration of the movement in seconds

     public void Move()
     {
          Vector3 targetPosition = transform.position;

          if (moveRight)
               targetPosition += Vector3.right * moveDistance;
          else
               targetPosition += Vector3.left * moveDistance;

          // Move the GameObject using DOTween
          transform.DOMove(targetPosition, moveDuration);
     }
}


