using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{    
    GameObject[] players;
    
    [SerializeReference]
    private float distanceBeforeDeath = -10f;

    void Start()
    {

    }

    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            CheckOutOfBounds(player);
        }
    }

    private void CheckOutOfBounds(GameObject player)
    {
        if (player.transform.position.y < distanceBeforeDeath)
        {
            if (player.GetComponent<PlayerController>().Lives == 0){
                player.GetComponent<PlayerController>().OnLose();
                Destroy(player);
            } else {
                var spawnPoints = GameObject.FindGameObjectsWithTag("Spawn Point");
                player.transform.position = spawnPoints[new System.Random(DateTime.Now.Millisecond).Next(spawnPoints.Length)].transform.position;
                player.GetComponent<PlayerController>().Lives--;
            }
        }
    }
}
