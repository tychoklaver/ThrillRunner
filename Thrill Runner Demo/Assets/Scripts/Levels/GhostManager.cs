using UnityEngine;
using System.Collections.Generic;
using ThrillRunner.GhostPlayer;

namespace ThrillRunner.Levels
{
    /// <summary>
    /// Manages ghost recording and playback during a level session.
    /// Acts as a controller between the player's movement and ghost systems.
    /// </summary>
    public class GhostManager : MonoBehaviour
    {
        [SerializeField] private GhostRecorder recorder;
        [SerializeField] private GhostPlayback ghostPrefab;

        /// <summary> 
        /// Exposes the recorded ghost frames for readonly access.
        /// </summary>
        public List<GhostFrame> RecordedFrames => recorder?.RecordedFrames;

        /// <summary> 
        /// Starts capturing the player's movements into ghost frames.
        /// </summary>
        public void StartRecording() => recorder?.StartRecording();

        /// <summary>
        /// Stops capturing movement and finalizes the ghost recording.
        /// </summary>
        public void StopRecording() => recorder?.StopRecording();

        /// <summary>
        /// Instantiates a ghost playback object and replays the recorded path.
        /// </summary>
        public void PlayGhost() {
            if (ghostPrefab == null || recorder == null) return;

            GhostPlayback ghost = Instantiate(ghostPrefab);
            ghost.Play(recorder.RecordedFrames);
        }
    }
}
