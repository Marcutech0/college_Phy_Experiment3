using TMPro;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool _isMoving = false;
    [SerializeField] private TextMeshProUGUI _speedometer;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _maxSpeed = 10f;
    [SerializeField] private float _rotationSpeed = 200f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerRotate();
        _isMoving = Input.GetKey(KeyCode.W);

        float _currentSpeed = rb.linearVelocity.magnitude;
        _speedometer.text = "Player Speed: " + _currentSpeed.ToString("F2") + " m/s";
    }

    void FixedUpdate()
    {
        if (_isMoving)
        {
            playerThrust();
        }
    }

    void playerThrust()
    {
        Vector2 force = transform.up * _moveSpeed;
        rb.AddForce(force);

        if (rb.linearVelocity.magnitude > _maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * _maxSpeed;
        }
    }

    void playerRotate()
    {
        float Hmovement = -Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, Hmovement * _rotationSpeed * Time.deltaTime);
    }
}
