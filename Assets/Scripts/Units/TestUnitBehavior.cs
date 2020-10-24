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

    new void FixedUpdate()
    {
        transform.position += speed * Time.deltaTime;
    }
      
    // Update is called once per frame
    void Update()
    {
        ////código para movimentação da unidade teste.
        speed = Vector3.zero;
        speed.y = 5f * Input.GetAxis("Vertical");
        speed.x = 5f * Input.GetAxis("Horizontal");
    }

}
