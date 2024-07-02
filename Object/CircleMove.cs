using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour
{
    [SerializeField] bool invalidHorizontalMove = false;
    [SerializeField] bool invalidVerticalMove = false;
    [SerializeField] int r = 3;
    [SerializeField] float moveSpeed = 0.1f;

    Vector3 center;
    int frame = 0;

    // Start is called before the first frame update
    void Start()
    {
        center = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x_pos = Mathf.Cos(frame * moveSpeed * Mathf.Deg2Rad) * r + center.x;
        float y_pos = Mathf.Sin(frame * moveSpeed * Mathf.Deg2Rad) * r + center.y;

        if (invalidHorizontalMove)
            x_pos = center.x;
        if (invalidVerticalMove)
            y_pos = center.y;

        Vector3 newPos = new Vector3(x_pos, y_pos, transform.position.z);

        transform.position = newPos;

        frame++;
    }
}
