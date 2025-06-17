using UnityEngine;

namespace ThrillRunner.Levels
{
    /// <summary>
    /// Triggers the player's death when they collide with this object.
    /// Inherits from <see cref="PlayerTrigger"/> to centralize player collision logic.
    /// </summary>
    public class DeathTrigger : PlayerTrigger
    {
        /// <summary>
        /// Called when the player enters the trigger collider.
        /// Notifies the LevelManager to handle player death logic.
        /// </summary>
        /// <param name="player">The collider belonging to the player.</param>
        protected override void OnPlayerTrigger(Collider player) {
            LevelManager.Instance?.PlayerDeath();
        }
    }
}
