using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    [SerializeField]
    GameObject fadeObj;

    Fade fade;

    bool startEnding = false;


    float sec = 0;
    // Start is called before the first frame update
    void Start()
    {
        fade = fadeObj.GetComponent<Fade>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startEnding)
        {
            sec += Time.unscaledDeltaTime;

            if(sec > 2.0f)
            {
                SceneManager.LoadScene("Result");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            fade.FadeIn();
            startEnding = true;
            GameManager.stopCounter = true;
        }
    }
}
