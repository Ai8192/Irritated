using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDiamondRendering : MonoBehaviour
{
    [SerializeField]
    List<Sprite> sprites = new List<Sprite>();
    [SerializeField]
    List<Sprite> redSprites = new List<Sprite>();

    [SerializeField]
    int cycleFrame = 15;

    int frame = 0;
    int spriteNo = 0;

    Image img;

    bool red = false;

    // trueの時、ダイヤの色が赤にならなくなる。
    [SerializeField]
    bool forceDiamondColorBlue = false;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();

        if (GameManager.difficulty == Difficulty.IRRITATE && !forceDiamondColorBlue)
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
                img.sprite = redSprites[spriteNo];
            }
            else
            {
                // 画像数でループするように添え字を増やす
                spriteNo++;
                spriteNo = spriteNo % sprites.Count;

                // 画像の差し替え
                img.sprite = sprites[spriteNo];
            }
        }

        frame++;
    }
}
