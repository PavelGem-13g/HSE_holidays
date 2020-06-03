using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsScr : MonoBehaviour
{
    TextMeshProUGUI text;
    void Start()
    {
        PlayerPrefs.SetInt("coinsCount",0);
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = "Coins: " + PlayerPrefs.GetInt("coinsCount");
    }
}
