using UnityEngine;

namespace ThrillRunner
{
    public abstract class PlayerTrigger : MonoBehaviour
    {
        protected abstract void OnPlayerTrigger(Collider playerCollider);

        private void OnTriggerEnter(Collider other) {
            if (other.TryGetComponent(out PlayerIdentifier _)) {
                OnPlayerTrigger(other);
            }
        }
    }
}
