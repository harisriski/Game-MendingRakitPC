using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class selesai_level_2_mini_game : MonoBehaviour
{
    public TextMeshProUGUI text_koin_selesai;
    public TextMeshProUGUI text_anggaran;
    level_2_mini_game_manager manager;
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
        manager = GameObject.FindGameObjectWithTag("MiniGameManager").GetComponent<level_2_mini_game_manager>();
        text_koin_selesai.SetText("Koin : " + manager.koin);
        int total_anggaran = manager.koin * multiplier;
        text_anggaran.SetText("Anggaran : " + total_anggaran + "$");
    }

    public void toko()
    {
        PlayerPrefs.SetInt("level_2_cari_uang", 1);
        PlayerPrefs.SetInt("level_2_anggaran", manager.koin * multiplier);
        SceneManager.LoadScene("level2_toko");
    }
}
