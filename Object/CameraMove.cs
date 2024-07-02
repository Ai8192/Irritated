using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    int moveFrame = 0;
    Vector3 moveVec;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // ƒJƒƒ‰‚ÌƒGƒŠƒAˆÚ“®ˆ—
        if (moveFrame > 0)
        {
            transform.position = moveVec + transform.position;
            moveFrame--;
        }
        
        
        // ‰æ–Ê—h‚ê
        float correctAngle = transform.rotation.eulerAngles.z;
        if (correctAngle > 0)
        {
            if(Mathf.Abs(correctAngle) < 1.1f)
            {
                transform.eulerAngles = Vector3.zero;
            } else
            {
                correctAngle /= 2.0f;
                transform.Rotate(new Vector3(0, 0, -correctAngle));
            }
        }


    }

    public void MoveArea(Vector3 nextPos)
    {
        moveFrame = 15;
        moveVec = nextPos - transform.position;
        moveVec /= moveFrame;
        moveVec.z = 0;
    }

    public void ShakeCamera()
    {
        ShakeCamera(4);
    }
    public void ShakeCamera(float angle)
    {
        Vector3 newEuler = new Vector3(0, 0, angle);
        transform.eulerAngles = newEuler;
    }
}
