using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEnemigo : MonoBehaviour
{
    bool limite = false;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Movimiento", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Movimiento()
    {
        if (limite == false)
        {
            transform.Translate(Vector3.right);
            if (transform.position.x == 6)
            {
                limite = true;
            }
        }
        else
        {
            transform.Translate(Vector3.left);
            if (transform.position.x == -6)
            {
                limite = false;
            }
        }
    }
}
