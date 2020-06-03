using UnityEngine;

public class enemylogic : MonoBehaviour
{

    public GameObject explosionenemy;
    public GameObject laserenemy;

    public GameObject gunactivator2;
    public GameObject gunactivator3;
    public GameObject coin;

    float speedreset = 1.5f;
    float timer;
    float speedenemy = -0.2f;

    void Start()
    {
        timer = 0.15f;
    }


    void Update()
    {
        transform.Translate(new Vector3(0, speedenemy * PlayerPrefs.GetFloat("speedCoeff"), 0f));

        timer = timer - Time.deltaTime * PlayerPrefs.GetFloat("speedCoeff");
        if (timer <= 0)
        {
            Instantiate(laserenemy, new Vector3(transform.position.x, transform.position.y - 0.4f), transform.rotation);
            timer = speedreset;
        }
        if (transform.position.y <= -6)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            PlayerPrefs.SetInt("tempScore", PlayerPrefs.GetInt("tempScore") + 5);
            Instantiate(explosionenemy, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (col.tag == "laser")
        {
            PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+3);
            if (Random.Range(0, 5) == 0)
            {
                Instantiate(gunactivator2, transform.position, transform.rotation);
            }
            else if (Random.Range(0, 5) == 0)
            {
                Instantiate(gunactivator3, transform.position, transform.rotation);
            }
            else if (Random.Range(0, 5) == 0)
            {
                Instantiate(coin, transform.position, transform.rotation);
            }
            Instantiate(explosionenemy, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}