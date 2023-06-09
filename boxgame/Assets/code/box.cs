using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    private float min_X = -1f, max_X = 3.59f;


    private bool canmove;
    private float move_speed = 2f;
    

    private Rigidbody2D mybody;

    private bool gameOver;
    private bool ignoreCollition;
    private bool ignoreTrigger;

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
    }

     void Start()
    {
        canmove = true;

        if (Random.Range(0, 2) > 0)
        {
            move_speed *= -1f;
        }


        controller.instance.box = this;

    }

     void Update()
    {
        MoveBox();
    }

     void MoveBox()
    {
        if (canmove)
        {
            Vector3 temp = transform.position;
            temp.x += move_speed * Time.deltaTime;

            if(temp.x > max_X)
            {
                move_speed *= -1f;
            }else if (temp.x < min_X)
            {
                move_speed *= -1f;
            }

            transform.position= temp;
        }
    }
    public void drop()
    {
        canmove = false;
        mybody.gravityScale = 4;
    }

    void Landed()
    {
        if (gameOver)
            return;

        ignoreCollition = true;
        ignoreTrigger = true;
        controller.instance.spwannewbox();
        controller.instance.movecamera();

    }
    void restartgame()
    {
        controller.instance.restartgame();
    }

     void OnCollisionEnter2D(Collision2D target)
    {
        if (ignoreCollition)
        {
            return;        
        }
        if(target.gameObject.tag == "ground")
        {
            Invoke("Landed", 0.1f);
            ignoreCollition = true;
            ignoreTrigger = true;         
        }
        if (target.gameObject.tag == "box")
        {
           
            Invoke("Landed", 0.1f);
            ignoreCollition = true;
            ignoreTrigger = true;
        
        }
       
    }

     void OnTriggerEnter2D(Collider2D target)
    { 
        if (ignoreTrigger)
        {
            return;
        }
        if (target.tag == "gameover")
        {
            Debug.Log("end");
            CancelInvoke("Landed");
            gameOver = true;
            ignoreTrigger = true;
            Invoke("restartgame", 0.5f);
        }
    }
}
