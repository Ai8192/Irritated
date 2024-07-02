using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainOrbBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject rainObj;

    [SerializeField]
    int addFrame = 0;

    [SerializeField]
    int interval = 60;

    int frame = 0;

    // Start is called before the first frame update
    void Start()
    {
        frame = addFrame;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (frame % interval == 0)
            Instantiate(rainObj, transform.position + new Vector3(0, -0.5f), Quaternion.Euler(0, 0, -90.0f));

        frame++;
    }
}
