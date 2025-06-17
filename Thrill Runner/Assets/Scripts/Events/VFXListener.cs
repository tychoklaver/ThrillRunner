using UnityEngine;
using ThrillRunner.UI;

namespace ThrillRunner.Events
{
    /// <summary>
    /// Listens for pickup events and triggers visual/audio effects and UI feedback.
    /// </summary>
    public class VFXListener : MonoBehaviour
    {
        [Header("Visual & Audio Feedback")]
        [Tooltip("The visual effect prefab to spawn at the pickup location.")]
        [SerializeField] private GameObject vfxPrefab;

        [Tooltip("The audio clip to play when a pickup is collected.")]
        [SerializeField] private AudioClip pickupSound;

        [Header("UI Feedback")]
        [Tooltip("UI Feedback Controller for showing pickup messages.")]
        [SerializeField] private PickupUIFeedback uiFeedback;

        /// <summary>
        /// Subscribes to the pickup event when this listener is enabled.
        /// </summary>
        private void OnEnable() {
            if (PickupEventChannel.Instance != null) 
                PickupEventChannel.Instance.OnVisualPickupCollected += PlayEffect;
        }

        /// <summary>
        /// Unsubscribes from the pickup event when this listener is disabled.
        /// </summary>
        private void OnDisable() {
            if (PickupEventChannel.Instance != null)
                PickupEventChannel.Instance.OnVisualPickupCollected -= PlayEffect;
        }

        /// <summary>
        /// Spawns a VFX prefab, plays an audio clip, and updates the UI when a pickup is colllected.
        /// </summary>
        /// <param name="label">The message for when pickup is collected.</param>
        /// <param name="position">The world position where the pickup was collected.</param>
        private void PlayEffect(string label, Vector3 position) {
            if (vfxPrefab)
                Instantiate(vfxPrefab, position, Quaternion.identity);

            if (pickupSound)
                AudioSource.PlayClipAtPoint(pickupSound, position);

            uiFeedback?.ShowPickupMessage(label);
        }
    }
}
