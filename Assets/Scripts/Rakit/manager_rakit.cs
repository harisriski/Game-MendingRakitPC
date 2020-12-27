using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager_rakit : MonoBehaviour
{
    public int level;
    public GameObject panel_deskripsi;
    public GameObject slot_terpilih;
    public GameObject komponen_terpilih;
    public GameObject mobo_terpilih;
    public GameObject mobo_terpasang;
    public GameObject area_mobo;
    // Start is called before the first frame update
    public GameObject konten_komponen;
    void Start()
    {
        int banyak_komponen = PlayerPrefs.GetInt("level" + level + "_" + "komponen");
        for(int i = 0; i < banyak_komponen; i++)
        {
            GameObject komponen = Instantiate(Resources.Load("Komponen/" + PlayerPrefs.GetString("level" + level + "_" + i)) as GameObject);
            komponen.name = Resources.Load("Komponen/" + PlayerPrefs.GetString("level" + level + "_" + i)).name;
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

    public void reset_mobo()
    {
        if(mobo_terpasang == null)
        {
            return;
        }

        for(int i = 0; i < mobo_terpasang.transform.childCount; i++)
        {
            if(mobo_terpasang.transform.GetChild(i).GetComponent<slot_komponen_rakit>().komponen != null)
            {
                mobo_terpasang.transform.GetChild(i).GetComponent<slot_komponen_rakit>().komponen.gameObject.SetActive(true);
                mobo_terpasang.transform.GetChild(i).GetComponent<slot_komponen_rakit>().komponen = null;
                mobo_terpasang.transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(false);
            }
        }

        mobo_terpilih.gameObject.SetActive(true);
        mobo_terpilih = null;
        Destroy(mobo_terpasang.gameObject);
        area_mobo.SetActive(true);
    }

    public void selesai_rakit()
    {
        if(mobo_terpasang !=null)
        {
            PlayerPrefs.SetInt("level" + level + "_" + "mobo", 1);
            for (int i = 0; i < 15; i++)
            {
                if (i == 0)
                {
                    if(mobo_terpasang.transform.GetChild(i).GetComponent<slot_komponen_rakit>().komponen != null)
                    {
                        PlayerPrefs.SetString("level" + level + "_" + "processor", mobo_terpasang.transform.GetChild(i).GetComponent<slot_komponen_rakit>().komponen.name);
                    }
                    else
                    {
                        PlayerPrefs.SetString("level" + level + "_" + "processor", "");
                    }
                }

                if (i >= 1 && i <= 6)
                {
                    if (mobo_terpasang.transform.GetChild(i).GetComponent<slot_komponen_rakit>().komponen != null)
                    {
                        PlayerPrefs.SetString("level" + level + "_" + "hardisk" + "_" + i, mobo_terpasang.transform.GetChild(i).GetComponent<slot_komponen_rakit>().komponen.name);

                    }
                    else
                    {
                        PlayerPrefs.SetString("level" + level + "_" + "hardisk" + "_" + i, "");

                    }

                }

                if (i >= 7 && i <= 10)
                {
                    if (mobo_terpasang.transform.GetChild(i).GetComponent<slot_komponen_rakit>().komponen != null)
                    {
                        PlayerPrefs.SetString("level" + level + "_" + "ram" + "_" + i, mobo_terpasang.transform.GetChild(i).GetComponent<slot_komponen_rakit>().komponen.name);

                    }
                    else
                    {
                        PlayerPrefs.SetString("level" + level + "_" + "ram" + "_" + i, "");

                    }

                }

                if (i >= 11 && i <= 14)
                {
                    if (mobo_terpasang.transform.GetChild(i).GetComponent<slot_komponen_rakit>().komponen != null)
                    {
                        PlayerPrefs.SetString("level" + level + "_" + "vga" + "_" + i, mobo_terpasang.transform.GetChild(i).GetComponent<slot_komponen_rakit>().komponen.name);

                    }
                    else
                    {
                        PlayerPrefs.SetString("level" + level + "_" + "vga" + "_" + i, "");

                    }
                }
            }
        }
        else
        {
            PlayerPrefs.SetInt("level" + level + "_" + "mobo", 0);
        }


        SceneManager.LoadScene("level" + level + "_" + "selesai");
    }
}
