using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class rotator : MonoBehaviour
{

    int f;
    float sc;
    void Start()
    {
        f = Random.Range(-5, 5);
        sc = Random.Range(0.9f, 1.2f);
        transform.localScale = new Vector3(sc, sc, sc);
    }

    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(f, new Vector3(0, 0, 1));
    }
}
