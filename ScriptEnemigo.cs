using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEnemigo : MonoBehaviour
{
    float rate = 1f;
    bool limite = false;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Movimiento", 1f, rate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
    IEnumerator CambioAltura()
    {
        yield return new WaitForSeconds(rate);
        CancelInvoke();
        transform.Translate(Vector3.down);
        if(transform.position.x == 5)
        {
            transform.Translate(Vector3.right);
        }
        else if(transform.position.x == -5)
        {
            transform.Translate(Vector3.left);
        }
        rate *= 0.9f;
        InvokeRepeating("Movimiento", rate, rate);
    }
    void Movimiento()
    {
        if (limite == false)
        {
            
            transform.Translate(Vector3.right);
            if (transform.position.x == 6)
            {
                StartCoroutine(CambioAltura());
                limite = true;

            }
        }
        else
        {
            transform.Translate(Vector3.left);
            if (transform.position.x == -6)
            {
                StartCoroutine(CambioAltura());
                limite = false;
            }
        }
    }
}
