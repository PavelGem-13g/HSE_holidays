using System.Collections;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    AudioSource music;
    public bool isUp;
    private void Start()
    {
        ElevatorMoveing(0.5f);
    }
    public void ElevatorMoveing(float speed)
    {
        StartCoroutine(ElevatorAnim(speed));
    }

    IEnumerator ElevatorAnim(float speed)
    {
        while (true)
        {
            if (transform.position.y <= 0.96)
            {
                transform.position += new Vector3(0, speed * Time.deltaTime);
                Debug.Log("Up");
            }
            if (transform.position.y >= 0.97)
            {
                transform.position -= new Vector3(0, speed * Time.deltaTime);
                Debug.Log("Down");
            }
            //transform.position += new Vector3(0, speed * Time.deltaTime);
            Debug.Log("End");
            yield return null;
        }
        yield return null;
/*        while (!isUp)
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime);
            yield return null;
        }
        //yield return null;*/

    }
}
