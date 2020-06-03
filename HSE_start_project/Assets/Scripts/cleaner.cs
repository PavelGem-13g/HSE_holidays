using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cleaner : MonoBehaviour
{
    TextMeshProUGUI text;
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = "Score " + PlayerPrefs.GetInt("score").ToString();
    }
    public void Clear()
    {
        PlayerPrefs.SetInt("score", 0);
        text.text = "Score " + PlayerPrefs.GetInt("score").ToString();
    }
}
