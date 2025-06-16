using UnityEngine;
using System.Collections.Generic;
using ThrillRunner.GhostPlayer;

namespace ThrillRunner.Levels
{
    public class GhostManager : MonoBehaviour
    {
        [SerializeField] private GhostRecorder recorder;
        [SerializeField] private GhostPlayback ghostPrefab;

        public List<GhostFrame> RecordedFrames => recorder?.RecordedFrames;

        public void StartRecording() => recorder?.StartRecording();
        public void StopRecording() => recorder?.StopRecording();

        public void PlayGhost() {
            if (ghostPrefab == null || recorder == null) return;

            GhostPlayback ghost = Instantiate(ghostPrefab);
            ghost.Play(recorder.RecordedFrames);
        }
    }
}
