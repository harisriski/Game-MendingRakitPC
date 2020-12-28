using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class komponen_toko : MonoBehaviour
{

    public GameObject komponen_asli;
    public Image foto;
    public int harga;
    public string nama;
    public string deskripsi;
    public bool beli;

    public bool mobo;
    public bool processor;
    public bool graphic_card;
    public bool hardisk;
    public bool ram;

    private void Awake()
    {
        this.GetComponent<Button>().onClick.AddListener(pilih_komponen);
    }
    // Start is called before the first frame update
    void Start()
    {
        foto = transform.GetChild(0).GetComponent<Image>();
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().SetText(harga.ToString() + "$");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pilih_komponen()
    {
        komponen_toko_manager manager = GameObject.FindGameObjectWithTag("TokoGameManager").GetComponent<komponen_toko_manager>();
        manager.setDeskripsi(this, beli);
    }
}
