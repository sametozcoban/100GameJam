using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 15f;  // Zıplama kuvvetini artırdık
    public float fallMultiplier = 2.5f;  // Düşerkenki hızı artırmak için
    public float lowJumpMultiplier = 2f;  // Yavaş zıplamayı düzeltmek için
    public Animator anim;
    public float fireInterval = 0.5f;  // Ateş etme aralığı (saniye cinsinden)
    private bool isFiring;  // Ateş durumu kontrol değişkeni
    bool isGrounded = true;
    public GameObject degnak;

    public AudioSource ac;
   

    private Rigidbody2D rb;

    

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
        // Hareket kontrolü
        float moveInputX = Input.GetAxisRaw("Horizontal");
        float moveInputY = Input.GetAxisRaw("Vertical");

        Vector2 moveVelocity = new Vector2(moveInputX, moveInputY).normalized * moveSpeed;
        rb.velocity = new Vector2(moveVelocity.x, rb.velocity.y);  // Yalnızca yatay hareket

        //Debug.Log(moveInputY + " " + moveInputX );
        if (moveInputX > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            //GameObject.FindGameObjectWithTag("lavukYatiran").GetComponent<CapsuleCollider2D>().offset = new Vector2(0f, 0f);
            anim.SetBool("isRun",true);
        }
        if (moveInputX < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            //GameObject.FindGameObjectWithTag("lavukYatiran").GetComponent<CapsuleCollider2D>().offset = new Vector2(0f, .7f);
            anim.SetBool("isRun", true);
        }
        if (moveInputX == 0)
        {
            anim.SetBool("isRun", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ac.Play();
            anim.SetTrigger("Atack");
            StartCoroutine(Degnakk());
           
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            anim.SetBool("isDead", true);
           
        }


        // Zıplama
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("Jump");
            Jump();
        }

        // Uygula: Düşerken hızı artırmak veya yavaşlatmak
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.W))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        // Çökme animasyonu
        bool isCrouching = Input.GetKey(KeyCode.S);
        //animator.SetBool("IsCrouching", isCrouching);

        // Ateş animasyonu
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            StartFiring();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopFiring();
        }*/

    }

    /*void StartFiring()
    {
        if (!isFiring)
        {
            isFiring = true;
            // Particle System'i başlat
            if (fireParticleSystem != null)
            {
                Debug.Log("Ateş edildi");
                fireParticleSystem.Play();
            }
        }
    }*/

    /*void StopFiring()
    {
        if (isFiring)
        {
            isFiring = false;
            // Particle System'i durdur
            if (fireParticleSystem != null)
            {
                fireParticleSystem.Stop();
            }
        }
    }*/

    void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    
    
    //bool IsGrounded()
   // {
    //    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
     //   return hit.collider != null;
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name);
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



    IEnumerator Degnakk()
    {
        yield return new WaitForSeconds(.6f);
        if (gameObject.GetComponent<SpriteRenderer>().flipX)
        {
            degnak.SetActive(true);
            GameObject.FindGameObjectWithTag("lavukYatiran").GetComponent<CapsuleCollider2D>().offset = new Vector2(0f, .7f);
            
        }
        if (!gameObject.GetComponent<SpriteRenderer>().flipX)
        {
            degnak.SetActive(true);
            GameObject.FindGameObjectWithTag("lavukYatiran").GetComponent<CapsuleCollider2D>().offset = new Vector2(0f, 0f);

        }
        yield return new WaitForSeconds(.2f);
        degnak.SetActive(false);
        yield return new WaitForSeconds(2f);
    }
   
}
