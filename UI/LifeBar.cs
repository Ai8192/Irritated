using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField]
    Sprite NormalColor, HardColor, IrritateColor;

    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();

        // ìÔà’ìxÇ…ÇÊÇ¡ÇƒêFÇïœÇ¶ÇÈ
        switch(GameManager.difficulty)
        {
            case Difficulty.NORMAL:
                image.sprite = NormalColor;
                break;
            case Difficulty.HARD:
                image.sprite = HardColor;
                break;
            case Difficulty.IRRITATE:
                image.sprite = IrritateColor;
                break;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float amount = GameManager.playerHealth;
        amount /= GameManager.playerHealthMax;

        image.fillAmount = amount;
    }
}
