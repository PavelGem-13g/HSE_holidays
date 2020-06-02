using UnityEngine;

public class laser : MonoBehaviour
{
    public float speedlaser;


    void Update()
    {
        transform.Translate(new Vector3(0, speedlaser, 0f));
        if (!(-6 <= transform.position.y && transform.position.y <= 6))
        {
            Destroy(gameObject);
        }
    }

}