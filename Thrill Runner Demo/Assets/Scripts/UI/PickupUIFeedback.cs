using UnityEngine;
using TMPro;

namespace ThrillRunner.UI
{
    /// <summary>
    /// Handles displaying pickup messages on the UI for a limited time.
    /// </summary>
    public class PickupUIFeedback : MonoBehaviour
    {
        [SerializeField] private TMP_Text messageText;
        [SerializeField] private float displayTime = 2f;

        private float timer = 0f;

        /// <summary>
        /// Checks every frame if the pickup message should be hidden after the display duration.
        /// Uses unscaled time to avoid pausing when the game is paused or slowed.
        /// </summary>
        private void Update() {
            if (messageText.gameObject.activeSelf) {
                timer -= Time.unscaledDeltaTime;
                if (timer <= 0f)
                    messageText.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Shows the given pickup message on the UI and resets display timer.
        /// </summary>
        /// <param name="message">The pickup message to display.</param>
        public void ShowPickupMessage(string message) {
            messageText.text = message;
            messageText.gameObject.SetActive(true);
            timer = displayTime;
        }
    }
}
