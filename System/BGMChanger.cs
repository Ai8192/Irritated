using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BGMChanger : MonoBehaviour
{
    [SerializeField]
    AudioClip newBgm;

    AudioSource ads;

    bool stopBGM = false;
    bool finishedStopBGM = false;
    bool startBGM = false;
    int frame = 0;
    // Start is called before the first frame update
    void Start()
    {
        ads = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(stopBGM && ads.volume > 0 && !finishedStopBGM)
        {
            ads.volume -= 0.01f;
            ads.volume = Mathf.Max(0, ads.volume);
            if(ads.volume <= 0 )
            {
                finishedStopBGM = true;
            }
        }

        if(startBGM && ads.volume < 1) 
        {
            ads.volume += 0.005f;
            ads.volume = Mathf.Min(1, ads.volume);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (stopBGM)
            return;

        if(collision.CompareTag("Player"))
        {
            stopBGM = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (startBGM)
            return;

        if (collision.CompareTag("Player"))
        {
            ads.Stop();
            startBGM = true;
            ads.clip = newBgm;
            ads.Play();
        }
    }
}
