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
            if (PlayerPrefs.GetInt("tempScore") > PlayerPrefs.GetInt("score"))
            {
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("tempScore"));
            }
            //PlayerPrefs.SetFloat("speedCoeff", 0f);
            //SceneManager.LoadScene(1);
            isPause = true;
            pause.SetActive(true);
        }
        if (target==null)
        {
            if (PlayerPrefs.GetInt("tempScore") > PlayerPrefs.GetInt("score"))
            {
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("tempScore"));
            }
            timer = timer - Time.deltaTime;
            if (timer < 0)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}