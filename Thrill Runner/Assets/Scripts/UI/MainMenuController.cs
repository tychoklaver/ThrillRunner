using UnityEngine;
using UnityEngine.SceneManagement;

namespace ThrillRunner.UI
{
    /// <summary>
    /// Controls Main Menu UI interactions, including starting the game,
    /// showing the tutorial panel and exiting the application.
    /// </summary>
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject tutorialPanel;

        private const int LEVEL_SCENE_INDEX = 1;

        /// <summary>
        /// Initializes the menu by hiding the tutorial panel at startup.
        /// </summary>
        void Awake() {
            tutorialPanel?.SetActive(false);
        }

        /// <summary>
        /// Loads the main game scene when the Play button is pressed.
        /// </summary>
        public void OnPlayButtonPressed() {
            SceneManager.LoadScene(LEVEL_SCENE_INDEX);
        }

        /// <summary>
        /// Shows the tutorial panel when the Tutorial button is pressed.
        /// </summary>
        public void OnTutorialButtonPressed() {
            tutorialPanel?.SetActive(true);
        }

        /// <summary>
        /// Handles game exit requests.
        /// Logs the request and quits the application.
        /// Stops play mode if running inside the Unity Editor.
        /// </summary>
        public void OnExitButtonPressed() {
            Debug.Log("Exit Game requested.");
            Application.Quit();
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #endif
        }

        /// <summary>
        /// Closes/hides the tutorial panel.
        /// </summary>
        public void CloseTutorialPanel() {
            tutorialPanel?.SetActive(false);
        }
    }
}
