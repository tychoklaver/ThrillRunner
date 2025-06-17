using UnityEngine;

namespace ThrillRunner.Pickups
{
    /// <summary>
    /// Applies a rotation effect to the pickup.
    /// Useful for drawing attention to pickups or interactive objects.
    /// </summary>
    public class RotatingPickup : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 200f; // Speed of rotating animation.

        void Update() {
            // Rotates the pickup.
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}
