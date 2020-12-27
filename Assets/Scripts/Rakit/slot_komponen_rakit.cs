using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot_komponen_rakit : MonoBehaviour
{
    Color highlight_color = new Color(1, 0.7960784f, 0.5215687f,1);
    Color normal_color;
    SpriteRenderer sprite;
    manager_rakit manager;
    public bool hardisk;
    public GameObject komponen;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("RakitGameManager").GetComponent<manager_rakit>();
        sprite = GetComponent<SpriteRenderer>();
        normal_color = sprite.color;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        manager.slot_terpilih = gameObject;
        if(komponen == null)
        {
            if (hardisk)
            {
                sprite.color = Color.black;
            }
            else
            {
                sprite.color = highlight_color;
            }
            
        }
        else
        {

        }

        Debug.Log("masuk ke " + gameObject.name);
    }

    private void OnMouseOver()
    {
        manager.panel_deskripsi.GetComponent<deskripsi_rakit>().set_deskripsi(this);
    }

    private void OnMouseExit()
    {
        if(manager.slot_terpilih != null)
        {
            manager.slot_terpilih = null;
        }
        sprite.color = normal_color;
        manager.panel_deskripsi.GetComponent<deskripsi_rakit>().set_deskripsi();

        Debug.Log("keluar dari " + gameObject.name);
    }
}
