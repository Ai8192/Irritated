using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    [SerializeField]
    GameObject fireBall;

    [SerializeField] int fireBallNum = 4;
    [SerializeField] float range = 1;
    [SerializeField] float roleSpeed = 1;
    [SerializeField] float startAngle = 0;

    // Start is called before the first frame update
    void Start()
    {
        int ballcount = 0;
        float i = 0;
        while(ballcount < fireBallNum)
        {
            GameObject obj = Instantiate(fireBall);
            FireBallBehavior fireScript = obj.GetComponent<FireBallBehavior>();
            fireScript.SetStatus(transform.position, range, i + startAngle, roleSpeed);
            i += 360 / fireBallNum;
            ballcount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
