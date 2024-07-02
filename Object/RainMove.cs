using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RainMove : MonoBehaviour
{
    [SerializeField]
    bool RoleAnim = false;
    float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (speed < 0.7f)
            speed += 0.001f;

        if (RoleAnim)
            transform.Rotate(0, 0, 5.0f);


        Vector3 pos = transform.position;
        pos.y -= speed;
        transform.position = pos;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
