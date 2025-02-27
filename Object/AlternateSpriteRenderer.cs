using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class AlternateSpriteRenderer : MonoBehaviour
{
    [SerializeField]
    List<Sprite> sprites = new List<Sprite>();

    [SerializeField]
    int cycleFrame = 15;

    int frame = 0;
    int spriteNo = 0;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (frame % cycleFrame == 0)
        {
            // 画像の差し替え
            sr.sprite = sprites[spriteNo];

            // 画像数でループするように添え字を増やす
            spriteNo++;
            spriteNo = spriteNo % sprites.Count;
        }
        frame++;
    }
}
