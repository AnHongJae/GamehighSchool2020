using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour//, IEatable
{
    public Animator m_Animator;

    public float m_Speed = 3f;
    private Rigidbody2D m_Rigidbody2D;


    public bool Jump;
    public bool m_IsDead = false;

    public bool m_IsClimbing = false;
    public bool m_IsTouchLadder = false;
    //public bool m_HitRecoveringTime;

    public float m_ClimbSpeed = 2f;


    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        if (m_IsDead) return;

        float MoveX = Input.GetAxis("Horizontal");
        float MoveY = Input.GetAxis("Vertical");



        if (m_IsTouchLadder && Mathf.Abs(MoveY)> 0.5f)
        {
            m_IsClimbing = true;
        }


        if (!m_IsClimbing)
        {

            Vector3 velocity = (new Vector3(MoveX, 0, MoveY).normalized * m_Speed);
            velocity.y = m_Rigidbody2D.velocity.y;
            m_Rigidbody2D.velocity = velocity;







            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            if (Jump)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Rigidbody2D rd = GetComponent<Rigidbody2D>();
                    rd.AddForce(Vector3.up * 550f);

                    Jump = false;
                }
            }
        }
        else
        {
            m_Rigidbody2D.constraints = 
                m_Rigidbody2D.constraints | RigidbodyConstraints2D.FreezePosition;
            //사다리 도중 이동기능
            Vector3 movement = Vector3.zero;
            movement.x = MoveX * Time.deltaTime;
            movement.y = MoveY * Time.deltaTime;

            transform.position += movement;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ClimbingExit();
            }

            
        }




        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

    if (Jump) {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Rigidbody2D rd = GetComponent<Rigidbody2D>();
                rd.AddForce(Vector3.up * 550f);

                Jump = false;
            }
        }




    }

    private void ClimbingExit()
    {
        m_Rigidbody2D.constraints =
            m_Rigidbody2D.constraints
            & ~RigidbodyConstraints2D.FreezePosition;
        m_IsClimbing = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Jump = true;



        }
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                Jump = true;

                if (contact.rigidbody)
                {
                    var hp = contact.rigidbody.GetComponent<HPComponent>();
                    if (hp)
                    {
                        //Destroy(hp.gameObject);
                        hp.TakeDamage(10);
                    }
                }
            }
            //else if(contact.rigidbody && contact.rigidbody.tag == "Enemy")
            //{
            //    //피격시 무적
            //    if (m_HitRecoveringTime <= 0)
            //    {
            //        var hp = GetComponent<HPComponent>();
            //        hp.TakeDamage(10);
            //        m_HitRecoveringTime = 1;
            //    }

            //    m_Rigidbody2D.velocity = Vector2.zero;
            //    m_Rigidbody2D.AddForce(Vector2.left * 10000f);
            //}
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ladder")
        {
            m_IsTouchLadder = true;
        }
        else if(collision.tag == "Item")
        {
            var item = collision.GetComponent<ItemComponet>();
            if(item != null)
            item.BeAte(this);
        }

        if (collision.tag == "DeadZone")
        {
            m_IsDead = true;

            GameManager.Instance.OnplayerDead();

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            m_IsTouchLadder = false;

            ClimbingExit();
        }
    }




    public void LevelUp()
    {
        m_Speed++;
    }

    public void EatEvent()
    {
        LevelUp();
    }




}