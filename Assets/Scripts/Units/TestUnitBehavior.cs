using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esse script está no root "Scripts" por se tratar da parte de behavior que se repetirá para todas as unidades, qualquer que sejam.
public class TestUnitBehavior : MonoBehaviour
{
    //código para movimentação da unidade teste.
    private Vector3 speed;

    public float health = 1.0f; //define a vida a unidade; pode vir a ser int, dependendo se quebraremos ou não o dano em frações.
    public float attackDamage = 1.0f; //define o dano causado por ataque da unidade; pode vir a ser int, pela mesma razão de cima.
    public float attackSpeed = 1.0f; //define quantas vezes a unidade ataca por segundo.
    public float moveSpeed = 1.0f; //define o quão rápido a unidade se move na tela.
    //mais atributos serão inseridos a medida que sejam pertinentes ao desenvolvimento do projeto.

    // Start is called before the first frame update
    void Start()
    {
        //código para movimentação da unidade teste.
        speed = new Vector3(0, 0, 0);
    }

    void FixedUpdate()
    {
        transform.position += speed * Time.deltaTime;
    }

    //função que vai definir os atributos da unidade ao summoná-la.
    public void isSummoned(float ht, float atk, float atkS, float mS)
    {
        health = ht;
        attackDamage = atk;
        attackSpeed = atkS;
        moveSpeed = mS;
    }

    //função a ser chamada quando qualquer unitade sofre dano, a ser modificada no futuro com "tipo de dano" e "elemento de dano".
    public void OnHit(float damage)
    {
        health -= damage;
        //damage será devidamente multiplicada por valores futuros de tipo e elemento de dano, bem como resistências a elementos.
        if (health <= 0)
        {
            Destroy(gameObject);
            //provisóriamente, o objeto será destruído.
        }
    }

    //função para contato com inimigo e "dar dano".
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
    }
}
