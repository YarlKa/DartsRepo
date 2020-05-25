using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enamy : MonoBehaviour
{
    [SerializeField] private ParticleSystem airBallParticl;

    private BoxCollider2D myCollider2D;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    public void Start()
    {
        myCollider2D = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Darts"))
        {
            Debug.Log("Hit");
            myCollider2D.enabled = false;
            sr.enabled = false;

            airBallParticl.Play();
            Destroy(gameObject, 2f);

        }
    }
    
}
