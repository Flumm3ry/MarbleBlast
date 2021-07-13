using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    private bool canJump = false;

    public float movementSpeed = 200f;
    public float jumpForce = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
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

    // For all physics stuff
    void FixedUpdate()
    {
        Vector3 movementVector = new Vector3();
        if (Input.GetKey("w")) movementVector += Vector3.forward;
        if (Input.GetKey("s")) movementVector += Vector3.back;
        if (Input.GetKey("d")) movementVector += Vector3.right;
        if (Input.GetKey("a")) movementVector += Vector3.left;

        if (Input.GetKey("space") && canJump) rb.AddForce(Vector3.up * jumpForce);
        
        rb.AddForce(movementVector.normalized * movementSpeed * Time.deltaTime );

        
    }
}
