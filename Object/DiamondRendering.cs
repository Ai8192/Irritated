using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondRendering : MonoBehaviour
{
    [SerializeField]
    List<Sprite> sprites = new List<Sprite>();
    [SerializeField]
    List<Sprite> redSprites = new List<Sprite>();

    [SerializeField]
    int cycleFrame = 15;

    int frame = 0;
    int spriteNo = 0;

    SpriteRenderer sr;

    bool red = false;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (GameManager.difficulty == Difficulty.IRRITATE)
            red = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {   

        if (frame % cycleFrame == 0)
        {
            if (red)
            {
                // 画像数でループするように添え字を増やす
                spriteNo++;
                spriteNo = spriteNo % redSprites.Count;

                // 画像の差し替え
                sr.sprite = redSprites[spriteNo];
            } 
            else
            {
                // 画像数でループするように添え字を増やす
                spriteNo++;
                spriteNo = spriteNo % sprites.Count;

                // 画像の差し替え
                sr.sprite = sprites[spriteNo];
            }
        }

        frame++;
    }
}
