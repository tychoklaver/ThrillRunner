using UnityEngine;
using ThrillRunner;

namespace ThrillRunner.Levels
{
    public class GoalTrigger : PlayerTrigger
    {
        protected override void OnPlayerTrigger(Collider player) {
            LevelManager.Instance?.CompleteLevel();
        }
    }
}
