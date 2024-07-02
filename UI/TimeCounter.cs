using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int min = (int)GameManager.elapsedTime / 60;
        int sec = (int)GameManager.elapsedTime % 60;
        float others = GameManager.elapsedTime % 1 * 100;
        int num = (int)others;

        text.text = min + ":" + sec.ToString("D2") + "." + num.ToString("D2");
    }
}
