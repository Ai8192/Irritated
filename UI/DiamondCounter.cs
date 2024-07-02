using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondCounter : MonoBehaviour
{
    [SerializeField]
    bool countDiamond = true;

    Text text;
    public static int amount_of_diamond { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        if (countDiamond)
            amount_of_diamond = GameObject.FindGameObjectsWithTag("Diamond").Length;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        text.text = GameManager.diamond + "/" + amount_of_diamond;
    }
}
