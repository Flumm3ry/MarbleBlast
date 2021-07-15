using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private Vector3 _force;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 force) {
        _force = force;
    }

    void FixedUpdate()
    {
        PerformMovement();
    }

    void PerformMovement() {
        _rb.MovePosition(_rb.position + _force * Time.fixedDeltaTime);
    }
}
