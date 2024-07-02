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
    // 服装効果
    static bool SuperInvincibility   = false;     // 無敵時間２倍。私服の効果
    static bool FastRunning          = false;     // 移動速度上昇。夏服の効果
    static bool AdditionalHealing    = false;     // ダイヤモンド回復量追加。秋服の効果
    static bool HeavyDamageResist    = false;     // ダメージ上限設定。春服の効果

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
            // 回復なし
            case Difficulty.IRRITATE:
                healValue = 0;
                break;
        }

        // 秋服なら回復量+5
        if (AdditionalHealing)
            healValue += 5;

        playerHealth += healValue;
        playerHealth = Mathf.Min(playerHealth, playerHealthMax);
    }

}