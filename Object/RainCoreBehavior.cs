using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCoreBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject rainObj, rainMObj;

    int frame = 0;

    bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (activated)
        {
            if(frame%1==0)
            {
                float ang = 0;
                for(int i = 0; i<2; i++)
                {
                    float cx = Mathf.Sin(3 * (frame * 7 + ang) * Mathf.Deg2Rad) * 17.0f + transform.position.x;
                    float cy = Mathf.Sin(4 * (frame * 7 + ang) * Mathf.Deg2Rad) * 3.0f + transform.position.y + 2.0f;

                    if (frame % 10 == 0)
                        Instantiate(rainMObj, new Vector3(cx, cy, 0), Quaternion.Euler(0, 0, -90.0f));
                    else
                        Instantiate(rainObj, new Vector3(cx, cy, 0), Quaternion.Euler(0, 0, -90.0f));

                    ang += 3.0f;
                }
            }
            frame++;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            activated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            activated = false;
        }
    }
}
