using UnityEngine;
using UnityEngine.SceneManagement;

namespace ThrillRunner.Levels
{
    /// <summary>
    /// Manages the state and flow of a level, including timing, player progress, and UI interactions.
    /// Acts as a central controller for level logic.
    /// </summary>
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private GhostManager ghostManager;
        [SerializeField] private UIManager uiManager;

        private float timer;
        private bool levelStarted;
        private bool levelFinished;

        public static LevelManager Instance { get; private set; }

        void Awake() {
            if (Instance != null)
                Destroy(gameObject);
            else 
                Instance = this;

            uiManager.ShowGoalPanel(false);
            uiManager.ShowDeathPanel(false);
        }

        private void Update() {
            if (levelStarted && !levelFinished) {
                timer += Time.deltaTime;
                uiManager.UpdateTimer(timer);
            }
        }

        /// <summary>
        /// Starts the level timer and begins recording ghost data.
        /// </summary>
        public void StartLevel() {
            levelStarted = true;
            timer = 0f;
            ghostManager.StartRecording();
        }

        /// <summary>
        /// Handles level completion: stops timer, plays ghost, freezes time, and shows UI.
        /// </summary>
        public void CompleteLevel() {
            levelFinished = true;
            Time.timeScale = 0f;
            ghostManager.StopRecording();
            ghostManager.PlayGhost();
            uiManager.ShowGoalPanel(true);
        }

        /// <summary>
        /// Called when the player dies. Freezes the time and displays the death UI.
        /// </summary>
        public void PlayerDeath() {
            levelFinished = true;
            Time.timeScale = 0f;
            uiManager.ShowDeathPanel(true);
        } 

        /// <summary>
        /// Restarts the current level by reloading the scene.
        /// </summary>
        public void RestartLevel() {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        /// <summary>
        /// Returns the player to the main menu.
        /// </summary>
        public void MainMenu() {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }

}
