using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    private Animator anim;

    // You can adjust these values to change the bounce force and direction
    public float bounceForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("UPPPPPPP");
        if (collision.gameObject.name == "Player")
        {
            TrampJump(collision.gameObject);
            anim.SetBool("Tramping", true);
        }
    }

    private void TrampJump(GameObject player)
    {
        // Make sure the player GameObject has a Rigidbody2D component
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Apply an upward force to the player
            rb.AddForce(new Vector2(0, bounceForce), ForceMode2D.Impulse);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("Tramping", false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

