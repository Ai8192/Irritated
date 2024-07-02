using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour
{
    Image image;
    int flashFrame = 0;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(flashFrame>0)
        {
            flashFrame--;
        }

        if(flashFrame == 0)
        {
            Color col = image.color;
            col.a = 0;

            image.color = col;
        }
    }

    public void Flash(Color color, int frame)
    {
        image.color = color;
        flashFrame = frame;
    }
}
