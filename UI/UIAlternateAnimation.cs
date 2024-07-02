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
            // �摜�̍����ւ�
            img.sprite = sprites[spriteNo];

            // �摜���Ń��[�v����悤�ɓY�����𑝂₷
            spriteNo++;
            spriteNo = spriteNo % sprites.Count;
        }

        frame++;
    }
}
