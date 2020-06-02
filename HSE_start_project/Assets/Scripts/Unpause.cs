using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unpause : MonoBehaviour
{
    public GameObject pause;
    public void Play()
    {
        FindObjectOfType<Exit>().isPause = false;
        pause.SetActive(false);
    }
}
