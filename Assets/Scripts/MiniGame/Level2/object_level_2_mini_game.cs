using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_level_2_mini_game : MonoBehaviour
{
    level_2_mini_game_manager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("MiniGameManager").GetComponent<level_2_mini_game_manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.mulai && !manager.selesai)
        {
            transform.Translate(manager.moveSpeed * Time.deltaTime, 0, 0);

        }

        if (transform.position.x <= -20)
        {
            Destroy(gameObject);
        }
    }
}
