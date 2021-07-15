using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    private bool canJump = false;

    [SerializeReference]
    private float movementSpeed = 200f;

    [SerializeReference]
    private float jumpForce = 50f;

    private PlayerMotor _motor;

    // Start is called before the first frame update
    void Start()
    {
        _motor = GetComponent<PlayerMotor>();
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
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var rawForce = context.ReadValue<Vector2>();

        Vector3 movementVector = Camera.main.transform.rotation * new Vector3(rawForce.x, 0f, rawForce.y);
        _motor.Move(movementVector.normalized * movementSpeed);
    }
}
