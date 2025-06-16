using UnityEngine;
using UnityEngine.SceneManagement;

namespace ThrillRunner.Levels
{
        
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance { get; private set; }

        [SerializeField] private GhostManager ghostManager;
        [SerializeField] private UIManager uiManager;

        private float timer;
        private bool levelStarted;
        private bool levelFinished;

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

        public void StartLevel() {
            levelStarted = true;
            timer = 0f;
            ghostManager.StartRecording();
        }

        public void CompleteLevel() {
            levelFinished = true;
            Time.timeScale = 0f;
            ghostManager.StopRecording();
            ghostManager.PlayGhost();
            uiManager.ShowGoalPanel(true);
        }

        public void PlayerDeath() {
            levelFinished = true;
            Time.timeScale = 0f;
            uiManager.ShowDeathPanel(true);
        } 

        public void RestartLevel() {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void MainMenu() {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }

}
