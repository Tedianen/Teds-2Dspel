using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private Vector3 respawnPoint; // Store the respawn point

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // Set initial respawn point to the player's starting position
        respawnPoint = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes") || collision.gameObject.CompareTag("Saw") || collision.gameObject.CompareTag("Falldamage") || collision.gameObject.CompareTag("CannonBall"))
        {
            Die();   
        }
    }

    private void Die()
    {
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;

        // Respawn the player after a delay (e.g., 1 second)
        StartCoroutine(RespawnAfterDelay(1.0f));
    }

    private IEnumerator RespawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Move the player to the respawn point
        transform.position = respawnPoint;

        // Reset the player's state or any other necessary logic
        rb.bodyType = RigidbodyType2D.Dynamic;
        anim.SetTrigger("respawn");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RespawnPoint"))
        {
            // Set a new respawn point if collided with the RespawnPoint object
            respawnPoint = other.transform.position;
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

