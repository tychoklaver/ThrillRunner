using UnityEngine;

namespace ThrillRunner.Pickups
{
    /// <summary>
    /// Makes a pickup object blink by continuously cycling its material color through the HSV spectrum.
    /// Useful for drawing attention to collectibles or interactive objects.
    /// </summary>
    public class BlinkingPickup : MonoBehaviour
    {
        [SerializeField] private float colorCycleSpeed = 1f; // Speed at which the color cycles through the HSV spectrum.

        private Material _material;

        void Start() {
            // Get and store the material used by this object's renderer.
            Renderer renderer = GetComponent<Renderer>();
            _material = renderer.material;
        }

        void Update() {
            // Ping Pong a value between 0 and 1 over time to use as hue.
            float t = Mathf.PingPong(Time.time * colorCycleSpeed, 1f);

            // Convert the hue to an RGB color and apply it to the material.
            Color hsvColor = Color.HSVToRGB(t, 1f, 1f);
            _material.color = hsvColor;
        }
    }
}
