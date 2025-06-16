using UnityEngine;

namespace ThrillRunner.Levels
{
    public class StartTrigger : PlayerTrigger
    {
        protected override void OnPlayerTrigger(Collider player) {
            LevelManager.Instance?.StartLevel();
            Destroy(gameObject);
        }
    }
}
