using UnityEngine;
using TMPro;

public class PhysicsDisplay : MonoBehaviour
{
    public Rigidbody2D rb;  // Player Rigidbody
    public TextMeshProUGUI physicsText;  // UI Text element

    private void Update()
    {
        // Get physics values
        float velocity = rb.linearVelocity.magnitude;  // Speed in m/s
        float mass = rb.mass;  // Mass in kg
        Vector2 momentum = mass * rb.linearVelocity;  // p = mv
        float acceleration = rb.linearVelocity.magnitude / Time.deltaTime;  // Approximate acceleration

        // Display values
        physicsText.text = $"Velocity: {velocity:F2} m/s\n" +
                           $"Momentum: {momentum.magnitude:F2} kg·m/s\n" +
                           $"Acceleration: {acceleration:F2} m/s²\n" +
                           $"Mass: {mass} kg";
    }
}
