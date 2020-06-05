using System.IO;
using UnityEngine;

public class carscr : MonoBehaviour
{
    public GameObject laser;
    public GameObject laser3x;
    public GameObject explosionplayer;
    public GameObject pause;

    float x, y, z, x1, y1;
    bool trigtime = false;
    public float speedreset = 0.25f;
    float timer;
    Vector2 startpos;
    Vector2 startcar;
    public bool gun1 = true;
    public bool gun2 = false;
    public bool gun3 = false;
    int guncount = 0;

    void Start()
    {
        timer = speedreset;
        y = laser.transform.position.y;
        z = laser.transform.position.z;
        PlayerPrefs.SetFloat("speedCoeff", 1f);
        
    }

    public void Update()
    {
        if (timer < 0)
        {
            timer = speedreset;
            trigtime = false;
        }

        if (Input.GetMouseButton(0) && !FindObjectOfType<Exit>().isPause)
        {
            PlayerPrefs.SetFloat("speedCoeff", 1f);
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0.5f, 10);
            if (timer == speedreset)
            {
                if (gun1 == true)
                {
                    Instantiate(laser, new Vector2(transform.position.x, transform.position.y + 1.1f), transform.rotation);
                    trigtime = true;
                }
                if (gun2 == true && guncount > 0)
                {
                    guncount--;
                    if (guncount == 0) 
                    {
                        gun1 = true;
                        gun2 = false;
                        gun3 = false;
                    }
                    Instantiate(laser3x, new Vector2(transform.position.x, transform.position.y + 1.1f), transform.rotation);
                    trigtime = true;
                }
                if (gun3 == true && guncount > 0) 
                {
                    guncount--;
                    if (guncount == 0) 
                    {
                        gun1 = true;
                        gun2 = false;
                        gun3 = false;
                    }
                    Instantiate(laser3x, new Vector2(transform.position.x, transform.position.y + 1.1f), transform.rotation);
                    trigtime = true;
                }
            }
            if (trigtime == true)
            {
                timer = timer - Time.deltaTime;
            }
        }
        else if(FindObjectOfType<Exit>().isPause)
        {
            PlayerPrefs.SetFloat("speedCoeff", 0f);
        }
        else
        {
            PlayerPrefs.SetFloat("speedCoeff", 0.3f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Handheld.Vibrate();

        if (col.tag == "gunbonous")
        {
            gun2 = true;
            guncount = 85;
            gun1 = false;
            gun3 = false;
            Destroy(col.gameObject);
        }
        if (col.tag == "invisibitityBonous") 
        {
            gun1 = false;
            gun2 = false;
            gun3 = true;
            guncount = 50;
            
            Destroy(col.gameObject);
        }
        if (col.tag == "coin")
        {
            PlayerPrefs.SetInt("tempScore",PlayerPrefs.GetInt("tempScore")+10);
            PlayerPrefs.SetInt("coinsCount", PlayerPrefs.GetInt("coinsCount") + 1);
            Destroy(col.gameObject);
        }
        
        if (col.gameObject.tag == "Enemy" && !gun3)
        {
            Instantiate(explosionplayer, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Enemy" && gun3)
        {
            PlayerPrefs.SetInt("tempScore", PlayerPrefs.GetInt("tempScore") + 6);
        }
    }
}