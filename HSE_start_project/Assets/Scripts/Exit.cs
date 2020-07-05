using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Exit : MonoBehaviour
{

    public GameObject target;
    public GameObject pause;
    float timer = 3f;
    public bool isPause=false;

    void Start()
    {
        pause.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (Memory.Get_TempScore() > Memory.Get_Score())
            {
                Memory.Set_Score(Memory.Get_TempScore());
            }
            isPause = true;
            pause.SetActive(true);
        }
        if (target==null)
        {
            if (Memory.Get_TempScore() > Memory.Get_Score())
            {
                Memory.Set_Score(Memory.Get_TempScore());
            }
            timer = timer - Time.deltaTime;
            if (timer < 0)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}