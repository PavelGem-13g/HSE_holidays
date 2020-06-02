using UnityEngine;
using System.Collections;

public class asteroidlogic : MonoBehaviour
{

    public GameObject explosion;
    float speedasteroid = -0.1f;


    void Update()
    {
        transform.Translate(new Vector3(0, speedasteroid * PlayerPrefs.GetFloat("speedCoeff"), 0f));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "laser") 
        {
            Destroy(col.gameObject);//Удаляем сам выстрел 
            PlayerPrefs.SetInt("tempScore", PlayerPrefs.GetInt("tempScore") + 1);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}