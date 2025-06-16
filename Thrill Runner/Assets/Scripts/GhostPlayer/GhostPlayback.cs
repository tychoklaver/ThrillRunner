using System.Collections.Generic;
using UnityEngine;

namespace ThrillRunner.GhostPlayer
{
    public class GhostPlayback : MonoBehaviour
    {
        private List<GhostFrame> frames;
        private int currentFrame = 0;

        public float playbackSpeed = 1f;
        private float timer = 0f;

        private Animator animator;

        void Awake() {
            animator = GetComponent<Animator>();
        }

        public void Play(List<GhostFrame> recordedFrames) {
            frames = recordedFrames;
            currentFrame = 0;
            timer = 0f;
        }

        private void Update() {
            if (frames == null || currentFrame >= frames.Count)
                return;

            GhostFrame frame = frames[currentFrame];

            transform.position = frame.position;
            transform.rotation = frame.rotation;

            animator.SetFloat("MoveSpeed", frame.moveSpeed);
            animator.SetBool("IsSprinting", frame.isSprinting);
            animator.SetBool("WalksBackwards", frame.walksBackwards);

            Debug.Log(frame.moveSpeed);
            Debug.Log(frame.isSprinting);
            Debug.Log(frame.walksBackwards);

            currentFrame++;
        }
    }
}
