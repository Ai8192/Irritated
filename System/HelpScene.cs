using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpScene : MonoBehaviour
{
    public List<GameObject> Pages;

    int page = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PageChange();
        SceneChange();
    }

    void PageChange()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            page++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            page--;
        }

        page = Mathf.Clamp(page, 0, Pages.Count - 1);

        foreach (GameObject p in Pages)
        {
            p.SetActive(false);
        }

        Pages[page].SetActive(true);
    }

    void SceneChange()
    {

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
