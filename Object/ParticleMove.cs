using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMove : MonoBehaviour
{
    Vector3 speed;
    int frame = 0;
    int duration = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 newPos = transform.position;
        newPos += speed;
        transform.position = newPos;

        transform.Rotate(0, 0, 15);
        frame++;

        if(frame > duration)
            Destroy(gameObject);
    }

    public void SetEffect(float spd, float ang, Vector3 pos)
    {
        transform.position = pos;
        float x_speed = Mathf.Cos(ang * Mathf.Deg2Rad) * spd;
        float y_speed = Mathf.Sin(ang * Mathf.Deg2Rad) * spd;

        speed = new Vector3(x_speed, y_speed);
    }

    public void SetEffect(float spd, float ang, Vector3 pos, int d)
    {
        SetEffect(spd, ang, pos);
        duration = d;
    }
    public void SetEffect(float spd, float ang, int d, Vector3 pos, Vector3 scale)
    {
        transform.localScale = scale;
        SetEffect(spd, ang, pos, d);
    }
}
