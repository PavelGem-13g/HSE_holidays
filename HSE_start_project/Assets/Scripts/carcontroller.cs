using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class carconroller : MonoBehaviour
{
    public GameObject laser;
    public GameObject laser3x;
    public GameObject laserhor;
    public GameObject laser3xhor;
    public GameObject sphere;
    public GameObject sphere3x;
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
    public bool gun4 = false;
    public bool gun5 = false;
    public bool gun6 = false;
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
                        gun4 = false;
                        gun5 = false;
                        gun6 = false;
                    }
                    Instantiate(laser3x, new Vector2(transform.position.x, transform.position.y + 1.1f), transform.rotation);//Генерация выстрелов из префаба laser3x
                    trigtime = true;
                }
                //Ниже для остальных видов "вооружения" все происходит аналогично
                if (gun3 == true && guncount > 0)
                {
                    guncount--;
                    if (guncount == 0)
                    {
                        gun1 = true;
                        gun2 = false;
                        gun3 = false;
                        gun4 = false;
                        gun5 = false;
                        gun6 = false;
                    }
                    Instantiate(laserhor, new Vector2(transform.position.x, transform.position.y + 1.1f), transform.rotation);
                    trigtime = true;
                }
                if (gun4 == true && guncount > 0)
                {
                    guncount--;
                    if (guncount == 0)
                    {
                        gun1 = true;
                        gun2 = false;
                        gun3 = false;
                        gun4 = false;
                        gun5 = false;
                        gun6 = false;
                    }
                    Instantiate(laser3xhor, new Vector2(transform.position.x, transform.position.y + 2f), transform.rotation);
                    trigtime = true;
                }
                if (gun5 == true && guncount > 0)
                {
                    guncount--;
                    if (guncount == 0)
                    {
                        gun1 = true;
                        gun2 = false;
                        gun3 = false;
                        gun4 = false;
                        gun5 = false;
                        gun6 = false;
                    }
                    Instantiate(sphere, new Vector2(transform.position.x, transform.position.y + 1.1f), transform.rotation);
                    trigtime = true;
                }
                if (gun6 == true && guncount > 0)
                {
                    guncount--;
                    if (guncount == 0)
                    {
                        gun1 = true;
                        gun2 = false;
                        gun3 = false;
                        gun4 = false;
                        gun5 = false;
                        gun6 = false;
                    }
                    Instantiate(sphere3x, new Vector2(transform.position.x, transform.position.y + 2f), transform.rotation);
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
        if (col.tag == "systemcontrol")
        {
            return;//Возврат необходим чтобы избежать конфликта с объектом controlcountobject
        }
        if (col.tag == "gunactivator2")//проверка на пересечение с "капсулой" для gunactivator2 
        {
            gun2 = true;//активация второго орудия
            guncount = 85;//установка количества боеприпасов
            gun1 = false;//отключение остальных "орудий"
            gun3 = false;
            gun4 = false;
            gun5 = false;
            gun6 = false;
            Destroy(col.gameObject);//уничтожение "капсулы" с которой произошло пересечение 
            return;
        }
        //Ниже все аналогично
        if (col.tag == "gunactivator3")
        {
            gun3 = true; guncount = 50;
            gun1 = false;
            gun2 = false;
            gun4 = false;
            gun5 = false;
            gun6 = false;
            Destroy(col.gameObject);
            return;
        }
        if (col.tag == "gunactivator4")
        {
            gun4 = true; guncount = 15;
            gun1 = false;
            gun3 = false;
            gun2 = false;
            gun5 = false;
            gun6 = false;
            Destroy(col.gameObject);
            return;
        }
        if (col.tag == "gunactivator5")
        {
            gun5 = true; guncount = 100;
            gun1 = false;
            gun3 = false;
            gun4 = false;
            gun2 = false;
            gun6 = false;
            Destroy(col.gameObject);
            return;
        }
        if (col.tag == "gunactivator6")
        {
            gun6 = true; guncount = 50;
            gun1 = false;
            gun3 = false;
            gun4 = false;
            gun5 = false;
            gun2 = false;
            Destroy(col.gameObject);
            return;
        }
        //Если столкновение с "капсулами" не произошло то это значит что игрок столкнулся с лазером противника, метеоритом или с вражеским звездолетом. Значит нужно удалить игрока со сцены
        Handheld.Vibrate();//активация вибрации(для смартфонов)
/*        if (GameObject.Find("Main Camera").GetComponent<blockgenerator>().score > GameObject.Find("Main Camera").GetComponent<blockgenerator>().data)//Если число сбитых метеоритов в текущей игровой сессии выше чем в файле с игровым рекордом, то делаем запись нового рекорда в файл
        {
            StreamWriter scoredata = new StreamWriter(Application.persistentDataPath + "/score1.gd");
            scoredata.WriteLine(GameObject.Find("Main Camera").GetComponent<blockgenerator>().score);
            scoredata.Close();
        }*/
        Instantiate(explosionplayer, transform.position, transform.rotation);//Генерация взрыва звездолета игрока
        Destroy(col.gameObject);//Удаление объекта с которым произошло пересечение
        Destroy(this.gameObject);//Удаление игрока с игровой сцены
    }
}