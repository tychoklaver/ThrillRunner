using UnityEngine;
using ThrillRunner.Events;

namespace ThrillRunner.Pickups
{
    /// <summary>
    /// Triggers a visual pickup notification via the PickupEventChannel when collected by the player.
    /// </summary>
    public class VisualPickupBroadcaster : PlayerTrigger
    {
        [SerializeField] private string pickupLabel = "Item Collected!"; // Shown on pickup.

        /// <summary>
        /// Called when the player enters the trigger. Broadcasts a pickup event and destroys this object.
        /// </summary>
        /// <param name="player">The collider of the player object.</param>
        protected override void OnPlayerTrigger(Collider player) {
            PickupEventChannel.Instance?.BroadcastVisualPickup(pickupLabel, transform.position);
            Destroy(gameObject);
        }
    }
}
