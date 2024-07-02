//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor.XR;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Difficulty
{
    NORMAL,
    HARD,
    IRRITATE,
    HELP
}

public class GameManager : MonoBehaviour
{
    public static Clothes clothType;
    // ��������
    static bool SuperInvincibility   = false;     // ���G���ԂQ�{�B�����̌���
    static bool FastRunning          = false;     // �ړ����x�㏸�B�ĕ��̌���
    static bool AdditionalHealing    = false;     // �_�C�������h�񕜗ʒǉ��B�H���̌���
    static bool HeavyDamageResist    = false;     // �_���[�W����ݒ�B�t���̌���

    [SerializeField]
    GameObject fadeObj;

    Fade fade;
    public static Difficulty difficulty = Difficulty.IRRITATE;

    public static int playerHealth;
    public static int playerHealthMax = 100;
    public static int diamond;
    public static int redDiamond;

    public static float elapsedTime;
    public static bool stopCounter;

    public static string AreaName;



    int frame = 0;
    bool startEnd = false;

    float startTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        fade = fadeObj.GetComponent<Fade>();

        playerHealthMax = 100;

        playerHealth = playerHealthMax;
        diamond = 0;
        redDiamond = 0;

        startTime = Time.time;
        stopCounter = false;

        AreaName = "Area-1";

        fade.FadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopCounter)
            elapsedTime = Time.time - startTime;
    }

    private void FixedUpdate()
    {
        if(playerHealth <= 0 && !startEnd)
        {
            startEnd = true;
            stopCounter = true;
        }

        if (startEnd && frame == 60)
            fade.FadeIn();

        if (startEnd)
        {
            if (frame > 180)
                SceneManager.LoadScene("Title");

            frame++;
        }

    }

    public static bool HasSuperInvincibility()
    {
        return SuperInvincibility;
    }
    public static bool HasFastRunning()
    {
        return FastRunning;
    }
    public static bool HasDamageResistance()
    {
        return HeavyDamageResist;
    }

    public static void SetStatusPrivate()
    {
        clothType = Clothes.Private;
        SuperInvincibility = true;
        FastRunning = false;
        AdditionalHealing = false;
        HeavyDamageResist = false;
    }
    public static void SetStatusSummer()
    {
        clothType = Clothes.Summer;
        SuperInvincibility = false;
        FastRunning = true;
        AdditionalHealing = false;
        HeavyDamageResist = false;
    }
    public static void SetStatusAutumn()
    {
        clothType = Clothes.Autumn;
        SuperInvincibility = false;
        FastRunning = false;
        AdditionalHealing = true;
        HeavyDamageResist = false;
    }
    public static void SetStatusSpring()
    {
        clothType = Clothes.Spring;
        SuperInvincibility = false;
        FastRunning = false;
        AdditionalHealing = false;
        HeavyDamageResist = true;
    }

    public static void HealPlayerLife(int baseValue)
    {
        int healValue = baseValue;
        switch (difficulty)
        {
            case Difficulty.NORMAL:
                healValue = baseValue * 2;
                break;
            case Difficulty.HARD:
                healValue = baseValue;
                break;
            // �񕜂Ȃ�
            case Difficulty.IRRITATE:
                healValue = 0;
                break;
        }

        // �H���Ȃ�񕜗�+5
        if (AdditionalHealing)
            healValue += 5;

        playerHealth += healValue;
        playerHealth = Mathf.Min(playerHealth, playerHealthMax);
    }

}