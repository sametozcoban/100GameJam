using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcControl : MonoBehaviour
{

    public GameObject target;
    public GameObject enemy;
    Animator anim;
    public GameObject emotions;

    private Health _haydarHealth;

    void Start()
    {
        anim= GetComponent<Animator>();
        
    }

    void Update()
    {
        float dist = Vector2.Distance(target.transform.position, enemy.transform.position);
      if (dist < 5)
      { 
          StartCoroutine(npcEmotions());
         enemy.transform.Translate(target.transform.position * -1f * Time.deltaTime);
         GameObject.FindGameObjectWithTag("enemy").GetComponent<Animator>().SetBool("run", true);
         if ((enemy.transform.position.x - target.transform.position.x) < 0)
         {
             GameObject.FindGameObjectWithTag("enemy").GetComponent<SpriteRenderer>().flipX = false;
         }
         else 
         {
             GameObject.FindGameObjectWithTag("enemy").GetComponent<SpriteRenderer>().flipX = true;
         }
         
         if (dist < 3)
         {
             GameObject.FindGameObjectWithTag("enemy").GetComponent<Animator>().SetBool("Atack", true);
         }
      }
      if (dist > 5)
      {
          
           GameObject.FindGameObjectWithTag("enemy").GetComponent<Animator>().SetBool("run", false);
      }

    }

    IEnumerator npcEmotions()
    {
        emotions.SetActive(true);
        yield return new WaitForSeconds(1f);
        emotions.SetActive(false);
    }

  // private void OnTriggerEnter2D(Collider2D other)
  // {
  //     if (other.gameObject.CompareTag("lavukYatiran"))
  //     {
  //         Debug.Log("vurdu");
  //         anim.SetTrigger("hit");
  //     }
  // }

}
