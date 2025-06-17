using UnityEngine;
using ThrillRunner;

namespace ThrillRunner.Pickups
{
    /// <summary>
    /// Handles player interaction with colletible pickups.
    /// Plays a sound and visual effect upon collection, then destroys itself.
    /// </summary>
    public class PickupCollectible : PlayerTrigger
    {
        [SerializeField] private AudioClip pickupSound;   // Sound to play when collected.
        [SerializeField] private GameObject pickupEffect; // Effect to play when collected.

        /// <summary>
        /// Called automatically when the player triggers the pickup.
        /// Plays audio and effects, then destroys the pickup object.
        /// </summary>
        /// <param name="player">The collider of the player object.</param>
        protected override void OnPlayerTrigger(Collider player) {
            if (pickupSound)
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);

            if (pickupEffect)
                Instantiate(pickupEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
