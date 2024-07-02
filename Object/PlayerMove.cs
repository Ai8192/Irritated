using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum sound
{
    GetDiamond,
    Explode,
    HitThorn,
    BurnedByLaser,
    HitRain,
    Plasma,
    Elixir
}

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    AlternateSpriteRenderer Private, Summer, Autumn, Spring;

    CameraMove mainCamera;
    ScreenFlash screenFlash;

    [SerializeField]
    GameObject particle;

    [SerializeField]
    List<AudioClip> clips = new List<AudioClip>();

    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;
    int invincibleTime = 0;

    bool exploded = false;

    int hitstop = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        mainCamera = GameObject.Find("Main Camera").GetComponent<CameraMove>();
        screenFlash = GameObject.Find("FlashScreen").GetComponent<ScreenFlash>();

        Private.enabled = false;
        Summer.enabled = false;
        Autumn.enabled = false;
        Spring.enabled = false;
        switch (GameManager.clothType)
        {
            case Clothes.Private:
                Private.enabled = true;
                break;
            case Clothes.Summer:
                Summer.enabled = true;
                break;
            case Clothes.Autumn:
                Autumn.enabled = true;
                break;
            case Clothes.Spring:
                Spring.enabled = true;
                break;
        }
    }

    private void FixedUpdate()
    {
        if (!exploded)
        {
            Move();
            Invincible();
            Explosion();
        }
    }

    // 移動処理
    private void Move()
    {
        float horizontalMove = 0;
        float verticalMove = 0;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            verticalMove += 1.0f;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            verticalMove -= 1.0f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            horizontalMove -= 1.0f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            horizontalMove += 1.0f;

        // 夏服なら移動速度上昇
        float movespeed = GameManager.HasFastRunning() ? 0.12f: 0.1f;

        Vector2 movePos = transform.position + new Vector3(horizontalMove, verticalMove) * movespeed;

        if (hitstop <= 0)
            rb2d.MovePosition(movePos);
        else
            hitstop--;

        if (Input.GetKey(KeyCode.Escape))
            GameManager.playerHealth = 0;
    }

    // 無敵時間処理
    private void Invincible()
    {
        if (invincibleTime > 0)
        {
            Color color = spriteRenderer.color;
            color.a = invincibleTime % 4 < 2 ? 1.0f : 0.5f;

            spriteRenderer.color = color;

            invincibleTime--;
        }
    }


    // HP0
    private void Explosion()
    {
        if (GameManager.playerHealth <= 0)
        {
            exploded = true;

            // エフェクト
            for (int i = 0; i < 360; i+=10)
            {
                ParticleMove pm = Instantiate(particle).GetComponent<ParticleMove>();
                pm.SetEffect(Random.Range(0.02f, 0.16f), i, 120, transform.position, new Vector3(1.0f, 1.0f, 1.0f));
            }

            audioSource.PlayOneShot(clips[(int)sound.Explode]);
        }
    }


    private void TakeDamage(int baseDamage, int baseInvTime)
    {
        int damageValue = GameManager.HasDamageResistance() ? Mathf.Min(baseDamage, 8) : baseDamage;

        GameManager.playerHealth -= damageValue;
        invincibleTime = baseInvTime;

        invincibleTime *= GameManager.HasSuperInvincibility() ? 2 : 1;
        hitstop = 1;

        // エフェクト
        float i = 0;
        while (i < 360)
        {
            ParticleMove pm = Instantiate(particle).GetComponent<ParticleMove>();
            pm.SetEffect(Random.Range(0.08f, 0.1f), 60 * i + Random.Range(-20, 20), transform.position);
            i += 360 / damageValue;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // アイテムの取得などの処理
        if (collision.CompareTag("Diamond"))
        {
            audioSource.PlayOneShot(clips[(int)sound.GetDiamond]);
            Destroy(collision.gameObject);
            GameManager.diamond++;
            GameManager.HealPlayerLife(5);

            // IRRITATE MODE ではダイヤ取得のパーティクルは出ない
            if (GameManager.difficulty == Difficulty.IRRITATE)
            {

            }
            else
            {
                // エフェクト
                screenFlash.Flash(new Color(0, 0, 1, 1), 1);
                for (int i = 0; i < 6; i++)
                {
                    ParticleMove pm = Instantiate(particle).GetComponent<ParticleMove>();
                    pm.SetEffect(Random.Range(0.08f, 0.16f), 60 * i + Random.Range(-20, 20), transform.position);
                }
            }

        }



        if (collision.CompareTag("Crystal"))
        {
            audioSource.PlayOneShot(clips[(int)sound.Elixir]);
            Destroy(collision.gameObject);
            GameManager.playerHealth = GameManager.playerHealthMax;

            // エフェクト
            screenFlash.Flash(new Color(0, 0, 1, 1), 1);
            for (int i = 0; i < 16; i++)
            {
                ParticleMove pm = Instantiate(particle).GetComponent<ParticleMove>();
                pm.SetEffect(Random.Range(0.03f, 0.18f), 20 * i + Random.Range(-5, 5), transform.position);
            }
        }
    }

    // 当たり判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 無敵時間中は被弾しない
        if (invincibleTime <= 0)
        {
            // トゲ
            if (collision.collider.CompareTag("Thorn"))
            {
                TakeDamage(12, 60);
                mainCamera.ShakeCamera();
                screenFlash.Flash(new Color(1, 0, 0, 1), 1);
                audioSource.PlayOneShot(clips[(int)sound.HitThorn]);
            }
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // 被弾処理
        // 無敵時間中は被弾しない
        if (invincibleTime <= 0)
        {
            // ファイア
            if (collision.CompareTag("FireBall"))
            {
                TakeDamage(8, 30);
                mainCamera.ShakeCamera();
                screenFlash.Flash(new Color(1, 0, 0, 1), 1);
                audioSource.PlayOneShot(clips[(int)sound.BurnedByLaser]);
            }

            // レーザー
            if (collision.CompareTag("Laser"))
            {
                TakeDamage(2, 2);
                mainCamera.ShakeCamera(2);
                screenFlash.Flash(new Color(1, 0, 0, 0.25f), 1);
                audioSource.PlayOneShot(clips[(int)sound.BurnedByLaser]);
            }

            // フィルボックス
            if (collision.CompareTag("FillBox"))
            {
                TakeDamage(3, 4);
                mainCamera.ShakeCamera(2);
                screenFlash.Flash(new Color(1, 0, 0, 0.25f), 1);
                audioSource.PlayOneShot(clips[(int)sound.BurnedByLaser]);
            }

            // 雨
            if (collision.CompareTag("Rain"))
            {
                TakeDamage(10, 20);
                mainCamera.ShakeCamera(2);
                screenFlash.Flash(new Color(0, 0, 1, 0.25f), 1);
                audioSource.PlayOneShot(clips[(int)sound.HitRain]);
            }
            if (collision.CompareTag("SpinRain"))
            {
                TakeDamage(18, 40);
                mainCamera.ShakeCamera(2);
                screenFlash.Flash(new Color(0, 0, 1, 0.25f), 1);
                audioSource.PlayOneShot(clips[(int)sound.HitRain]);
            }

            // プラズマ
            if (collision.CompareTag("Plasma"))
            {
                TakeDamage(12, 30);
                mainCamera.ShakeCamera(2);
                screenFlash.Flash(new Color(0, 0, 1, 0.25f), 1);
                audioSource.PlayOneShot(clips[(int)sound.Plasma]);
            }

            // プラズマレーザー
            if (collision.CompareTag("PlasmaLaser"))
            {
                TakeDamage(4, 2);
                mainCamera.ShakeCamera(2);
                screenFlash.Flash(new Color(0, 0, 1, 0.25f), 1);
                audioSource.PlayOneShot(clips[(int)sound.Plasma]);
            }
        }
    }
}
