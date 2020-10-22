using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esse script está no root "Scripts" por se tratar da parte de behavior que se repetirá para todas as unidades, qualquer que sejam.
public class GeneralUnitBehavior : MonoBehaviour
{
    public float health = 1.0f; //define a vida a unidade; pode vir a ser int, dependendo se quebraremos ou não o dano em frações.
    public int attackDamage = 1; //define o dano causado por ataque da unidade; pode vir a ser int, pela mesma razão de cima.
    public float attackSpeed = 1.0f; //define quantas vezes a unidade ataca por segundo.
    public float moveSpeed = 1.0f; //define o quão rápido a unidade se move na tela.
    public bool hasCollided = false;
    //mais atributos serão inseridos a medida que sejam pertinentes ao desenvolvimento do projeto.

    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, 0); //coloca todas as unidades criadas no eixo z 0.
    }

    // Update is called once per frame
    void Update()
    {
        if (hasCollided)
        {
            Destroy(gameObject);
        }
    }
    
    //função que vai definir os atributos da unidade ao summoná-la.
    public void isSummoned(float ht, int atk, float atkS, float mS)
    {
        health = ht;
        attackDamage = atk;
        attackSpeed = atkS;
        moveSpeed = mS;
    }

    //função a ser chamada quando qualquer unitade sofre dano, a ser modificada no futuro com "tipo de dano" e "elemento de dano".
    public void OnHit(int damage)
    {
        health -= damage;
        //damage será devidamente multiplicada por valores futuros de tipo e elemento de dano, bem como resistências a elementos.
        Debug.Log("I " + gameObject.name + " was hit for " + damage + " damage! Only " + (health) + " hitpoints remain");
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("That's it, I'm dead.");
            //provisóriamente, o objeto será destruído.
        }
    }

    public void OnTriggerEnter2D(Collider2D target) //attacks between opposing factions.
    {
        if (hasCollided == false)
        {
            if (this.tag == "AlliedUnit" && target.tag == "EnemyUnit" || this.tag == "EnemyUnit" && target.tag == "AlliedUnit")
            {
                target.gameObject.SendMessage("OnHit", attackDamage);
                //this.gameObject.SendMessage("OnHit", attackDamage);
                hasCollided = true;
            }
            if (this.tag == "EnemyUnit" && target.tag == "Nexus")
            {
                target.gameObject.SendMessage("NexusHit", attackDamage);
                //Debug.Log(target.name);
                hasCollided = true;
                Destroy(gameObject);

            }
        }
        
    }

    public void OnMouseDown()
    {
        if (Input.GetKey("left shift"))
            Destroy(gameObject);
    }
}
