using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.Universal;
//using UnityEditor.SceneManagement;
public class PlayerMove : MonoBehaviour
{
    public GameObject Light2d;
    new Rigidbody2D rigidbody2D;
    Animator animator;
    [Header("地面")]
    public bool OnGround; 
    [Header("属性")]
    public float Speed = 1;
    public float JumpSeed = 1;
    public float JumpTime = 1;
    float JumpTime0 = 0;

    public static int Stage = 1;
    int Stage1 = 0;

    static Select select;
    public static bool isIn = false;//是否在画中
    public static float Light = 100;
    float SelectintoTimer = 1;

    void Start()
    {
        OnGround = false;
        transform.rotation = Quaternion.Euler(0, 180, 0);
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        setStage();
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            Move();
            jump();
            setStage();
            Selectinto();
        }
    }
    static float inputX;
    public static bool left = false;
    private void Move()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        rigidbody2D.linearVelocity = new Vector2(inputX * Speed * Time.deltaTime * 100, rigidbody2D.linearVelocity.y);

        if (inputX > 0) { transform.rotation = Quaternion.Euler(0, 0, 0); left = false; }
        else if (inputX < 0){ transform.rotation = Quaternion.Euler(0, 180, 0);left = true; }

        if (inputX == 0)animator.SetBool("Move", false);
        else animator.SetBool("Move", true);

    }
    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(JumpTime0<JumpTime)JumpTime0 += Time.deltaTime;
            if (OnGround)
            {
                rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocity.x, JumpSeed);
                OnGround = false;
                animator.Play("jump");
            }
        }
    }
    private void setStage()
    {
        if (Stage1 != Stage)
        {
            //animator.SetInteger("Stage", Stage);
            Light2d.GetComponent<Light2D>().intensity = Light/100f;
            SpriteRenderer a = GetComponent<SpriteRenderer>();
             //a.color = new Color(a.color.r,a.color.g,a.color.b, Light / 100f);
            Stage1 = Stage;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag=="Ground")
        {
            OnGround=true;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Frame") select = collision.GetComponent<Select>();
        //if(select&&select.use) { select = null; }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Frame") select = collision.GetComponent<Select>();
       // if (select&& select.use) { select = null; }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Frame") select = null;
    }
    void Selectinto()
    {
        if (SelectintoTimer > 0) SelectintoTimer -= Time.deltaTime;
        if ((select != null || isIn)&& SelectintoTimer<=0)
        {
            float a = Input.GetAxis("Mouse ScrollWheel");
            if (!isIn && a > 0)
            {
                if (select)
                {
                    select.UnityEvents.Invoke();
                    select = null;
                    isIn = true;
                }
            }
            else if (isIn && a < 0)
            {

                Camera.main.GetComponent<CameraEffects>().returnToScene0();
                //isIn = false;
            }
            if (a != 0) SelectintoTimer = 1;
        }
    }
}
