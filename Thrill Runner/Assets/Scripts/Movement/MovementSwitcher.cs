using UnityEngine;

namespace ThrillRunner.Movement
{
    /// <summary>
    /// Simple runtime input-based movement switcher.
    /// Listens for specific key presses to switch between movement behaviors 
    /// (e.g. dash vs walk) using the MovementController system.
    /// </summary>
    public class MovementSwitcher : MonoBehaviour
    {
        private MovementController controller; // Reference to active MovementController.

        void Start() {
            controller = GetComponent<MovementController>();
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.Q))
                controller.SwitchMovement<DashMovement>();

            if (Input.GetKeyDown(KeyCode.E))
                controller.SwitchMovement<WalkMovement>();
        }
    }
}
