using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager_rakit : MonoBehaviour
{
    public GameObject slot_terpilih;
    public GameObject komponen_terpilih;
    public GameObject mobo_terpilih;
    public GameObject mobo_terpasang;
    public GameObject area_mobo;
    // Start is called before the first frame update
    public GameObject konten_komponen;
    void Start()
    {
        int banyak_komponen = PlayerPrefs.GetInt("level1_komponen");
        for(int i = 0; i < banyak_komponen; i++)
        {
            GameObject komponen = Instantiate(Resources.Load("Komponen/" + PlayerPrefs.GetString("level1_" + i)) as GameObject);
            komponen.transform.SetParent(konten_komponen.transform);
            Destroy(komponen.transform.GetChild(1).gameObject);
            komponen.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            komponen.AddComponent<komponen_rakit>();
            komponen.GetComponent<komponen_rakit>().setKategori(komponen.GetComponent<komponen_toko>());
            Destroy(komponen.GetComponent<komponen_toko>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
