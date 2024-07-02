using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColorChanger : MonoBehaviour
{
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        switch (GameManager.difficulty)
        {
            case Difficulty.NORMAL:
                text.color = Color.green;
                break;
            case Difficulty.HARD:
                text.color = Color.blue;
                break;
            case Difficulty.IRRITATE:
                text.color = Color.red;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
