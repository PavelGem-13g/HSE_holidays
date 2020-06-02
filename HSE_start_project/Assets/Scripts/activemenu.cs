using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activemenu : MonoBehaviour
{
    float speed = -0.01f;
    void Update()
    {
        transform.Translate(new Vector3(0f, speed, 0f));
        if (transform.position.y < -10f)
        {
            transform.position = new Vector3(0f, 10f, 0f);
        }
    }
}
