using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
  
    ScriptNave scriptNave;
    GameObject Enemigo;
    // Start is called before the first frame update
    void Start()
    {
        Enemigo = GameObject.FindGameObjectWithTag("Enemigo"); 
        scriptNave = GameObject.FindGameObjectWithTag("Nave").GetComponent<ScriptNave>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Enemigo != null) { 
        if (Enemigo.GetComponent<Collider2D>() == collision)
        {
            Destroy(Enemigo);
        }
        }
        Destroy(gameObject);
        scriptNave.reiniciarDisparo();
    }

}
