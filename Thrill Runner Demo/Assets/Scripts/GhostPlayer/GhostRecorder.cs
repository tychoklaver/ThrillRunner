using System.Collections.Generic;
using UnityEngine;

namespace ThrillRunner.GhostPlayer
{
    /// <summary>
    /// Records a sequence of player positions and rotations over time,
    /// storing them as ghost frames for playback or analysis.
    /// </summary>
    public class GhostRecorder : MonoBehaviour
    {
        /// <summary>
        /// The list of all recorded ghost frames.
        /// </summary>
        public List<GhostFrame> RecordedFrames { get; private set; } = new List<GhostFrame>();

        // Whether the recorder is currently recording frames.
        private bool recording = false;

        /// <summary>
        /// Begins a new ghost recording session, clearing previous data.
        /// </summary>
        public void StartRecording() {
            RecordedFrames.Clear();
            recording = true;
        }

        /// <summary>
        /// Stops the recording session.
        /// </summary>
        public void StopRecording() {
            recording = false;
        }

        /// <summary>
        /// Captures a new frame each update while recording is active.
        /// </summary>
        private void Update() {
            if (!recording) return;

            RecordedFrames.Add(new GhostFrame(transform));
        }
    }
}
