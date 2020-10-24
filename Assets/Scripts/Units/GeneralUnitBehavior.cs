using System.Collections;
using System.Collections.Generic;
using UnityEngine.Sprites;
using UnityEngine;

//Esse script está no root "Scripts" por se tratar da parte de behavior que se repetirá para todas as unidades, qualquer que sejam.
public class GeneralUnitBehavior : MonoBehaviour
{
    public GameObject mainTarget; //stores GameObject of current target.
    public GameObject myHandle; //stores object handle.
    public int health = 5; //define a vida a unidade; pode vir a ser int, dependendo se quebraremos ou não o dano em frações.
    public int attackDamage = 1; //define o dano causado por ataque da unidade; pode vir a ser int, pela mesma razão de cima.
    public float attackSpeed = 1.0f; //define quantas vezes a unidade ataca por segundo.
    public float moveSpeed = 1.5f; //define o quão rápido a unidade se move na tela.
    public float time;
    public float summonTime;
    public Quaternion variavelTeste;
    public bool startMove = false;
    public bool shouldMove = false;
    public bool doneSummon = false;
    public AttackCollision attackStick;
        //mais atributos serão inseridos a medida que sejam pertinentes ao desenvolvimento do projeto.




    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, 0); //coloca todas as unidades criadas no eixo z 0.
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (doneSummon == false)//1.6s for animation to take place.
        {
            if (summonTime <= 1.0f)
            {
                summonTime += Time.deltaTime;
                //Debug.Log(summonTime);
            }
            else
            {
                doneSummon = true;
                startMove = true;
            }
        }
        time += Time.deltaTime;
        Vector3 pointTowards = transform.position.normalized;
        pointTowards.z = 0.0f;
        Vector3 pointTarget = (mainTarget.transform.position - transform.position).normalized;
        pointTowards.z = 0.0f;
        float dotProduct = Vector3.Dot(pointTarget, transform.right);
        float targetAngle = Vector3.Angle(pointTowards, pointTarget);
        //Debug.Log(targetAngle);
        Quaternion targetRotation = Quaternion.Euler(0, 0, -1 * Mathf.Sign(dotProduct) * targetAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation * targetRotation, moveSpeed * 3 * Time.deltaTime);
    }

    //função que vai definir os atributos da unidade ao summoná-la.
    public void Summoned(int ht, int atk, float atkS, float mS)
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
            //Debug.Log("That's it, I'm dead.");
            //provisóriamente, o objeto será destruído.
        }
    }

    public void OnTriggerStay2D(Collider2D target) //attacks between opposing factions.
    {
        if (time >= 1/attackSpeed)
        {
            if (gameObject.tag == "AlliedUnit" && target.tag == "EnemyUnit")
            {
                AttackCollision stick = Instantiate(attackStick, myHandle.transform.position, transform.rotation);
                stick.direction = (mainTarget.transform.position - transform.position).normalized;
                stick.direction.z = 0.0f;
                stick.targetCollider = target;
                stick.damage = attackDamage;
                stick.intendedTarget = "EnemyUnit";
                time = 0.0f;
            }

            if (gameObject.tag == "EnemyUnit" && target.tag == "AlliedUnit")
            {
                AttackCollision stick = Instantiate(attackStick, myHandle.transform.position, transform.rotation);
                stick.direction = (mainTarget.transform.position - transform.position).normalized;
                stick.direction.z = 0.0f;
                stick.targetCollider = target;
                stick.damage = attackDamage;
                stick.intendedTarget = "AlliedUnit";
                time = 0.0f;
            }

            if (gameObject.tag == "EnemyUnit" && target.tag == "Nexus")
            {
                AttackCollision stick = Instantiate(attackStick, myHandle.transform.position, transform.rotation);
                stick.direction = (mainTarget.transform.position - transform.position).normalized;
                stick.direction.z = 0.0f;
                stick.targetCollider = target;
                stick.damage = attackDamage;
                stick.intendedTarget = "Nexus";
                time = 0.0f;
                //AttackCollision stick = Instantiate(attackStick, transform.position, transform.rotation);
                //stick.direction = (mainTarget.transform.position - transform.position).normalized;
                //stick.direction.z = 0.0f;
                //target.gameObject.SendMessage("OnHit", attackDamage);
                //Debug.Log("I send OnHit to" + target);
            }
        }


        //if (hasCollided == false)
        //{
        //    if (this.tag == "AlliedUnit" && target.tag == "EnemyUnit" || this.tag == "EnemyUnit" && target.tag == "AlliedUnit")
        //    {
        //        //target.gameObject.SendMessage("OnHit", attackDamage);
        //        //this.gameObject.SendMessage("OnHit", attackDamage);
        //        hasCollided = true;
        //    }
        //    if (this.tag == "EnemyUnit" && target.tag == "Nexus")
        //    {
        //        //target.gameObject.SendMessage("NexusHit", attackDamage);
        //        //Debug.Log(target.name);
        //        hasCollided = true;
        //        Destroy(gameObject);

        //    }
        //}

    }

    public void OnMouseDown()
    {
        if (Input.GetKey("left shift"))
        {
            Destroy(gameObject);
        }
            
    }
}
