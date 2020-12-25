using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobo_detektor_rakit : MonoBehaviour
{
    manager_rakit manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("RakitGameManager").GetComponent<manager_rakit>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if(manager.slot_terpilih == null)
        {
            if(manager.komponen_terpilih != null)
            {
                if(manager.komponen_terpilih.GetComponent<komponen_rakit>().mobo)
                {
                    manager.mobo_terpilih = manager.komponen_terpilih;
                }
            }
        }
        Debug.Log("masuk ke " + gameObject.name);
    }

    private void OnMouseExit()
    {

        Debug.Log("keluar dari " + gameObject.name);
    }
}
