using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaydarControl : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    bool isGrounded;
    public bool isFlip;
    public GameObject shotSpawn;
    public GameObject shotBall;
    public AudioSource ac;
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        float moveInputX = Input.GetAxisRaw("Horizontal");
        float moveInputY = Input.GetAxisRaw("Vertical");

        Vector2 moveVelocity = new Vector2(moveInputX, moveInputY).normalized * 5;
        rb.velocity = new Vector2(moveVelocity.x, rb.velocity.y);

        Debug.Log(moveInputY + " " + moveInputX);
        if (moveInputX > 0)
        {
            isFlip= false;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            //GameObject.FindGameObjectWithTag("shotSpawn").GetComponent<SpriteRenderer>().flipX = true;
            anim.SetBool("isRun", true);
        }
        if (moveInputX < 0)
        {
            isFlip = true;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            //GameObject.FindGameObjectWithTag("shotSpawn").GetComponent<SpriteRenderer>().flipX = false;
            anim.SetBool("isRun", true);
        }
        if (moveInputX == 0)
        {
            anim.SetBool("isRun", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Atack");
            Instantiate(shotBall.transform, shotSpawn.transform);
            ac.Play();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            anim.SetBool("isDead", true);
            StartCoroutine(dying());
            
        }


        // Z�plama
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("w �al��t�");
            anim.SetTrigger("Jump");
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, 11f);
            }
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (2.5f - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.W))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (2.5f - 1) * Time.deltaTime;
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("ground") || other.gameObject.CompareTag("enemy"))
        {
            anim.SetBool("Ground", true);
            isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            anim.SetBool("Ground", false);
            isGrounded = false;
        }
    }

    IEnumerator dying()
    {
        yield return new WaitForSeconds(1f);
        rb.gravityScale = -2f;
        rb.mass = 0f;
        rb.AddForce(new Vector2(0f, .05f));
    }



}
