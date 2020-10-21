using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

//Esse script está no root "Scripts" por se tratar da parte de behavior que se repetirá para todas as unidades, qualquer que sejam.
public class TestUnitBehavior : GeneralUnitBehavior
{
    //código para movimentação da unidade teste.
    private Vector3 speed;

    void Start()
    {
        //código para movimentação da unidade teste.
        speed = new Vector3(0, 0, 0);
    }

    void FixedUpdate()
    {
        transform.position += speed * Time.deltaTime;
    }

    public void OnTriggerEnter2D (Collider2D target)
    {
        if (target.tag == "TestUnit" || target.tag == "EnemyUnit")
        {
            target.gameObject.SendMessage("OnHit", attackDamage);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        ////código para movimentação da unidade teste.
        speed = Vector3.zero;
        speed.y = 5f * Input.GetAxis("Vertical");
        speed.x = 5f * Input.GetAxis("Horizontal");

        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
