using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class deskripsi_rakit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        set_deskripsi();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void set_deskripsi(slot_komponen_rakit slot)
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("- " + slot.gameObject.name);
        if (slot.komponen != null) transform.GetChild(1).GetComponent<TextMeshProUGUI>().SetText("- Terpasang (" + slot.komponen.GetComponent<komponen_rakit>().nama + ")");
        else
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().SetText("- Belum Terpasang");
    }

    public void set_deskripsi(komponen_rakit komponen)
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(komponen.nama);
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().SetText(komponen.deskripsi);
    }

    public void set_deskripsi()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("");
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().SetText("");
    }
}
