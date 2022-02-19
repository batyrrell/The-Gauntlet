using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public GameObject[] player;
    public GameObject[] enemyType;
    Vector3 playerPos = new Vector3(15, 2, 20);
    Vector3 enemyPos = new Vector3(50, 0, 0);
    int difficulty;
    string oath;

    void SpawnPlayer()
    {
        difficulty = PlayerPrefs.GetInt("Difficulty");
        if (difficulty == 2)
        {
            oath = "Flagellant";
        }
        if (difficulty == 1)
        {
            oath = "Warrior";
        }
        if (difficulty == 0)
        {
            oath = "Paladin";
        }
        Debug.Log($"{oath} has been chosen.");
        Instantiate(player[difficulty], playerPos, Quaternion.identity);
        Instantiate(enemyType[difficulty], enemyPos, Quaternion.identity);
    }
    void Start()
    {
        SpawnPlayer();
    }
}
