using System.IO;
using UnityEngine;

public class carscr : MonoBehaviour
{
    public GameObject laser;
    public GameObject laser3x;
/*    public GameObject laserhor;
    public GameObject laser3xhor;
    public GameObject sphere;
    public GameObject sphere3x;*/
    public GameObject explosionplayer;
    

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
        
    }

    public void Update()
    {
        if (timer < 0)
        {
            timer = speedreset;
            trigtime = false;
        }

        if (Input.GetMouseButton(0))
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0.5f, 10);

            if (timer == speedreset)//проверка истечения времени(время перезарядки) 
            {
                if (gun1 == true)//проверка базового орудия 
                {
                    Instantiate(laser, new Vector2(transform.position.x, transform.position.y + 1.1f), transform.rotation);//Генерация выстрелов из префаба laser в месте текущей позиции игрока(с некоторыми поправками)
                    trigtime = true;
                }
                if (gun2 == true && guncount > 0)//В случае активации 2-го орудия выстрелы будут генерироваться по данному коду 
                {
                    guncount--;//Снижение числа боеприпасов
                    if (guncount == 0) //В случае если боеприпасы закончатся то активируем 1 орудие а остальные блокируем
                    {
                        gun1 = true;
                        gun2 = false;
                        gun3 = false;
/*                        gun4 = false;
                        gun5 = false;
                        gun6 = false;*/
                    }
                    Instantiate(laser3x, new Vector2(transform.position.x, transform.position.y + 1.1f), transform.rotation);//Генерация выстрелов из префаба laser3x
                    trigtime = true;
                }
                if (gun3 == true && guncount > 0)//В случае активации 2-го орудия выстрелы будут генерироваться по данному коду 
                {
                    guncount--;//Снижение числа боеприпасов
                    if (guncount == 0) //В случае если боеприпасы закончатся то активируем 1 орудие а остальные блокируем
                    {
                        gun1 = true;
                        gun2 = false;
                        gun3 = false;
                       
                    }
                    Instantiate(laser3x, new Vector2(transform.position.x, transform.position.y + 1.1f), transform.rotation);//Генерация выстрелов из префаба laser3x
                    trigtime = true;
                }
            }
            if (trigtime == true)
            {
                timer = timer - Time.deltaTime;//Отсчет времени для перезарядки
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Handheld.Vibrate();

        if (col.tag == "gunbonous")//проверка на пересечение с "капсулой" для gunactivator2 
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
        if (col.tag == "coin")//проверка на пересечение с "капсулой" для gunactivator2 
        {
            PlayerPrefs.SetInt("tempScore",PlayerPrefs.GetInt("tempScore")+10);
            Destroy(col.gameObject);
        }
        //Если столкновение с "капсулами" не произошло то это значит что игрок столкнулся с лазером противника, метеоритом или с вражеским звездолетом. Значит нужно удалить игрока со сцены
        //активация вибрации(для смартфонов)
        /*        if (GameObject.Find("Main Camera").GetComponent<blockgenerator>().score > GameObject.Find("Main Camera").GetComponent<blockgenerator>().data)//Если число сбитых метеоритов в текущей игровой сессии выше чем в файле с игровым рекордом, то делаем запись нового рекорда в файл
                {
                    StreamWriter scoredata = new StreamWriter(Application.persistentDataPath + "/score1.gd");
                    scoredata.WriteLine(GameObject.Find("Main Camera").GetComponent<blockgenerator>().score);
                    scoredata.Close();
                }*/
        if (col.gameObject.tag == "Enemy" && !gun3)
        {
            Instantiate(explosionplayer, transform.position, transform.rotation);//Генерация взрыва звездолета игрока
            Destroy(col.gameObject);//Удаление объекта с которым произошло пересечение
            Destroy(gameObject);
        }
    }
}