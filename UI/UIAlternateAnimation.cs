using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAlternateAnimation : MonoBehaviour
{
    [SerializeField]
    List<Sprite> sprites = new List<Sprite>();

    [SerializeField]
    int cycleFrame = 15;

    int frame = 0;
    int spriteNo = 0;

    Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (frame % cycleFrame == 0)
        {
            // 画像の差し替え
            img.sprite = sprites[spriteNo];

            // 画像数でループするように添え字を増やす
            spriteNo++;
            spriteNo = spriteNo % sprites.Count;
        }

        frame++;
    }
}
