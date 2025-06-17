using System;
using UnityEngine;

namespace ThrillRunner.Events
{
    /// <summary> 
    /// A global event channel responsible for broadcasting visual pickup events.
    /// Use this to notify listeners when a pickup has been collected in the world.
    /// </summary>
    public class PickupEventChannel : MonoBehaviour
    {
        /// <summary>
        /// Raised when a visual pickup has been collected.
        /// Includes the pickup's name and its world position.
        /// </summary>
        public event Action<string, Vector3> OnVisualPickupCollected;

        /// <summary>
        /// Singleton Instance for global access to this event channel.
        /// Will be set during Awake.
        /// </summary>
        public static PickupEventChannel Instance { get; private set; }

        /// <summary>
        /// Ensures only one instance exists and assigns the Singleton reference.
        /// Destroys duplicates on scene load.
        /// </summary>
        private void Awake() {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else 
                Instance = this;
        }

        /// <summary>
        /// Triggers the visual pickup collected event with a message and world position.
        /// </summary>
        /// <param name="pickupName">Message of collected pickup.</param>
        /// <param name="position">World position of the pickup at time of collection.</param>
        public void BroadcastVisualPickup(string pickupName, Vector3 position) {
            OnVisualPickupCollected?.Invoke(pickupName, position);
        }
    }
}
