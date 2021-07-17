using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private Vector3 _force;
    private Rigidbody _rb;

    private Camera _camera;

    private Vector2 _rotation;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _camera = GetComponentInChildren<Camera>();
    }

    public void Move(Vector3 force) {
        _force = force;
    }

    public void RotateCamera(Vector2 rotation) {
        _rotation = rotation;
    }

    public void Jump(float jumpForce)
    {
        _rb.AddForce(Vector3.up * jumpForce);
    }

    void FixedUpdate()
    {
        PerformMovement();
    }

    void PerformMovement() {
        _rb.AddForce(_force * Time.fixedDeltaTime);
    }
}
