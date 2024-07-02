using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScene : MonoBehaviour
{
    [SerializeField]
    GameObject fadeObj;

    // Start is called before the first frame update
    void Start()
    {
        fadeObj.GetComponent<Fade>().FadeOut();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
