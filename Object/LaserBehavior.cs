using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour
{
    int frame = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(1.0f, 0, 0));

        frame++;

        if (frame > 180)
            Destroy(gameObject);
    }

    public void SetStatus(float ang)
    {
        transform.eulerAngles = new Vector3(0, 0, ang);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall") || collision.CompareTag("Thorn"))
        {
            Destroy(gameObject);
        }
    }
}
