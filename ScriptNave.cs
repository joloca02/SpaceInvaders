using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptNave : MonoBehaviour
{
    Rigidbody2D MyRB;
    bool posibleDisparo = true;
    bool canMove = true;
    public GameObject cohete;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        MyRB = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove) { 
        float movement = Input.GetAxis("Horizontal");
        MyRB.velocity = transform.right * movement*15;
        float xPos = Mathf.Clamp(MyRB.position.x, -6.5f, 6.5f);
        transform.position = new Vector2(xPos, -7.0f);
        }

        if (Input.GetButton("Jump") && posibleDisparo)
        {
            GameObject disparo =Instantiate(cohete, new Vector2(MyRB.position.x, -5.50f), Quaternion.identity);
            Rigidbody2D RBdisparo = disparo.GetComponent<Rigidbody2D>();
            RBdisparo.velocity= (new Vector2(0f, 1f)*20);
            posibleDisparo = false;
        }
    }
    public void reiniciarDisparo()
    {
        posibleDisparo = true;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.SetActive(true);
        posibleDisparo = false;
        canMove = false;
        GameObject.FindGameObjectWithTag("Enemigo").GetComponent<ScriptEnemigo>().canMove=false;

    }
}
