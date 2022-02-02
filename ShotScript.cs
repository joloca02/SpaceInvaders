using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
  
    ScriptNave scriptNave;
    GameObject[] Enemigos;
    GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.FindGameObjectWithTag("TextWin");
        Enemigos = GameObject.FindGameObjectsWithTag("Enemigo"); 
        scriptNave = GameObject.FindGameObjectWithTag("Nave").GetComponent<ScriptNave>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        scriptNave.reiniciarDisparo();
        for (int i = 0; i < Enemigos.Length; i++) { 
        if (Enemigos.Length!=0) { 
        if (Enemigos[i].GetComponent<Collider2D>() == collision)
        {
            Destroy(Enemigos[i]);
                    if (Enemigos.Length == 1)
                    {
                        scriptNave.activateWinText();
                        scriptNave.canMove = false;
                        scriptNave.posibleDisparo = false;
                    }
            }
        }

    }
    }
}
