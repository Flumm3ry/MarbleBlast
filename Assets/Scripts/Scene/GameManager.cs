using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{    
    public GameObject[] players;
    public float timeRemaining = 120f;
    void Start()
    {

    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;

        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            CheckOutOfBounds(player);
        }
    }

    private void CheckOutOfBounds(GameObject player)
    {
        if (player.transform.position.y < -10f)
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
