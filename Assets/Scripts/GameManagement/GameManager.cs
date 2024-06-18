using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private          ObjectOwner.Player currentPlayer;
    [SerializeField] GameObject[]       players = new GameObject[4];

    void Start()
    {
        currentPlayer = ObjectOwner.Player.Player1;
        foreach (GameObject startPoint in GameObject.FindGameObjectsWithTag("StartPoint"))
        {
            ObjectOwner owner = startPoint.GetComponent<ObjectOwner>();
            if (players[0] != null && owner.player == ObjectOwner.Player.Player1)
            {
                players[0].GetComponent<Player>().CreateTower(startPoint);
            }
            if (players[1] != null && owner.player == ObjectOwner.Player.Player2)
            {
                players[1].GetComponent<Player>().CreateTower(startPoint);
            }
            if (players[2] != null && owner.player == ObjectOwner.Player.Player2)
            {
                players[2].GetComponent<Player>().CreateTower(startPoint);
            }
            if (players[3] != null && owner.player == ObjectOwner.Player.Player3)
            {
                players[3].GetComponent<Player>().CreateTower(startPoint);
            }
        }
    }
}
