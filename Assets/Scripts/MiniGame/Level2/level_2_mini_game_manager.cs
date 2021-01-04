using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class level_2_mini_game_manager : MonoBehaviour
{
    public bool mulai;
    public bool selesai;
    public Transform spawn_point;
    public TextMeshProUGUI text_score;
    public Transform moving_lantai;
    public Transform lantai_teripilih_reset;
    public Transform last_pos;
    public float moveSpeed;
    public int koin;

    public GameObject keterangan;
    public GameObject game_over;

    float timer_obstacle;
    float timer_koin;
    // Start is called before the first frame update
    void Start()
    {
        timer_obstacle = Random.Range(3, 6);
        timer_koin = Random.Range(3, 6);
        koin = 0;
        set_koin(koin);
        mulai = false;
        moveSpeed = -6f;   
    }

    // Update is called once per frame
    void Update()
    {
        if(mulai && !selesai)
        {
            if(keterangan.activeSelf)
            {
                keterangan.SetActive(false);
            }
            moveSpeed -= 0.2f * Time.deltaTime;
            moveSpeed = Mathf.Clamp(moveSpeed, -12f, -6f);
            moving_lantai.Translate(moveSpeed * Time.deltaTime, 0, 0);
            if (lantai_teripilih_reset != null)
            {
                moving_lantai = lantai_teripilih_reset.transform.GetChild(0);
                lantai_teripilih_reset.transform.GetChild(0).SetParent(null);
                lantai_teripilih_reset.SetParent(last_pos);
                lantai_teripilih_reset.localPosition = new Vector3(38f, 0, 0);
                last_pos = lantai_teripilih_reset;
                lantai_teripilih_reset = null;
            }
            Debug.Log(moveSpeed);


            timer_koin -= Time.deltaTime;
            timer_obstacle -= Time.deltaTime;
            if(timer_koin <= 0)
            {
                Instantiate(Resources.Load("MiniGame/Level2/koin") as GameObject, spawn_point.position, spawn_point.rotation);
                timer_koin = Random.Range(3, 6);

            }
            if(timer_obstacle <= 0)
            {
                Instantiate(Resources.Load("MiniGame/Level2/virus_" + Random.Range(1,4)) as GameObject, spawn_point.position, spawn_point.rotation);
                timer_obstacle = Random.Range(1, 3);
            }
        }

    }

    public void tambah_koin(int banyak)
    {
        koin += banyak;
        set_koin(koin);
    }

    public void set_koin(int banyak)
    {
        koin = banyak;
        text_score.SetText("Koin : " + banyak);
    }
}
