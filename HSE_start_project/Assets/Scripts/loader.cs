using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loader : MonoBehaviour
{
    public int sceneNumber;
    public void Play()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
