using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsScr : MonoBehaviour
{
    TextMeshProUGUI text;
    void Start()
    {
        Memory.Set_Coin(0);
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = "Coins: " + Memory.Get_Coin();
    }
}
