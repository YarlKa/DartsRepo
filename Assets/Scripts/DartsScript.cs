using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DartsScript : MonoBehaviour
{
    public float Fors;

    public GameObject dartsRefab;

    bool isShoot;
    Vector2 spawPos;
    Vector2 scale;

    private void Start()
    {
        dartsRefab.name = "";
        spawPos = transform.position;
        scale = transform.localScale;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Weel")
        {
            transform.SetParent(col.transform);
            SpawnNewDarts();
            Destroy(this);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {

            Destroy(gameObject, 2f);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isShoot = true;
        }
        if (isShoot)
        {
            transform.Translate(new Vector3(0, Fors, 0));
        }
    }
    void SpawnNewDarts()
    {
        GameObject temp = Instantiate(dartsRefab, spawPos, Quaternion.identity);
        temp.transform.localScale = scale;
    }
    void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
