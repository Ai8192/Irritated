using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public bool fadeIn { get; private set; }
    public bool fadeOut { get; private set; }

    Image img;
    int frame = 0;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fadeIn)
        {
            float alpha = frame / 30.0f;

            Color color = Color.black;
            color.a = alpha;

            img.color = color;

            if (alpha > 1.5f)
                fadeIn = false;

            frame++;
        }

        if (fadeOut)
        {
            float alpha = frame / 30.0f;

            Color color = Color.black;
            color.a = 1.5f - alpha;

            img.color = color;

            if (color.a < 0)
                fadeOut = false;

            frame++;
        }

    }

    public void FadeIn()
    {
        frame = 0;
        fadeIn = true;
    }

    public void FadeOut()
    {
        frame = 0;
        fadeOut = true;
    }
}
