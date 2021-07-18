using System;
using System.Linq;
using MLAPI;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : NetworkBehaviour
{
    private GameObject localPlayer;
    private GameObject gameManager;
    public Text livesLeftText;
    public Text timeLeftText;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        var networkPlayer = NetworkManager.Singleton.ConnectedClients.FirstOrDefault(x => x.Value.PlayerObject.IsLocalPlayer);

        if (networkPlayer.Value.PlayerObject != null) {
            var localPlayer = networkPlayer.Value.PlayerObject;
            livesLeftText.text = "Lives: " + localPlayer.GetComponent<PlayerController>().Lives;
        } else {
            livesLeftText.text = String.Empty;
        }

        var timeRemaining = Math.Round(gameManager.GetComponent<GameManager>().timeRemaining);
        timeLeftText.text = "Time Remaining: " + timeRemaining.ToString();
    }
}
