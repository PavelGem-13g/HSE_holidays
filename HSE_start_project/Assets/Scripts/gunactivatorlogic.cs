using UnityEngine;
using System.Collections;

public class gunactivatorlogic : MonoBehaviour
{
    float speed = -0.025f;
    void Update()
    {
        transform.Translate(new Vector3(0, speed, 0f));
        if (!(-6 <= transform.position.y && transform.position.y <= 6))
        {
            Destroy(gameObject);
        }
    }
}