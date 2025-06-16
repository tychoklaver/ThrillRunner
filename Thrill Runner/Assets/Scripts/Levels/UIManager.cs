using UnityEngine;
using TMPro;

namespace ThrillRunner.Levels
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private GameObject goalPanel;
        [SerializeField] private GameObject deathPanel;

        public void ShowGoalPanel(bool active) => goalPanel?.SetActive(active);
        public void ShowDeathPanel(bool active) => deathPanel?.SetActive(active);
        public void UpdateTimer(float time) {
            if (timerText != null)
                timerText.text = $"Time: {time:F2}s";
        }
    }
}
