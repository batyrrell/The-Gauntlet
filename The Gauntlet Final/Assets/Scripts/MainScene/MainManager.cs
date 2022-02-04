using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public GameObject[] player;
    Vector3 playerPos = new Vector3(0, 1, 0);
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
        Instantiate(player[difficulty], playerPos, Quaternion.Euler(new Vector3(0, 45, 0)));
    }
    void Start()
    {
        SpawnPlayer();
    }
}
