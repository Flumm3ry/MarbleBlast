using UnityEngine;
using MLAPI;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeReference]
    private Behaviour[] _componentsToDisable;
    
    private Camera sceneCamera;

    void Start()
    {
        sceneCamera = Camera.main;

        if (!IsLocalPlayer)
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
