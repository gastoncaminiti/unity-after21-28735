using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score, powerupSpeed, lastSP;


    public enum typeGem { Blue, Green, Red, Black };
    public int[] gemQuantity;

    public GameData gameData = new GameData();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            //score = 0;
            score = PlayerPrefs.GetInt("Score");
            lastSP = PlayerPrefs.GetInt("SavePoint");
            powerupSpeed = 1;
            gemQuantity = new int[Enum.GetNames(typeof(typeGem)).Length];
            if(gameData.LoadGameDataJSON()){
                gemQuantity = gameData.gemQuantity;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void SaveScore(int newScore)
    {
        instance.score += newScore;
        PlayerPrefs.SetInt("Score", instance.score);
        instance.gameData.score = instance.score;
        instance.gameData.SaveGameDataJSON();

    }

    public static void SaveSP(int newIndexSP)
    {
        instance.lastSP = newIndexSP;
        PlayerPrefs.SetInt("SavePoint", instance.lastSP);
    }

    public static void SaveGemQuantity()
    {
        instance.gameData.gemQuantity = instance.gemQuantity;
        instance.gameData.SaveGameDataJSON();
    }

}
