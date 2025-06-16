using UnityEngine;

namespace ThrillRunner.Levels
{
    public class DeathTrigger : PlayerTrigger
    {
        protected override void OnPlayerTrigger(Collider player) {
            LevelManager.Instance?.PlayerDeath();
        }
    }
}
