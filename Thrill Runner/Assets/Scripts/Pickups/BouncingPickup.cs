using UnityEngine;

namespace ThrillRunner.Pickups
{
    /// <summary>
    /// Causes a pickup to bounce up and down smoothly in place,
    /// using a sine wave for visual attention and feedback.
    /// </summary>
    public class BouncingPickup : MonoBehaviour
    {
        [SerializeField] private float bounceStrength = 0.5f; // Maximum vertical distance from the starting position.
        [SerializeField] private float bounceSpeed = 1f;      // Speed of the up/down bounce.

        private Vector3 startPos; // Initial world position of the pickup.

        void Start() {
            // Cache the initial position of the pickup to offset from.
            startPos = transform.position;
        }

        void Update() {
            // Oscillate the position vertically using a sine wave.
            transform.position = startPos + Vector3.up * Mathf.Sin(Time.time * bounceSpeed) * bounceStrength;
        }
    }
}
