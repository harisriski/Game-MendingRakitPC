using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class komponen_toko_manager : MonoBehaviour
{
    public GameObject komponen_terpilih;
    public komponen_toko_deskripsi panel_deskripsi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDeskripsi(komponen_toko komponen, bool beli)
    {
        komponen_terpilih = komponen.gameObject;
        panel_deskripsi.setDeskripsi(komponen, beli);
    }

    public void selesaiBelanja()
    {
        int banyak_komponen = panel_deskripsi.konten_beli.transform.GetChildCount();
        PlayerPrefs.SetInt("level1_komponen", 0);
        for (int i = 0; i < banyak_komponen; i++)
        {
            PlayerPrefs.SetString("level1_" + i, panel_deskripsi.konten_beli.transform.GetChild(i).name);
            PlayerPrefs.SetInt("level1_komponen", PlayerPrefs.GetInt("level1_komponen") + 1);
        }
        PlayerPrefs.SetString("level1_" + banyak_komponen, "");

        for(int i = 0; i < banyak_komponen+1; i++)
        {
            Debug.Log(PlayerPrefs.GetString("level1_" + i));
        }

        SceneManager.LoadScene("level1_rakit");
    }
}
