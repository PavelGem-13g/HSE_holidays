using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Memory /*: MonoBehaviour*/
{
    public static void Set_Speed(float coeff)
    {
        PlayerPrefs.SetFloat("speedCoeff", coeff);
    }
    public static float Get_Speed()
    {
        return PlayerPrefs.GetFloat("speedCoeff");
    }
    public static void Set_Score(int score)
    {
        PlayerPrefs.SetInt("score", score);
    }
    public static int Get_Score()
    {
        return PlayerPrefs.GetInt("score");
    }
    public static void Set_TempScore(int score)
    {
        PlayerPrefs.SetInt("tempScore", score);
    }
    public static int Get_TempScore()
    {
        return PlayerPrefs.GetInt("tempScore");
    }
    public static void Set_Coin(int coin)
    {
        PlayerPrefs.SetInt("coinsCount", coin);
    }
    public static int Get_Coin()
    {
        return PlayerPrefs.GetInt("coinsCount");
    }
}
