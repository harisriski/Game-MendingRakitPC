using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class komponen_toko_deskripsi : MonoBehaviour
{
    public Image foto_komponen;
    public TextMeshProUGUI text_harga;
    public TextMeshProUGUI text_nama;
    public TextMeshProUGUI text_deskripsi;
    public GameObject tombol_beli;
    public GameObject tombol_batal;
    public GameObject konten_beli;
    
    // Start is called before the first frame update
    void Start()
    {
        tombol_beli.GetComponent<Button>().onClick.AddListener(beli);
        tombol_batal.GetComponent<Button>().onClick.AddListener(batal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDeskripsi(komponen_toko komponen, bool beli)
    {
        if(beli)
        {
            tombol_batal.SetActive(false);
            tombol_beli.SetActive(true);
        }
        else
        {
            tombol_beli.SetActive(false);
            tombol_batal.SetActive(true);
        }
        foto_komponen.rectTransform.sizeDelta = komponen.foto.rectTransform.sizeDelta;
        foto_komponen.sprite = komponen.foto.sprite;
        text_harga.SetText("Harga : \n" + "Rp " + komponen.harga.ToString());
        text_nama.SetText("Nama : \n" + komponen.nama);
        text_deskripsi.SetText("Deskripsi : \n" + komponen.deskripsi);
    }

    public void beli()
    {
        komponen_toko_manager manager = GameObject.FindGameObjectWithTag("TokoGameManager").GetComponent<komponen_toko_manager>();
        GameObject terpilih = Instantiate(manager.komponen_terpilih);
        terpilih.name = manager.komponen_terpilih.name;
        terpilih.transform.SetParent(konten_beli.transform);
        terpilih.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        terpilih.GetComponent<komponen_toko>().beli = false;
    }

    public void batal()
    {
        Destroy(GameObject.FindGameObjectWithTag("TokoGameManager").GetComponent<komponen_toko_manager>().komponen_terpilih);
    }
}
