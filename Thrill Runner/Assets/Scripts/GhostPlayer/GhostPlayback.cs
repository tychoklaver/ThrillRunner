using System.Collections.Generic;
using UnityEngine;

namespace ThrillRunner.GhostPlayer
{
    /// <summary>
    /// Replays a recorded sequence of ghost frames by updating position and rotation each frame.
    /// </summary>
    public class GhostPlayback : MonoBehaviour
    {
        // List of recorded ghost frames to play back.
        private List<GhostFrame> frames;

        // Index of current frame being played.
        private int currentFrame = 0;

        /// <summary>
        /// Starts playback from the beginning of the provided list of ghost frames.
        /// </summary>
        /// <param name="recordedFrames">The sequence of recorded player frames to replay.</param>
        public void Play(List<GhostFrame> recordedFrames) {
            frames = recordedFrames;
            currentFrame = 0;
        }

        /// <summary>
        /// Replays the ghost by setting the transform to match each recorded frame, one per update.
        /// Stops automatically at the end of the frame list.
        /// </summary>
        private void Update() {
            if (frames == null || currentFrame >= frames.Count)
                return;

            GhostFrame frame = frames[currentFrame];

            transform.position = frame.position;
            transform.rotation = frame.rotation;

            currentFrame++;
        }
    }
}
