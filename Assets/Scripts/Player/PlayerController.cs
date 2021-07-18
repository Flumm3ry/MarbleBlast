using UnityEngine;
using UnityEngine.InputSystem;
using System;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeReference]
    private float movementSpeed = 200f;

    [SerializeReference]
    private float jumpForce = 400f;

    private bool canJump = false;

    private PlayerMotor _motor;

    private Camera _playerCamera;

    private string _powerup;

    public string Powerup { get { return _powerup; } }

    public int Lives { get; set; } = 3;

    void Start()
    {
        _motor = GetComponent<PlayerMotor>();
        _playerCamera = GetComponentInChildren<Camera>() ?? Camera.main;
    }

    void Update()
    {

    }

    public void AddPowerup(string powerup)
    {
        _powerup = powerup;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
            canJump = true;
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
            canJump = false;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (canJump)
            _motor.Jump(jumpForce);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var rawForce = context.ReadValue<Vector2>();

        Vector3 movementVector = _playerCamera.transform.rotation * new Vector3(rawForce.x, 0f, rawForce.y);
        _motor.Move(movementVector.normalized * movementSpeed);
    }

    public void OnLose()
    {
        _playerCamera.transform.position = new Vector3(61.4f, 22.3f, 0f);
        _playerCamera.transform.LookAt(GameObject.FindWithTag("Floor").transform, Vector3.up);
    }
}
