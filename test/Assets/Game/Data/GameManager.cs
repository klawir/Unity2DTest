using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject PlayerStartPosition;
    public GameObject EnemyStartPosition;
    public Unit Player;
    private Quaternion rotation;
    private void ResetGame()
    {
        Player.Move = PlayerStartPosition.transform.position;
        Enemy.transform.position = EnemyStartPosition.transform.position;
        Enemy.transform.rotation = rotation;
    }
    void Start ()
    {
        rotation.z = 0;
        ResetGame();
    }
	void Update ()
    {
        if (Input.GetKey(KeyCode.R))
            ResetGame();
    }
}