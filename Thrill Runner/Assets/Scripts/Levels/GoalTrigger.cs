using UnityEngine;
using ThrillRunner;

namespace ThrillRunner.Levels
{
    /// <summary>
    /// Trigger that marks the player reaching the level's goal.
    /// Inherits from <see cref="PlayerTrigger"/> to handle player-specific collisions.
    /// </summary>
    public class GoalTrigger : PlayerTrigger
    {
        /// <summary>
        /// Called when the player enters the trigger collider.
        /// Notifies the LevelManager to mark the level as completed.
        /// </summary>
        /// <param name="player">The player's collider which triggered this.</param>
        protected override void OnPlayerTrigger(Collider player) {
            LevelManager.Instance?.CompleteLevel();
        }
    }
}
