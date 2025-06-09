using UnityEngine;
using UnityEngine.SceneManagement;

namespace ThrillRunner.UI
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject gameModeSelectionPanel;
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private GameObject controlsOverviewPanel;

        private const int LEVEL_SCENE_INDEX = 1;
        private const int OPEN_WORLD_INDEX = 2;

        void Awake() {
            // Ensure all sub-panels are disabled at startup.
            gameModeSelectionPanel?.SetActive(false);
            settingsPanel?.SetActive(false);
            controlsOverviewPanel?.SetActive(false);
        }

        public void OnPlayButtonPressed() {
            gameModeSelectionPanel?.SetActive(true);
        }

        public void OnSettingsButtonPressed() {
            settingsPanel?.SetActive(true);
        }

        public void OnControlsButtonPressed() {
            controlsOverviewPanel?.SetActive(true);
        }

        public void OnExitButtonPressed() {
            Debug.Log("Exit Game requested.");
            Application.Quit();
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stops play in Unity Editor.
    #endif
        }

        public void OpenWorldSelected() {
            SceneManager.LoadScene(OPEN_WORLD_INDEX);
        }

        /// Loads the level scene.
        public void LevelModeSelected() {
            SceneManager.LoadScene(LEVEL_SCENE_INDEX);
        }

        public void CloseGameModeSelection() {
            gameModeSelectionPanel?.SetActive(false);
        }

        public void CloseSettingsPanel() {
            settingsPanel?.SetActive(false);
        }

        public void CloseControlsPanel() {
            controlsOverviewPanel?.SetActive(false);
        }
    }
}
