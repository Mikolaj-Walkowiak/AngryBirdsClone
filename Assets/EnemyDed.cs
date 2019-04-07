using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyDed : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public GameObject deathEffect;
    public float Damage = 2f;
    // Start is called before the first frame update
    void Start()
    {
        EnemiesAlive++;
    }
    void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.relativeVelocity.magnitude > Damage)
        {
            Kill();
        }
    }

    void Kill()
    {
        
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        EnemiesAlive--;
        if (EnemiesAlive <= 0)
        {
            Debug.Log("Wygranko");
            ///Next level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
