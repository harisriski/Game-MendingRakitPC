using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class manager_level_3_mini_game : MonoBehaviour
{
    public float moveSpeed;
    public bool mulai;
    public bool selesai;
    public int koin;
    public GameObject ui_selesai;
    public Transform spawn_point;
    float timer;
    public float spawn_delay;
    Transform last_obstacle;
    float timer_koin;
    public TextMeshProUGUI text_koin;
    public GameObject text_keterangan;
    // Start is called before the first frame update
    void Start()
    {
        
        koin = 0;
        set_koin(koin);
        timer_koin = 3f;
        timer = spawn_delay;
        mulai = false;
        selesai = false;
        moveSpeed = -3f;
        last_obstacle = Instantiate(Resources.Load("MiniGame/Level3/obstacle_" + Random.Range(1, 4)) as GameObject, spawn_point.position,spawn_point.rotation).transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mulai && !selesai)
        {
            if(text_keterangan.activeSelf)
            {
                text_keterangan.SetActive(false);
            }

            timer_koin -= Time.deltaTime;
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                bool naik = false;
                int pacuan_naik = Random.Range(1, 3);
                if(pacuan_naik == 2)
                {
                    naik = true;
                }

                float y = last_obstacle.position.y;

                if(naik)
                {
                    y += Random.Range(1, 3);
                }
                else
                {
                    y -= Random.Range(1, 3);
                }

                y = Mathf.Clamp(y, -2, 2);

                Vector3 spawn_pos = new Vector3(spawn_point.position.x, y, spawn_point.position.z);

                last_obstacle = Instantiate(Resources.Load("MiniGame/Level3/obstacle_" + Random.Range(1, 4)) as GameObject, spawn_pos, spawn_point.rotation).transform;
                if(timer_koin <= 0)
                {
                    last_obstacle.GetComponent<obstacle_level_3_mini_game>().aktifkan_koin(Random.Range(1, 3));
                    timer_koin = 3f;
                }
                timer = spawn_delay;
            }

            moveSpeed -= 0.09f * Time.deltaTime;
            spawn_delay -= 0.03f * Time.deltaTime;
            Debug.Log(moveSpeed);

            moveSpeed = Mathf.Clamp(moveSpeed, -6f, -3f);
            spawn_delay = Mathf.Clamp(spawn_delay, 1f, 2f);
        }
    }

    public void gameover(GameObject player)
    {
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        selesai = true;
        ui_selesai.SetActive(true);
        ui_selesai.GetComponent<selesai_level_3_mini_game>().game_selesai();
    }

    public void tambah_koin(int banyak)
    {
        koin += banyak;
        set_koin(koin);
    }

    public void set_koin(int banyak)
    {
        text_koin.SetText("Koin : " + banyak);
    }
}
