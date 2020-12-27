using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class selesai_rakit_manager : MonoBehaviour
{
    public int level;
    public TextMeshProUGUI text_hasil;
    public TextMeshProUGUI text_detail;
    // Start is called before the first frame update
    void Start()
    {
        cek_komponen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cek_komponen()
    {
        string detail_kesalahan_pokok = "";
        bool skip_hardisk = false;
        bool skip_ram = false;
        bool skip_vga = false;
        int slot_hardisk_terisi = 6;
        int slot_ram_terisi = 4;
        int slot_vga_terisi = 4;

        if(PlayerPrefs.GetInt("level" + level + "_mobo") != 0)
        {
            for (int i = 0; i < 15; i++)
            {
                if (i == 0)
                {
                    if (!PlayerPrefs.GetString("level" + level + "_" + "processor").Equals(""))
                    {
                        if ((Resources.Load("Komponen/" + PlayerPrefs.GetString("level" + level + "_" + "processor")) as GameObject).GetComponent<komponen_toko>().processor)
                        {
                            Debug.Log("processor bener");
                        }
                        else
                        {
                            Debug.Log("processor salah");
                        }
                    }
                    else
                    {
                        detail_kesalahan_pokok += "- Slot Processor\n";
                    }
                }

                if (i >= 1 && i <= 6)
                {
                    if (!PlayerPrefs.GetString("level" + level + "_" + "hardisk" + "_" + i).Equals(""))
                    {
                        if (!skip_hardisk && (Resources.Load("Komponen/" + PlayerPrefs.GetString("level" + level + "_" + "hardisk" + "_" + i)) as GameObject).GetComponent<komponen_toko>().hardisk)
                        {
                            slot_hardisk_terisi -= 1;
                        }
                        else
                        {
                            skip_hardisk = true;
                        }
                    }
                }

                if (i >= 7 && i <= 10)
                {
                    if (!PlayerPrefs.GetString("level" + level + "_" + "ram" + "_" + i).Equals(""))
                    {
                        if (!skip_ram && (Resources.Load("Komponen/" + PlayerPrefs.GetString("level" + level + "_" + "ram" + "_" + i)) as GameObject).GetComponent<komponen_toko>().ram)
                        {
                            slot_ram_terisi -= 1;
                        }
                        else
                        {
                            skip_ram = true;
                        }

                    }
                }

                if (i >= 11 && i <= 14)
                {
                    if (!PlayerPrefs.GetString("level" + level + "_" + "vga" + "_" + i).Equals(""))
                    {
                        if (!skip_vga && (Resources.Load("Komponen/" + PlayerPrefs.GetString("level" + level + "_" + "vga" + "_" + i)) as GameObject).GetComponent<komponen_toko>().graphic_card)
                        {
                            slot_vga_terisi -= 1;
                        }
                        else
                        {
                            skip_vga = true;
                        }

                    }
                }
            }

            if (slot_hardisk_terisi == 6 || skip_hardisk)
            {
                detail_kesalahan_pokok += "- Slot Hardisk\n";
            }

            if (slot_ram_terisi == 4 || skip_ram)
            {
                detail_kesalahan_pokok += "- Slot RAM\n";

            }

            if (slot_vga_terisi == 4 || skip_vga)
            {
                detail_kesalahan_pokok += "- Slot Graphic Card\n";

            }
        }
        

        if(!detail_kesalahan_pokok.Equals(""))
        {
            text_hasil.SetText("Level Gagal :(");
            detail_kesalahan_pokok = "Beberapa slot tidak sesuai dengan komponen yang seharusnya : \n" + detail_kesalahan_pokok;
            text_detail.SetText(detail_kesalahan_pokok);
        }
        else
        {
            if(PlayerPrefs.GetInt("level" + level + "_mobo") != 0)
            {
                if(level == 1)
                {
                    level1_cek();
                }

                if(level == 2)
                {
                    level2_cek();
                }

                if(level == 3)
                {
                    level3_cek();
                }
            }
            else
            {
                text_hasil.SetText("Level Gagal :(");
                text_detail.SetText("Motherboard tidak tersedia");
            }
            
        }
    }

    public void level1_cek()
    {
        text_hasil.SetText("Level Berhasil ^_^");
        string detail =    "- Motherboard (Terpasang)\n" +
                                "- Processor (Terpasang)\n" +
                                "- Hardisk (Terpasang)\n" +
                                "- RAM (Terpasang)\n" +
                                "- Graphic Card (Terpasang)";
        text_detail.SetText(detail);
    }

    public void level2_cek()
    {

    }

    public void level3_cek()
    {

    }
}
