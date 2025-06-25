using UnityEngine;

namespace ThrillRunner.Levels
{
    /// <summary>
    /// Trigger that starts the level timer and ghost recording.
    /// This object destroys itself after activation to prevent retriggering.
    /// </summary>
    public class StartTrigger : PlayerTrigger
    {
        /// <summary>
        /// Called when the player enters the trigger. Starts the level and removes the trigger.
        /// </summary>
        /// <param name="player">The player's collider.</param>
        protected override void OnPlayerTrigger(Collider player) {
            LevelManager.Instance?.StartLevel();
            Destroy(gameObject);
        }
    }
}
