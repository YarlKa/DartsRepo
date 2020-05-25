using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DartsShoot : MonoBehaviour
{
    [SerializeField]
    private Vector2 Fors;

    private bool isActiv = true;

    private Rigidbody2D rb;
    private BoxCollider2D dartsCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        dartsCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && isActiv)
        {
            rb.AddForce(Fors, ForceMode2D.Impulse);
            rb.gravityScale = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isActiv)
            return;
        isActiv = false;

        if(collision.collider.tag == "Weel")
        {
            rb.velocity = new Vector2(0, 0);
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(collision.collider.transform);

            dartsCollider.offset = new Vector2(dartsCollider.offset.x, -0.4f);
            dartsCollider.size = new Vector2(dartsCollider.size.x, 1.2f);
        }
        else if(collision.collider.tag == "Darts")
        {
            rb.velocity = new Vector2(rb.velocity.x, -2);
        }

        else
        {
            Destroy(gameObject, 2f);
        }
    }
}
