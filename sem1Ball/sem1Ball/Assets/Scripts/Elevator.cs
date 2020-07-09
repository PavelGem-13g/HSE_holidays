using System.Collections;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    AudioSource music;
    public bool isUp = false;
    public bool isOn = false;
    public bool isEnd = false;
    public float max = 1.5f;
    public float min = 0f;

    private void Start()
    {
        ElevatorMoveing(1f);
    }

    public void ElevatorMoveing(float speed)
    {
        StartCoroutine(ElevatorAnim(speed));
    }
    public void TurnOn()
    {
        isOn = true;
    }

    IEnumerator ElevatorAnim(float speed)
    {
        while (true)
        {
            if (isUp && isOn) moveUp(speed);
            else moveDown(speed);
            yield return null;
        }
    }
    void moveUp(float speed)
    {
        if (transform.localPosition.y <= max)
            transform.localPosition += new Vector3(0, speed * Time.deltaTime);
        if (transform.localPosition.y >= max && isEnd)
        {
            FindObjectOfType<Restart>().Load();
        }
    }
    void moveDown(float speed)
    {
        if (transform.localPosition.y >= min)
            transform.localPosition -= new Vector3(0, speed * Time.deltaTime);
    }

}
