using System.Collections.Generic;
using UnityEngine;

namespace ThrillRunner.GhostPlayer
{
    public class GhostRecorder : MonoBehaviour
    {
        public List<GhostFrame> RecordedFrames { get; private set; } = new List<GhostFrame>();
        private bool recording = false;

        private Animator animator;

        void Awake() {
            animator = GetComponent<Animator>();
        }

        public void StartRecording() {
            RecordedFrames.Clear();
            recording = true;
        }

        public void StopRecording() {
            recording = false;
        }

        private void Update() {
            if (!recording) return;

            float moveSpeed = animator.GetFloat("MoveSpeed");
            bool isSprinting = animator.GetBool("IsSprinting");
            bool backwards = animator.GetBool("WalksBackwards");

            RecordedFrames.Add(new GhostFrame(transform, moveSpeed, isSprinting, backwards));
        }
    }
}
