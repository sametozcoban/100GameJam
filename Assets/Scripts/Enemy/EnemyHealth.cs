using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int enemyDamage;
    private int enemyHealth;
    private int speed;
    private int animationSpeed;
    

    public enum EnemyType
    {
        Piyade,
        AğırAbi,
        Bombacı,
        Sniper,
        Komando
    }

    public EnemyType selectedEnemyType;

    void Start()
    {
        // Sağlık değerini ayarla
        switch (selectedEnemyType)
        {
            case EnemyType.Piyade:
                enemyHealth = 1;
                enemyDamage = 1;
                speed = 1;
                break;

            case EnemyType.AğırAbi:
                enemyHealth = 2;
                speed = 1;
                enemyDamage = 1;
                animationSpeed = 1;
                break;

            case EnemyType.Bombacı:
                enemyHealth = 1; // Örneğin bombacının sağlık değeri 1
                speed = 3;
                enemyDamage = 1;
                animationSpeed = 1;
                break;

            case EnemyType.Sniper:
                enemyHealth = 1; // Örneğin sniper'ın sağlık değeri 1
                speed = 4;
                enemyDamage = 1;
                break;

            case EnemyType.Komando:
                enemyHealth = 4; // Örneğin komandonun sağlık değeri 1
                speed = 3;
                enemyDamage = 3;
                animationSpeed = 3;
                break;

            default:
                enemyHealth = 1; // Varsayılan değer olarak piyade seçildi
                break;
        }

        // Test etmek için sağlık değerini yazdır
        //Debug.Log("Enemy Health: " + enemyHealth);
    }

    void Update()
    {
        Debug.Log("Enemy Health: " + enemyHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("lavukYatiran") || collision.CompareTag("bullet"))
        {
            // Sağlık değerini ayarla
            switch (selectedEnemyType)
            {
                case EnemyType.Piyade:
                    enemyHealth -= 1;
                    if (enemyHealth == 0)
                    {
                        Destroy(gameObject, 1f);
                        GameObject.FindGameObjectWithTag("enemy").GetComponent<Animator>().SetBool("isDead", true);
                        return;
                    }
                    break;

                case EnemyType.AğırAbi:
                    enemyHealth -= 1;
                    if (enemyHealth == 0)
                    {
                        Destroy(gameObject, 1f);
                        return;
                    }
                    break;

                case EnemyType.Bombacı:
                    enemyHealth -= 1; // Örneğin bombacının sağlık değeri 1
                    if (enemyHealth == 0)
                    {
                        Destroy(gameObject, 1f);
                        return;
                    }

                    break;

                case EnemyType.Sniper:
                    enemyHealth -= 1;
                    if (enemyHealth == 0)
                    {
                        Destroy(gameObject, 1f);
                        return;
                    }
                    break;

                case EnemyType.Komando:
                    enemyHealth -= 1;
                    if (enemyHealth == 0)
                    {
                        Destroy(gameObject, 1f);
                        return;
                    }
                    break;

                default:
                    enemyHealth = 1; // Varsayılan değer olarak piyade seçildi

                    break;
            }

        }
    }

}
