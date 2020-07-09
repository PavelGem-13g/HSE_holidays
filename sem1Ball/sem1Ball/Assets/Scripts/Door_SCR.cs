using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_SCR : MonoBehaviour
{
    public float step = 2f;
    /*public float upperLevel = 10f;*/

    public void OpenDoor(int high)
    {
        StartCoroutine(OpenAnimation(high));
    }

    IEnumerator OpenAnimation(int high)
    {
        while (transform.position.y < high)
        {
            transform.position += new Vector3(0, step*Time.deltaTime);
            yield return null;
        }
    }
}
