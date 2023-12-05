//Orignal script created by Stanley Freihofer
using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;

    public ParticleSystem ParticleSystem;
    public RubyController rubyController;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    bool broken = true;

    Animator animator;

    //private ScoreCounter scoreCounter;

    // Start is called before the first frame update
    void Start()                //by Stannley Freihofer
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        rubyController = FindObjectOfType<RubyController>();
    }

    void Update()       //by Stanley Freihofer
    {
        //remember ! inverse the test, so if broken is true !broken will be false and return won’t be executed.
        if (!broken)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()          //by Stanley Freihofer
    {
        //remember ! inverse the test, so if broken is true !broken will be false and return won’t be executed.
        if (!broken)
        {
            return;
        }

        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }

        rigidbody2D.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)      //by Stanley Freihofer
    {
        RubyController controller = other.gameObject.GetComponent<RubyController>();

        if (controller != null)
        {
            controller.ChangeHealth(-1);        //decrease player health by a value of 1
        }
    }

    //by Stanley Freihofer
    //Public because we want to call it from elsewhere like the projectile script
    public void Fix()           //Fix broken robots function
    {
        broken = false;
        rigidbody2D.simulated = false;
        animator.SetTrigger("Fixed");
        ParticleSystem.Stop();
        //ScoreCounter scoreCounter = FindObjectOfType<ScoreCounter>();
        Debug.Log("Fixed");

        if (rubyController != null)
        {
            rubyController.ChangeScore(1);
            Debug.Log("Score increased");

        }
        Debug.Log("rubyController: " + rubyController);
    }
}

//controller.ChangeScore(1);
//controller1.ChangeScore(1);
//Debug.Log("score increased");
//RubyController controller1 = other.collider.GetComponent<RubyController>();
//RubyController controller = other.gameObject.GetComponent<RubyController>();