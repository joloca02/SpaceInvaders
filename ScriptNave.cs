using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptNave : MonoBehaviour
{
    Rigidbody2D MyRB;
    public GameObject cohete;
    // Start is called before the first frame update
    void Start()
    {
        MyRB = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal");
        MyRB.velocity = transform.right * movement*15;
        float xPos = Mathf.Clamp(MyRB.position.x, -6.5f, 6.5f);
        transform.position = new Vector2(xPos, -7.0f);

        if (Input.GetButton("Jump"))
        {
            GameObject disparo =Instantiate(cohete, new Vector2(MyRB.position.x, -5.75f), Quaternion.identity);
            Rigidbody2D RBdisparo = disparo.GetComponent<Rigidbody2D>();
            RBdisparo.velocity= (new Vector2(0f, 1f)*20);
        }
    }
}
