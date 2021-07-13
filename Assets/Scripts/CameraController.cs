using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float distance;
    public float rotationSpeed;
    [Range(0f, 1f)]
    public float smoothFactor;
    public Vector3 initialOffset;
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _offset = initialOffset;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + _offset * distance;
    }

    void LateUpdate()
    {
        Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);

        _offset = camTurnAngle * _offset;

        transform.LookAt(player);
    }
}
