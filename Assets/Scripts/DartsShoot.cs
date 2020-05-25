using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DartsShoot : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D myRigidBody2D;

    public bool IsReleased { get; set; }
    public bool Hit { get; set; }

  
    private void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
                
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FirDarts();
        } 
       
    }
    public void FirDarts()
    {
        if(!IsReleased)
        {
            IsReleased = true;
            myRigidBody2D.AddForce(new Vector2(0f, speed), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Weel"))
        {
            transform.SetParent(col.transform);
            myRigidBody2D.velocity = Vector2.zero;
            myRigidBody2D.isKinematic = true;
        }
        else if (col.gameObject.CompareTag("Enemy"))
        {
            /*Destroy(gameObject, 0.5f);*/
        }
    }
}
