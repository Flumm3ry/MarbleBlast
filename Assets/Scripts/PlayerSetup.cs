using UnityEngine;
using Mirror;
using System.Linq;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeReference]
    private Behaviour[] _componentsToDisable;
    
    private Camera sceneCamera;

    void Start()
    {
        sceneCamera = Camera.main;

        if (!isLocalPlayer)
        {
            foreach (var c in _componentsToDisable)
            {
                c.enabled = false;
            }
        } else {
            sceneCamera?.gameObject.SetActive(false);
        }
    }

    void OnDisable()
    {
        sceneCamera?.gameObject.SetActive(true);
    }
}
