using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_level_3_mini_game : MonoBehaviour
{
    manager_level_3_mini_game manager;
    public GameObject koin1;
    public GameObject koin2;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("MiniGameManager").GetComponent<manager_level_3_mini_game>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= -20)
        {
            Destroy(gameObject);
        }

        if(manager.mulai && !manager.selesai)
        {
            transform.Translate(manager.moveSpeed * Time.deltaTime, 0, 0);
        }
        
    }

    public void aktifkan_koin(int id)
    {
        if(id == 1)
        {
            koin1.SetActive(true);
            koin2.SetActive(false);
        }
        else
        {
            koin2.SetActive(true);
            koin1.SetActive(false);
        }
    }
}
