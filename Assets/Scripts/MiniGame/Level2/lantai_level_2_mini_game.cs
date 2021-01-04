using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lantai_level_2_mini_game : MonoBehaviour
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
        if(transform.position.x <= -20 && manager.lantai_teripilih_reset == null)
        {
            manager.lantai_teripilih_reset = transform;
        }
    }
}
