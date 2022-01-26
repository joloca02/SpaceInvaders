using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
  
    ScriptNave scriptNave;
    // Start is called before the first frame update
    void Start()
    {
       scriptNave = GameObject.FindGameObjectWithTag("Nave").GetComponent<ScriptNave>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ha habido colision");
        Destroy(gameObject);
        scriptNave.reiniciarDisparo();
    }

}
