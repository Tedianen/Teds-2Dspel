using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointRespawn : MonoBehaviour
{
    private Animator anim;
    private AudioSource Respawning;
    private bool NewRespawnPoint = false;


    // Start is called before the first frame update
    void Start()
    {
        Respawning = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && NewRespawnPoint != true)
        {
            anim.SetTrigger("NewRespawnPoint");
            Respawning.Play();
            NewRespawnPoint = true;
         
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
