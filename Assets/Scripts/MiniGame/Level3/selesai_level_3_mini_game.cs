using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class selesai_level_3_mini_game : MonoBehaviour
{
    public TextMeshProUGUI text_koin_selesai;
    public TextMeshProUGUI text_anggaran;
    manager_level_3_mini_game manager;
    int multiplier = 50;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void game_selesai()
    {
        manager = GameObject.FindGameObjectWithTag("MiniGameManager").GetComponent<manager_level_3_mini_game>();
        text_koin_selesai.SetText("Koin : " + manager.koin);
        int total_anggaran = manager.koin * multiplier;
        text_anggaran.SetText("Anggaran : " + total_anggaran + "$");
    }

    public void toko()
    {
        PlayerPrefs.SetInt("level_3_cari_uang", 1);
        PlayerPrefs.SetInt("level_3_anggaran", manager.koin * multiplier);
        SceneManager.LoadScene("level3_toko");
    }
}
