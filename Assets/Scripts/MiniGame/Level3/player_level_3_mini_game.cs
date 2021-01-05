using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_level_3_mini_game : MonoBehaviour
{
    Rigidbody2D rigid;
    public float jump_force;
    manager_level_3_mini_game manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("MiniGameManager").GetComponent<manager_level_3_mini_game>();
        rigid = GetComponent<Rigidbody2D>();
        rigid.isKinematic = true;
    }


    // Update is called once per frame
    void Update()
    {
        if(manager.mulai)
        {
            if(!manager.selesai)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rigid.velocity = Vector3.zero;
                    rigid.AddForce(Vector3.up * jump_force, ForceMode2D.Force);
                }
            }

        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rigid.isKinematic = false;
                manager.mulai = true;
                rigid.velocity = Vector3.zero;
                rigid.AddForce(Vector3.up * jump_force, ForceMode2D.Force);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        manager.gameover(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Obstacle")
        {
            manager.gameover(gameObject);
        }

        if(collision.tag == "Coin")
        {
            manager.tambah_koin(1);
            Destroy(collision.gameObject);
        }
    }
}
