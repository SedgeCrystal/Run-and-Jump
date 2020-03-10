using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float maxSpeed_x = 10.0f;
    Rigidbody2D rigidbody2D;
    float longJumpForce = 1500;
    float shortJumpForce = 1000;
    float lastSpeed_y = 0;
    bool isJumping = false;
    bool canJump = false;
    float mouseDownTime = 0;
    float threshold_MDT = 0.1f;
    float coolTime = 0.5f;
    float restCoolTime = 0;
    float time = -3;
    bool isStart = false;
    Text startCntText;
    Text scoreText;
    Animator animator;
    int jumpFinger = 0;

    public GameObject shotPrefab;
        

    
    // Start is called before the first frame update
    void Start()
    {
        this.rigidbody2D = GetComponent<Rigidbody2D>();
        
        this.animator = GetComponent<Animator>();
        this.startCntText = GameObject.Find("StartCountText").GetComponent<Text>();
        this.scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        startCntText.text = 3.ToString();

        DontDestroyOnLoad(this);
        
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("Collision");

        if(other.gameObject.tag == "Field" && lastSpeed_y >0)
        {
            this.isJumping = false;
            this.mouseDownTime = 0;
            //Debug.Log("not jumping");
        }
    }
    void MouseButton(int finger)
    {
        if (Input.GetMouseButtonDown(finger))
        {
            //Debug.Log(time);
            if (Input.touches[finger].position.x < Screen.width / 2)
                
            {
                mouseDownTime = 0;
                canJump = true;
                jumpFinger = finger;
            }
            else
            {
                if (restCoolTime <= 0)
                {
                    GameObject shot = Instantiate(shotPrefab) as GameObject;
                    shot.transform.position = this.transform.position + new Vector3(1, 0.1f, 0);
                    restCoolTime = coolTime;
                }
            }

        }
        if (Input.GetMouseButton(finger))
        {
            //Debug.Log(time);
            mouseDownTime += Time.deltaTime;
            //Debug.Log(mouseDownTime);
            if (canJump && !isJumping && mouseDownTime > this.threshold_MDT)
            {

                this.rigidbody2D.AddForce(transform.up * this.longJumpForce);

                this.isJumping = true;
                this.canJump = false;

            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        this.scoreText.text = transform.position.x.ToString("F1") + "m";
        if(transform.position.y  < -5)
        {
            SceneManager.LoadScene("ResultScene");

        }
        if (time < 0)
        {
            this.startCntText.text = (-1 * (time - 0.5f)).ToString("F0");

        }
        else
        {
            if (!isStart)
            {
                isStart = true;
                this.rigidbody2D.velocity = new Vector2(maxSpeed_x, 0);
                this.startCntText.text = "";
                this.animator.SetTrigger("StartTrigger");
            }

            restCoolTime -= Time.deltaTime;
            if (restCoolTime < 0)
            {
                restCoolTime = 0;
            }
            float v_y = this.rigidbody2D.velocity.y;

            this.rigidbody2D.velocity = new Vector2(maxSpeed_x, v_y);
            float speedY = Mathf.Abs(v_y);

            lastSpeed_y = speedY;

            if (Input.GetMouseButton(0))
            {
                MouseButton(0);
            }
            if (Input.GetMouseButton(1))
            {
                MouseButton(1);
            }

            if (Input.GetMouseButtonUp(jumpFinger))
            {
                
                if (canJump && !isJumping)
                {
                    this.rigidbody2D.AddForce(transform.up * this.shortJumpForce);
                    this.isJumping = true;
                    canJump = false;

                }
            }


            //Debug.Log(this.rigidbody2D.velocity);
            this.animator.SetBool("IsJumped", this.isJumping);
        }


    }
}
