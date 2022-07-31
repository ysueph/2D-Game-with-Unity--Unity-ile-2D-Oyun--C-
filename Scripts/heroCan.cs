using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class heroCan : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator animasyon;

   [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
       rigid = GetComponent<Rigidbody2D>();
        animasyon = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
       deathSoundEffect.Play();
       rigid.bodyType = RigidbodyType2D.Static;
        animasyon.SetTrigger("olme");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
