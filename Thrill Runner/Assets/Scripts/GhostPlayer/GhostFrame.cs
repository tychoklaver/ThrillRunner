using UnityEngine;

namespace ThrillRunner.GhostPlayer
{
    /// <summary>
    /// Represents a snapshot of player's movement and orientation at a specific moment.
    /// Used to record and replay ghost runs.
    /// </summary>
    [System.Serializable]
    public struct GhostFrame
    {
        /// <summary>
        /// World position of the player at this frame.
        /// </summary>
        public Vector3 position;

        /// <summary>
        /// World rotation of the player at this frame.
        /// </summary>
        public Quaternion rotation;

        /// <summary>
        /// Constructs a new frame from the given transform.
        /// </summary>
        /// <param name="t">Transform of the player at the current moment.</param>
        public GhostFrame(Transform t) {
            position = t.position;
            rotation = t.rotation;
        }
    }
}
