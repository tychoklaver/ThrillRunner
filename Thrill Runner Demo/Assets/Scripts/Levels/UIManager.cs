using UnityEngine;
using TMPro;

namespace ThrillRunner.Levels
{
    /// <summary>
    /// Manages the level UI elements such as the timer, goal, and death panels.
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private GameObject goalPanel;
        [SerializeField] private GameObject deathPanel;

        /// <summary>
        /// Shows or hides the goal panel based on the given flag.
        /// </summary>
        public void ShowGoalPanel(bool active) => goalPanel?.SetActive(active);

        /// <summary>
        /// Shows or hides the death panel based on the given flag.
        /// </summary>
        public void ShowDeathPanel(bool active) => deathPanel?.SetActive(active);

        /// <summary>
        /// Updates the on-screen timer text with the given time in seconds.
        /// </summary>
        /// <param name="time">The time since level start, in seconds.</param>
        public void UpdateTimer(float time) {
            if (timerText != null)
                timerText.text = $"Time: {time:F2}s";
        }
    }
}
