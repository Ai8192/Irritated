using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGate : MonoBehaviour
{
    static Transform player;

    [SerializeField]
    GameObject laserLine, laser;

    [SerializeField]
    int addframe = 0;

    [SerializeField]
    float laserAngle = 0;

    [SerializeField]
    float laserRoleSpeed = 0;

    [SerializeField]
    int laserCycle = 180;

    [SerializeField]
    bool endless = false;

    int frame = 0;
    // Start is called before the first frame update
    void Start()
    {
        frame += addframe;
        player = GameObject.Find("Player").transform;
    }

    private void FixedUpdate()
    {
        GenerateLaser();
    }

    void GenerateLaser()
    {
        //float roleSpeed = (float)frame % 180 / 6;
        float roleSpeed = 25;
        transform.Rotate(0, 0, roleSpeed);

        Vector3 correct = transform.position;
        correct.x += Mathf.Cos(laserAngle * Mathf.Deg2Rad) * 0.5f;
        correct.y += Mathf.Sin(laserAngle * Mathf.Deg2Rad) * 0.5f;

        if(CheckDistance())
        {
            int cycleFrame = frame % laserCycle;
            int startNotice = laserCycle / 3;
            int startLaser = laserCycle - startNotice;
            // レーザー予告線
            if (startNotice <= cycleFrame && cycleFrame < startLaser)
            {
                GameObject obj = Instantiate(laserLine, correct, Quaternion.identity);
                obj.GetComponent<LaserBehavior>().SetStatus(laserAngle);
            }
            // レーザー
            if (startLaser <= cycleFrame || endless)
            {
                GameObject obj = Instantiate(laser, correct, Quaternion.identity);
                obj.GetComponent<LaserBehavior>().SetStatus(laserAngle);
            }
        }

        laserAngle += laserRoleSpeed;

        frame++;
    }

    bool CheckDistance()
    {
        float x_distance = Mathf.Abs(player.position.x - transform.position.x);
        if (x_distance < 28)
        {
            float y_distance = Mathf.Abs(player.position.y - transform.position.y);
            if (y_distance < 20)
            {
                return true;
            }
        }

        return false;
    }
}
