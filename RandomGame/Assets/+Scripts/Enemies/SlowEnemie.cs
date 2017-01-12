using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEnemie : MonoBehaviour {

    enum AI_Movment { Patrol, Attack, MoveTowards, KnockBack }
    AI_Movment m_AIMovment;

    //KatanaSword m_Katana;
    EnemieBase m_Stats;
    public Vector3 m_RoomSize;
    Transform m_Player;
    Rigidbody m_Rgb;
    KatanaSword m_Katana;


    float m_KnockBackPower = 500;



    // Use this for initialization
    void Start()
    {
        // get children of the sword
        m_Katana = this.gameObject.transform.GetChild(0).GetComponent<KatanaSword>();

        m_Stats = GetComponent<EnemieBase>();
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        m_Rgb = GetComponent<Rigidbody>();
        Physics.IgnoreCollision(m_Katana.GetComponent<CapsuleCollider>(), GetComponent<BoxCollider>());


        m_AIMovment = AI_Movment.Patrol;
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_AIMovment)
        {
            case AI_Movment.Patrol:
                Patrol();
                break;
            case AI_Movment.MoveTowards:
                MoveTowards();
                break;
            case AI_Movment.Attack:
                Attack();
                break;
            case AI_Movment.KnockBack:
                KnockBack();
                break;
        }

    }

    void Patrol()
    {
       // m_Katana.IdleAnimator();
        float dist = Vector3.Distance(m_Player.position,transform.position);// Check dist if it is lower than 8 it changes state
        if (dist < 8 && dist > 2)
        {
            m_AIMovment = AI_Movment.MoveTowards;

        }

    
    }
    void MoveTowards()
    {
        //  m_Katana.IdleAnimator();
        // Follow the player if its 
        float dist = Vector3.Distance(m_Player.position, transform.position);
        Vector3 moveDirection = m_Player.position - transform.position;
        moveDirection = moveDirection.normalized;
       float angle = Vector3.Angle(transform.position, m_Player.position);

        transform.rotation = Quaternion.Euler(new Vector3(0f, angle,0f)) ;
        m_Rgb.MovePosition(m_Rgb.position + moveDirection * m_Stats.Speed * Time.deltaTime);

        
        if (dist < 1.5)
        {
            m_AIMovment = AI_Movment.Attack;

        }
    }
    void Attack()
    {
        m_Katana.StartCoroutine(m_Katana.coroutinAni(2f));
   
    

    }
    void KnockBack()
    {
        float timer = 1.5f;
        Vector3 knockBackVelocity = (transform.position - m_Player.position).normalized ;
       
        while (timer >= 0)
        {           
            // Knockback with 1 delta time stun; 
            timer -= Time.deltaTime;
            m_Rgb.AddForce(transform.TransformDirection(knockBackVelocity) * Time.deltaTime * m_KnockBackPower);

        }   
        m_AIMovment = AI_Movment.Patrol;
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Sword")
        {
            m_AIMovment = AI_Movment.KnockBack;
        }
    }

}
