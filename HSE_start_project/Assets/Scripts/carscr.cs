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
        Memory.Set_Speed(1f);
        
    }

    public void Update()
    {
        Gun_Reseter();
        if (Input.GetMouseButton(0) && !FindObjectOfType<Exit>().isPause)
        {
            Memory.Set_Speed(1f);
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
            Memory.Set_Speed(0f);
        }
        else
        {
            Memory.Set_Speed(0.3f);
        }
    }
    private void Gun_Reseter()
    {
        if (timer < 0)
        {
            timer = speedreset;
            trigtime = false;
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
            Memory.Set_TempScore(Memory.Get_TempScore() + 10);
            Memory.Set_Coin(Memory.Get_Coin() + 1);
            Destroy(col.gameObject);
        }
        
        if (col.gameObject.tag == "Enemy" && !gun3)
        {
            Instantiate(explosionplayer, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}