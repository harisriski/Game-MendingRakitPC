using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class komponen_toko_manager : MonoBehaviour
{
    public int level;
    public GameObject komponen_terpilih;
    public komponen_toko_deskripsi panel_deskripsi;
    public int total_anggaran;
    public int total_biaya;
    public Color hijau;
    public Color merah;
    public TextMeshProUGUI text_anggaran;
    public TextMeshProUGUI text_total_biaya;
    public GameObject anggaran_tidak_cukup;

    public GameObject tombol_cari_anggaran;
    // Start is called before the first frame update
    void Start()
    {
        if(level != 1)
        {
            if (PlayerPrefs.GetInt("level_" + level + "_cari_uang") == 0)
            {
                total_anggaran = 0;
                tombol_cari_anggaran.SetActive(true);
            }
            else
            {
                tombol_cari_anggaran.SetActive(false);
                total_anggaran = PlayerPrefs.GetInt("level_" + level + "_anggaran");

            }
        }


        set_anggaran_biaya(total_anggaran, total_biaya);
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
        if (total_biaya <= total_anggaran)
        {
            int banyak_komponen = panel_deskripsi.konten_beli.transform.childCount;
            PlayerPrefs.SetInt("level" + level + "_komponen", 0);
            PlayerPrefs.SetInt("level" + level + "_anggaran", total_anggaran);
            PlayerPrefs.SetInt("level" + level + "_biaya", total_biaya);
            for (int i = 0; i < banyak_komponen; i++)
            {
                PlayerPrefs.SetString("level" + level + "_" + i, panel_deskripsi.konten_beli.transform.GetChild(i).name);
                PlayerPrefs.SetInt("level" + level + "_" + "komponen", PlayerPrefs.GetInt("level" + level + "_" + "komponen") + 1);
            }
            PlayerPrefs.SetString("level" + level + "_" + banyak_komponen, "");

            for (int i = 0; i < banyak_komponen + 1; i++)
            {
                Debug.Log(PlayerPrefs.GetString("level" + level + "_" + i));
            }

            SceneManager.LoadScene("level" + level + "_" + "rakit");
        }

    }
    
    public void tambah_biaya(int biaya)
    {
        total_biaya += biaya;
        set_anggaran_biaya(total_anggaran, total_biaya);
    }

    public void kurangi_biaya(int biaya)
    {
        total_biaya -= biaya;
        set_anggaran_biaya(total_anggaran, total_biaya);
    }
    
    public void set_anggaran_biaya(int anggaran, int biaya)
    {
        total_anggaran = anggaran;
        total_biaya = biaya;
        text_anggaran.SetText("Anggaran : " + total_anggaran + "$");
        text_total_biaya.SetText("Total Biaya : " + total_biaya + "$");
        if(total_biaya <= total_anggaran)
        {
            text_total_biaya.color = hijau;
            anggaran_tidak_cukup.SetActive(false);
        }
        else
        {
            anggaran_tidak_cukup.SetActive(true);
            text_total_biaya.color = merah;
        }
    }
}
