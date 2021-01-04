using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakter_level_2_mini_game : MonoBehaviour
{
    level_2_mini_game_manager manager;
    bool nyentuh_lantai;
    Rigidbody2D rigid;
    public float jump_force;
    // Start is called before the first frame update
    void Start()
    {
        nyentuh_lantai = true;
        rigid = GetComponent<Rigidbody2D>();
        manager = GameObject.FindGameObjectWithTag("MiniGameManager").GetComponent<level_2_mini_game_manager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!manager.mulai)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                manager.mulai = true;
            }
        }
        else
        {
            if(!manager.selesai)
            {
                if (Input.GetKey(KeyCode.Space) && nyentuh_lantai)
                {
                    rigid.AddForce(Vector2.up * jump_force);
                    nyentuh_lantai = false;
                }
            }

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        nyentuh_lantai = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        nyentuh_lantai = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Obstacle")
        {
            manager.selesai = true;
            manager.game_over.SetActive(true);
            manager.game_over.GetComponent<selesai_level_2_mini_game>().game_selesai();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            manager.tambah_koin(1);
            Destroy(collision.gameObject);
        }
        Debug.Log(collision.tag);
    }
}
