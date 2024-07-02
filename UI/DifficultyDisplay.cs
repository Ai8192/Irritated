using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyDisplay : MonoBehaviour
{
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        switch(GameManager.difficulty)
        {
            case Difficulty.NORMAL:
                text.text = "NORMAL";
                text.color = Color.green;
                text.fontSize = 18;
                break;
            case Difficulty.HARD:
                text.text = "HARD";
                text.color = Color.blue;
                text.fontSize = 24;
                break;
            case Difficulty.IRRITATE:
                text.text = "IRRITATE";
                text.color = Color.red;
                text.fontSize = 18;
                break;
        }
    }
}
