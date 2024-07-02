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
            // ‰æ‘œ‚Ì·‚µ‘Ö‚¦
            sr.sprite = sprites[spriteNo];

            // ‰æ‘œ”‚Åƒ‹[ƒv‚·‚é‚æ‚¤‚É“Y‚¦š‚ğ‘‚â‚·
            spriteNo++;
            spriteNo = spriteNo % sprites.Count;
        }
        frame++;
    }
}
