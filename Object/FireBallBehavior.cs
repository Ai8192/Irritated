using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBehavior : MonoBehaviour
{

    Vector3 centerPos;
    float range = 0;
    float startAngle = 0;
    float speed = 0;

    int frame = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetStatus(Vector3 center, float r, float sAng, float roleSpeed)
    {
        centerPos = center;
        range = r;
        startAngle = sAng;
        speed = roleSpeed;
    }

    private void FixedUpdate()
    {
        float angle = (startAngle + frame * speed) * Mathf.Deg2Rad;

        float x_pos = Mathf.Cos(angle) * range + centerPos.x;
        float y_pos = Mathf.Sin(angle) * range + centerPos.y;

        transform.position = new Vector3(x_pos, y_pos, centerPos.z);

        frame++;
    }
}
