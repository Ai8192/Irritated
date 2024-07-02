using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillBox : MonoBehaviour
{
    [SerializeField] Sprite silentMode;
    [SerializeField] Sprite readyMode;
    [SerializeField] List<Sprite> sprites;

    [SerializeField] int addFrame = 0;

    SpriteRenderer sr;
    BoxCollider2D bc2d;
    int frame = 0;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bc2d = GetComponent<BoxCollider2D>();

        frame = addFrame;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (frame % 180 == 0)
        {
            bc2d.enabled = false;
            sr.sprite = silentMode;
        }
        if (frame % 180 == 60)
        {
            sr.sprite = readyMode;
        }

        if (frame % 180 == 120)
            bc2d.enabled = true;

        if (frame % 180 >= 120)
        {
            int spriteNo = frame%sprites.Count;
            sr.sprite = sprites[spriteNo];
        }


        frame++;
    }
}
