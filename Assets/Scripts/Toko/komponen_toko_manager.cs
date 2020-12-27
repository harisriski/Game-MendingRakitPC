using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class komponen_toko_manager : MonoBehaviour
{
    public int level;
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
        int banyak_komponen = panel_deskripsi.konten_beli.transform.childCount;
        PlayerPrefs.SetInt("level" + level + "_komponen", 0);
        for (int i = 0; i < banyak_komponen; i++)
        {
            PlayerPrefs.SetString("level" + level + "_" + i, panel_deskripsi.konten_beli.transform.GetChild(i).name);
            PlayerPrefs.SetInt("level" + level + "_" + "komponen", PlayerPrefs.GetInt("level" + level + "_" + "komponen") + 1);
        }
        PlayerPrefs.SetString("level" + level + "_" + banyak_komponen, "");

        for(int i = 0; i < banyak_komponen+1; i++)
        {
            Debug.Log(PlayerPrefs.GetString("level" + level + "_" + i));
        }

        SceneManager.LoadScene("level" + level + "_" + "rakit");
    }
}
