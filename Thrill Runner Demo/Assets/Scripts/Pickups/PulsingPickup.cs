using UnityEngine;

namespace ThrillRunner.Pickups
{
    /// <summary>
    /// Applies a pulsing (scaling) animation effect to the GameObject.
    /// Useful for drawing attention to pickups or interactive objects.
    /// </summary>
    public class PulsingPickup : MonoBehaviour
    {
        [SerializeField] private float pulseSpeed = 2f;    // Speed of the pulse animation.
        [SerializeField] private float pulseAmount = 0.2f; // Maximum scale amount.

        private Vector3 baseScale;
        
        void Start() {
            // Store the original scale of the object.
            baseScale = transform.localScale;
        }

        void Update() {
            // Compute a scale factor using a sine wave.
            float scale = 1f + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount;

            // Apply the pulsing scale.
            transform.localScale = baseScale * scale;
        }
    }
}
