using UnityEngine;

namespace ThrillRunner
{
    /// <summary>
    /// Base class for triggers that respond specifically to player collisions.
    /// Subclasses should implement <see cref="OnPlayerTrigger"/> to define custom behavior when the player enters the trigger.
    /// </summary>
    public abstract class PlayerTrigger : MonoBehaviour
    {
        /// <summary>
        /// Called when the player enters the trigger collider.
        /// </summary>
        /// <param name="playerCollider">The collider belonging to the player.</param>
        protected abstract void OnPlayerTrigger(Collider playerCollider);

        /// <summary>
        /// Unity callback invoked when any collider enters this trigger.
        /// Checks if the collider belongs to the player and invokes <see cref="OnPlayerTrigger"/> if so.
        /// </summary>
        /// <param name="other">The collider entering the trigger.</param>
        private void OnTriggerEnter(Collider other) {
            // Only react if the collider has a PlayerIdentifier component (identifies the player).
            if (other.TryGetComponent(out PlayerIdentifier _)) 
                OnPlayerTrigger(other);
            
        }
    }
}
