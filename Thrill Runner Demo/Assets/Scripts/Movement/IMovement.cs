using UnityEngine;

namespace ThrillRunner.Movement
{
    /// <summary>
    /// Interface for defining different player movement behaviors in the game.
    /// This abstraction allows for runtime swapping of movement types
    /// (e.g. dashing, walking, climbing) based on the player's selected mode.
    /// </summary>
    public interface IMovement
    {
        /// <summary>
        /// Calculates and applies the player's movement based on input.
        /// Intended to be called every frame by a movement controller.
        /// </summary>
        /// <param name="input">2D Movement Input.</param>
        /// <param name="isSprinting">Whether sprint input is currently active.</param>
        /// <returns>A Vector3 representing the intended movement for this frame.</returns>
        Vector3 Move(Vector2 input, bool isSprinting);
        void Jump();
        void Rotate(float horizontalInput, float rotationSpeed);
    }
}
