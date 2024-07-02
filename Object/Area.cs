using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    [SerializeField]
    string AreaName = "Area-1";

    static CameraMove mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        if (mainCamera == null)
            mainCamera = GameObject.Find("Main Camera").GetComponent<CameraMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            mainCamera.MoveArea(transform.position);
            GameManager.AreaName = AreaName;
        }
    }
}
