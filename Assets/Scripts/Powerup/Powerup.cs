using UnityEngine;

public class Powerup : MonoBehaviour
{
    public delegate void OnDestroyedHandler();
    public event OnDestroyedHandler OnDestroyed;
    
    void OnDisable()
    {
        if (OnDestroyed != null)
            OnDestroyed();
    }
    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        other.gameObject.GetComponent<PlayerController>()?.AddPowerup("Some Powerup");
        
        Destroy(gameObject);
    }
}
