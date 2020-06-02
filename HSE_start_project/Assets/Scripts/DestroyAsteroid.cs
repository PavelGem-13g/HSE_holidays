using UnityEngine;
using System.Collections;

public class DestroyAsteroid : MonoBehaviour
{
    void Update()
    {
        Destroy(this.gameObject, 0.4f / PlayerPrefs.GetFloat("speedCoeff"));
    }
}