using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Exit : MonoBehaviour
{

    public GameObject target;//Добавляем сюда звездолет игрока
    float timer = 3f;


    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))//Если будет нажата кнопка назад во время игры, то:
        {
            if (PlayerPrefs.GetInt("tempScore") > PlayerPrefs.GetInt("score"))
            {
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("tempScore"));
            }
            SceneManager.LoadScene(1);
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