using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int playerMaxHealth = 2;
    [SerializeField] private int currentHealth;
    [SerializeField] public GameObject _ui;
    public bool characterDead;
    

    public HealthBar _healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = playerMaxHealth;
        _healthBar.SetMaxHealth(playerMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
      //if (Input.GetKeyDown(KeyCode.Space)) // Space olarak kalmayacak değişmesi ön görülüyor.
      //{
      //    currentHealth -= 1;
      //    _healthBar.SetHealth(currentHealth);
      //    if (currentHealth == 0)
      //    {
      //        Destroy(gameObject);
      //    }
      //} 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("kılıç"))
        {
            currentHealth -= 1;
            _healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                GameObject.FindGameObjectWithTag("Haydar").GetComponent<Animator>().SetBool("isDead", true);
                StartCoroutine(timeScale());
                _ui.SetActive(true);
            }
        }
    }

    IEnumerator timeScale()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0f;
    }
}
