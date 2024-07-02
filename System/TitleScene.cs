using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Clothes
{
    Private,
    Summer,
    Autumn,
    Spring,
    MAX
}

public class TitleScene : MonoBehaviour
{
    static Clothes selectedCloth = Clothes.Private;

    [SerializeField]
    GameObject characterObj;

    [SerializeField]
    Sprite Private, Summer, Autumn, Spring;

    [SerializeField]
    GameObject fadeObj;

    [SerializeField]
    List<AudioClip> sounds;

    Fade fade;
    SpriteRenderer sr;
    AudioSource audioSource;
    bool gameStart = false;
    int frame = 0;
    // Start is called before the first frame update
    void Start()
    {
        fade = fadeObj.GetComponent<Fade>();
        sr = characterObj.GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        ChangeClothes((int)selectedCloth);
    }

    private void Update()
    {
        ChangeClothes();
        SceneChange();
    }

    void ChangeClothes()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            audioSource.PlayOneShot(sounds[0]);
            int no = (int)selectedCloth + 1;
            no %= (int)Clothes.MAX;

            // ïûëïÇÃïœçX
            ChangeClothes(no);

            selectedCloth = (Clothes)no;
        }
    }

    void SceneChange()
    {

//        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
//        {
//#if UNITY_EDITOR
//            UnityEditor.EditorApplication.isPlaying = false;
//#else
//                Application.Quit();
//#endif
//        }


        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && !gameStart)
        {
            GameManager.difficulty = Difficulty.NORMAL;
            gameStart = true;
            audioSource.PlayOneShot(sounds[1]);
            fade.FadeIn();
        }
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && !gameStart)
        {
            GameManager.difficulty = Difficulty.HARD;
            gameStart = true;
            audioSource.PlayOneShot(sounds[1]);
            fade.FadeIn();
        }
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && !gameStart)
        {
            GameManager.difficulty = Difficulty.IRRITATE;
            gameStart = true;
            audioSource.PlayOneShot(sounds[1]);
            fade.FadeIn();
        }

        // ê‡ñæâÊñ Ç…çsÇ≠
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.difficulty = Difficulty.HELP;
            gameStart = true;
            audioSource.PlayOneShot(sounds[1]);
            fade.FadeIn();
        }

        if (gameStart)
        {
            if (fade.fadeIn == false)
            {
                switch (GameManager.difficulty)
                {
                    case Difficulty.NORMAL:
                        SceneManager.LoadScene("NormalMode");
                        break;
                    case Difficulty.HARD:
                        SceneManager.LoadScene("HardMode");
                        break;
                    case Difficulty.IRRITATE:
                        SceneManager.LoadScene("IrritateMode");
                        break;

                    case Difficulty.HELP:
                        SceneManager.LoadScene("HelpScene");
                        break;

                }
            }

        }
    }



    void ChangeClothes(int clothesNo)
    {
        switch ((Clothes)clothesNo)
        {
            case Clothes.Private:
                sr.sprite = Private;
                GameManager.SetStatusPrivate();
                break;
            case Clothes.Summer:
                sr.sprite = Summer;
                GameManager.SetStatusSummer();
                break;
            case Clothes.Autumn:
                sr.sprite = Autumn;
                GameManager.SetStatusAutumn();
                break;
            case Clothes.Spring:
                sr.sprite = Spring;
                GameManager.SetStatusSpring();
                break;
        }
    }
}
