using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class komponen_rakit : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    GameObject foto_komponen;
    manager_rakit manager;

    public bool mobo;
    public bool processor;
    public bool graphic_card;
    public bool hardisk;
    public bool ram;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("RakitGameManager").GetComponent<manager_rakit>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector2 lastMousePosition;

    /// <summary>
    /// This method will be called on the start of the mouse drag
    /// </summary>
    /// <param name="eventData">mouse pointer event data</param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        manager.komponen_terpilih = gameObject;
        foto_komponen = Instantiate(Resources.Load("Sprite") as GameObject);
        foto_komponen.transform.position = eventData.position;
        foto_komponen.GetComponent<SpriteRenderer>().sortingOrder = 3;
        foto_komponen.GetComponent<SpriteRenderer>().sprite = transform.GetChild(0).GetComponent<Image>().sprite;
        foto_komponen.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        foto_komponen.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.3f);
        Debug.Log("Begin Drag");
        lastMousePosition = eventData.position;
    }

    /// <summary>
    /// This method will be called during the mouse drag
    /// </summary>
    /// <param name="eventData">mouse pointer event data</param>
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        foto_komponen.transform.position = new Vector2(mouse_pos.x,mouse_pos.y);
    }

    /// <summary>
    /// This method will be called at the end of mouse drag
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        if(manager.mobo_terpilih != null)
        {
            if(manager.mobo_terpasang == null)
            {
                manager.mobo_terpasang = Instantiate(Resources.Load("mobo") as GameObject);
                manager.mobo_terpilih = null;
                manager.area_mobo.SetActive(false);
                manager.komponen_terpilih.SetActive(false);
            }
        }
        else
        {
            if (manager.slot_terpilih != null)
            {
                if (!manager.slot_terpilih.GetComponent<slot_komponen_rakit>().terpasang)
                {

                    manager.slot_terpilih.GetComponent<slot_komponen_rakit>().terpasang = true;
                    manager.slot_terpilih.transform.GetChild(0).gameObject.SetActive(true);
                    manager.komponen_terpilih.SetActive(false);
                }
            }
        }



        manager.komponen_terpilih = null;
        Destroy(foto_komponen);
        Debug.Log("End Drag");
        //Implement your funtionlity here
    }

    public void setKategori(komponen_toko komponen)
    {
        mobo = komponen.mobo;
        processor = komponen.processor;
        graphic_card = komponen.graphic_card;
        hardisk = komponen.hardisk;
        ram = komponen.ram;
    }
}
