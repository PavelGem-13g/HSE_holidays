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
    }

    void Update()
    {
        text.text = "Score "+PlayerPrefs.GetInt("score").ToString();
    }
    public void Clear()
    {
        PlayerPrefs.SetInt("score", 0);
    }
}
