//ORIGINAL SCRIPT MADE BY STANLEY FREIHOFER
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RubyController : MonoBehaviour
{
    // ========= MOVEMENT =================
    public float speed = 4;
    private float newSpeed;

    // ======== HEALTH ==========
    public int maxHealth = 5;
    public float timeInvincible = 2.0f;
    public Transform respawnPosition;
    public ParticleSystem hitParticle;
    int currentHealth;
    float invincibleTimer;
    bool isInvincible;
    public int health
    {
        get { return currentHealth; }
    }

    // ======== PROJECTILE ==========
    public GameObject projectilePrefab;

    // ======== AUDIO ==========
    public AudioClip hitSound;
    public AudioClip shootingSound;
    public AudioClip winSound;
    public AudioClip loseSound;
    AudioSource audioSource;



    // =========== MOVEMENT ==============
    Rigidbody2D rigidbody2d;
    Vector2 currentInput;

    // ==== ANIMATION =====
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    // ================= SOUNDS =======================
 

    //SCORE & UI & GAME MANAGEMENT      //DON'T THINK OF THESE AS ACCESSING OBJECTS. THINK OF THESE AS CONTAINERS YOU WILL PUT THE OBJECTS YOU WANT TO ACCESS IN
    public int score = 0;
    public GameObject loseUI;
    public GameObject winUI;
    public GameObject ScoreUI;
    public TMP_Text speedDescription;
    public bool gameEnd = false;
    public TMP_Text scoreText;
    public TMP_Text speedValue;



    void Start()        //by Stanley Freihofer
    {
        Debug.Log(speed);
        // =========== MOVEMENT ==============
        rigidbody2d = GetComponent<Rigidbody2D>();

        // ======== HEALTH ==========
        invincibleTimer = -1.0f;
        currentHealth = maxHealth;

        // ==== ANIMATION =====
        animator = GetComponent<Animator>();

        // ==== AUDIO =====
        audioSource = GetComponent<AudioSource>();

        scoreText.text = "Score: " + score.ToString() + " /4 Robots Fixed";
        speedDescription.text = "Ruby is mid";
        speedValue.text = speed.ToString() + " Ruby Steps/hr";
    }

    void Update()       //by Stanley Freihofer
    {

        // ================= HEALTH ====================
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        // ============== MOVEMENT ======================
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        currentInput = move;


        // ============== ANIMATION =======================

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        // ============== PROJECTILE ======================

        if (Input.GetKeyDown(KeyCode.C))
            LaunchProjectile();

        // ======== DIALOGUE ==========
        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, 1 << LayerMask.NameToLayer("NPC"));
            if (hit.collider != null)
            {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    character.DisplayDialog();
                }
            }
        }


        if (gameEnd)
        {
            rigidbody2d.constraints = RigidbodyConstraints2D.FreezePosition;
            if (Input.GetKey(KeyCode.R))

            {

                if (gameEnd == true)

                {

                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // this loads the currently active scene

                }

            }
        }

    }

    void FixedUpdate()          //by Stanley Freihofer
    {
        Vector2 position = rigidbody2d.position;

        position = position + currentInput * speed * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    // ===================== HEALTH ==================
    public void ChangeHealth(int amount)        //by Stanley Freihofer
    {
        if (amount < 0)             //if the change in health is < 0
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;

            animator.SetTrigger("Hit");
            audioSource.PlayOneShot(hitSound);

            Instantiate(hitParticle, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        UIHealthBar.Instance.SetValue(currentHealth / (float)maxHealth);
        if (currentHealth <= 0)
        {
            LoseGame();
        }
        Debug.Log(amount);
        Debug.Log(currentHealth);
    }


    // ================ LOSE GAME SCENARIO ===========================
    public void LoseGame()
    {
        loseUI.SetActive(true);
        ScoreUI.SetActive(false);
        gameEnd = true;
        PlaySound(loseSound);
    }



    // =============== PROJECTICLE ========================
    void LaunchProjectile()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");
        audioSource.PlayOneShot(shootingSound);
    }



    // =============== SOUND ==========================

    //Allow to play a sound on the player sound source. used by Collectible
    public void PlaySound(AudioClip clip)       //by Stanley Freihofer
    {
        audioSource.PlayOneShot(clip);
    }

    public void ChangeScore(int amount)             //by Stanley Freihofer
    {
        score += amount;
        //scoreText.text = score.ToString();
        scoreText.text = "Score: " + score.ToString() + "/4 Robots Fixed";
        Debug.Log("Score changed by" + amount);

    //=============== WIN SCENARIO ==========================
        if (score >= 4)         //WIN SCENARIO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        {
            scoreText.text = score.ToString("You Win! Game Created by Stanley Freihofer");
            winUI.SetActive(true);
            PlaySound(winSound);
        }
    }

    public void ChangeSpeed(int amount)         //by Stanley Freihofer
    {
        if (amount < 4)     //if the change in speed is < 0
        {
            Debug.Log("speed:" + speed + "newSpeed:" + newSpeed + "amount:" + amount);
            speed = amount;
            speedDescription.text = ("Ruby is Slow");
            speedValue.text = speed.ToString() + " Ruby Steps/hr";
        }
        if (amount > 4)
        {
            speed = amount;
            speedDescription.text = ("Ruby is Fast");
            speedValue.text = speed.ToString() + " Ruby Steps/hr";
        }
            
    }
}


