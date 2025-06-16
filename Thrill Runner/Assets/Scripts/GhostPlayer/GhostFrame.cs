using UnityEngine;

namespace ThrillRunner.GhostPlayer
{
    [System.Serializable]
    public struct GhostFrame
    {
        public Vector3 position;
        public Quaternion rotation;
        public float moveSpeed;
        public bool isSprinting;
        public bool walksBackwards;

        public GhostFrame(Transform t, float speed, bool sprinting, bool backwards) {
            position = t.position;
            rotation = t.rotation;
            moveSpeed = speed;
            isSprinting = sprinting;
            walksBackwards = backwards;
        }
    }
}
