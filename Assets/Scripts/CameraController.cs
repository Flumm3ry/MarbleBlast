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
    }

    // Update is called once per frame
    void Update()
    {
    }

    void LateUpdate()
    {
        
    }
}
