using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDoor : MonoBehaviour
{
    //public float step;
    Vector3 rotation;
    public void OpenDoor(float step)
    {
        StartCoroutine(DoorAnim(step));
    }
    IEnumerator DoorAnim(float step)
    {
        while (true)
        {
            transform.Rotate(new Vector3(0, 0, step*Time.deltaTime));
            yield return null;
        }
    }
}
