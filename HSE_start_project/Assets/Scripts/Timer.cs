using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI text;
    public carscr player;
    public float realTime = 0;
    public int minutes=0;
    public int seconds=0;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<carscr>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<Exit>().isPause && player != null)
        {
            realTime += Time.deltaTime * Memory.Get_Speed();
        }
        seconds = Mathf.RoundToInt(realTime);
        
        if (seconds>=60)
        {
            minutes += 1;
            seconds = 0;
            realTime = 0f;
            Memory.Set_TempScore(Memory.Get_TempScore() + 100);
        }
        if (minutes < 10)
        {
            if (seconds < 10)
            {
                text.text = minutes + ":" + "0" + seconds;
            }
            if (seconds >= 10)
            {
                text.text = minutes + ":" + seconds;
            }

        }
        else text.text = minutes + ":" + seconds;
    }
    
}
