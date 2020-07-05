using UnityEngine;
using System.Collections;

public class asteroidlogic : MonoBehaviour
{

    public GameObject explosion;
    float speedasteroid = -0.1f;


    void Update()
    {
        transform.Translate(new Vector3(0, speedasteroid * Memory.Get_Speed(), 0f));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "laser") 
        {
            Destroy(col.gameObject);//Удаляем сам выстрел 
            Memory.Set_TempScore(Memory.Get_TempScore()+1);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (col.tag == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Memory.Set_TempScore(Memory.Get_TempScore() + 1);
            Destroy(gameObject);
        }
    }
}