using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptNave : MonoBehaviour
{
    Rigidbody2D MyRB;
    public bool posibleDisparo = true;
    public bool canMove = true;
    public GameObject cohete;
    public GameObject LooseText;
    public GameObject WinText;
    // Start is called before the first frame update
    void Start()
    {
        MyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            float movement = Input.GetAxis("Horizontal");
            MyRB.velocity = transform.right * movement * 15;
            float xPos = Mathf.Clamp(MyRB.position.x, -6.5f, 6.5f);
            transform.position = new Vector2(xPos, -7.0f);
        }

        if (Input.GetButton("Jump") && posibleDisparo)
        {
            GameObject disparo = Instantiate(cohete, new Vector2(MyRB.position.x, -5.50f), Quaternion.identity);
            Rigidbody2D RBdisparo = disparo.GetComponent<Rigidbody2D>();
            RBdisparo.velocity = (new Vector2(0f, 1f) * 20);
            posibleDisparo = false;
        }
    }
    public void reiniciarDisparo()
    {
        posibleDisparo = true;

    }
    public void activateWinText()
    {
        WinText.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LooseText.SetActive(true);
        posibleDisparo = false;
        canMove = false;
        GameObject[] n = GameObject.FindGameObjectsWithTag("Enemigo");
        for (int i = 0; i < n.Length; i++)
        {
            n[i].GetComponent<ScriptEnemigo>().canMove = false;
        }
    }
}
