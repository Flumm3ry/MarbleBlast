using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    private bool canJump = false;

    [SerializeReference]
    private float movementSpeed = 200f;

    [SerializeReference]
    private float jumpForce = 400f;

    private PlayerMotor _motor;

    private Camera _playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        _motor = GetComponent<PlayerMotor>();
        _playerCamera = GetComponentInChildren<Camera>() ?? Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) 
    {
        canJump = true;
    }
 
    void OnCollisionExit(Collision other) 
    {
        canJump = false;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (canJump) _motor.Jump(jumpForce);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var rawForce = context.ReadValue<Vector2>();

        Vector3 movementVector = _playerCamera.transform.rotation * new Vector3(rawForce.x, 0f, rawForce.y);
        _motor.Move(movementVector.normalized * movementSpeed);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();

        _motor.RotateCamera(direction);
    }
}
