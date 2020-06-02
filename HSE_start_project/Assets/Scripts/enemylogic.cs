using UnityEngine;

public class enemylogic : MonoBehaviour
{

    public GameObject explosionenemy;
    public GameObject laserenemy;

    public GameObject gunactivator2;
    public GameObject gunactivator3;
    public GameObject coin;
    /*public GameObject gunactivator4;
    public GameObject gunactivator5;
    public GameObject gunactivator6;*/
    //
    bool trigtime = false;
    float speedreset = 1.5f;
    float timer;
    float speedenemy = -0.2f;

    float x;

    void Start()
    {
        timer = speedreset;
    }


    void Update()
    {
        transform.Translate(new Vector3(0, speedenemy, 0f));
        if (timer < 0)
        {
            timer = speedreset;
            trigtime = false;
        }
        if (timer == speedreset)
        {
            Instantiate(laserenemy, new Vector2(transform.position.x, transform.position.y - 0.4f), transform.rotation);
            trigtime = true;
        }
        if (trigtime == true)
        {
            timer = timer - Time.deltaTime;
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
            Instantiate(explosionenemy, transform.position, transform.rotation);
        }
        if (col.tag == "laser")
        {
            PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+3);
            //x = Random.Range(0f, 100f);//Генерируется любое число от 0 до 100
            if (Random.Range(0, 5) == 0) //если число в диапазоне от 1 до 5 то создается капсула gunactivator2
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