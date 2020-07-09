using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public int Value = 10;

    public float RotationRate = 1.0f;
    private Vector3 rotationAxis = new Vector3(0, 1, 0);


    public void Vanish()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        //transform.Rotate(new Vector3(0, 1, 0));
        //transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y + 1, 0));
        //transform.eulerAngles = new Vector3(0, 1, 0);
        rotationAxis += Random.onUnitSphere / 50;


        transform.Rotate(rotationAxis, RotationRate);
    }
}
