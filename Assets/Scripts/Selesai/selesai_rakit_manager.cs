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
        PlayerPrefs.SetInt("level" + (level + 1) + "_terbuka", 1);
    }

    public void level2_cek()
    {
        bool gagal = false;
        int total_anggaran = PlayerPrefs.GetInt("level" + level + "_anggaran");
        int total_biaya = PlayerPrefs.GetInt("level" + level + "_biaya");
        int total_gb = 0;
        for (int i = 0; i < 15; i++)
        {
            if (i >= 1 && i <= 6)
            {
                if (!PlayerPrefs.GetString("level" + level + "_" + "hardisk" + "_" + i).Equals(""))
                {
                    if ((Resources.Load("Komponen/" + PlayerPrefs.GetString("level" + level + "_" + "hardisk" + "_" + i)) as GameObject).GetComponent<komponen_toko>().hardisk)
                    {
                        total_gb += (Resources.Load("Komponen/" + PlayerPrefs.GetString("level" + level + "_" + "hardisk" + "_" + i)) as GameObject).GetComponent<hardisk>().gb;
                    }
                }
            }
        }

        string hardisk_terpasang = "- Hardisk dengan ukuran > 500mb(Belum Terpasang)\n";

        if (total_gb > 500)
        {
            hardisk_terpasang = "- Hardisk dengan ukuran > 500mb(Terpasang)\n";
        }
        else
        {
            gagal = true;
        }

        string detail = "- Motherboard (Terpasang)\n" +
                                "- Processor (Terpasang)\n" +
                                hardisk_terpasang +
                                "- RAM (Terpasang)\n" +
                                "- Graphic Card (Terpasang)\n";

        if((total_anggaran - total_biaya >= 50))
        {
            detail += "- Sisakan anggaran minimal 100$ (Sudah terpenuhi)";
        }
        else
        {
            detail += "- Sisakan anggaran minimal 100$ (Belum terpenuhi)";
            gagal = true;
        }

        if (gagal)
        {
            text_hasil.SetText("Level Gagal :(");
        }
        else
        {
            text_hasil.SetText("Level Berhasil ^_^");
            PlayerPrefs.SetInt("level" + (level + 1) + "_terbuka", 1);
        }
        text_detail.SetText(detail);
    }

    public void level3_cek()
    {
        int total_anggaran = PlayerPrefs.GetInt("level" + level + "_anggaran");
        int total_biaya = PlayerPrefs.GetInt("level" + level + "_biaya");

        text_hasil.SetText("Level Gagal :(");
        bool gagal = false;
        int total_hardisk = 0;
        int total_ram = 0;
        int banyak_ram = 0;
       
        for (int i = 0; i < 15; i++)
        {
            if (i >= 1 && i <= 6)
            {
                if (!PlayerPrefs.GetString("level" + level + "_" + "hardisk" + "_" + i).Equals(""))
                {
                    if ((Resources.Load("Komponen/" + PlayerPrefs.GetString("level" + level + "_" + "hardisk" + "_" + i)) as GameObject).GetComponent<komponen_toko>().hardisk)
                    {
                        total_hardisk += (Resources.Load("Komponen/" + PlayerPrefs.GetString("level" + level + "_" + "hardisk" + "_" + i)) as GameObject).GetComponent<hardisk>().gb;
                    }
                }
            }

            if (i >= 7 && i <= 10)
            {
                if (!PlayerPrefs.GetString("level" + level + "_" + "ram" + "_" + i).Equals(""))
                {
                    if ((Resources.Load("Komponen/" + PlayerPrefs.GetString("level" + level + "_" + "ram" + "_" + i)) as GameObject).GetComponent<komponen_toko>().ram)
                    {
                        total_ram += (Resources.Load("Komponen/" + PlayerPrefs.GetString("level" + level + "_" + "ram" + "_" + i)) as GameObject).GetComponent<ram>().gb;
                        banyak_ram++;
                    }

                }
            }
        }

        string hardisk_terpasang = "- Hardisk dengan ukuran > 500 MB (Belum Terpasang)\n";
        string ram_terpasang = "- RAM dengan ukuran 8 GB (Belum Optimal)\n";
        string[] ram = new string[4];
        int pacuan = 0;

        if (total_hardisk >= 1000)
        {
            hardisk_terpasang = "- Hardisk dengan ukuran > 500 MB(Terpasang)\n";
        }
        else
        {
            gagal = true;
        }

        if(total_ram >= 8)
        {
            for(int i = 7; i <= 10; i++)
            {
                if((Resources.Load("Komponen/" + PlayerPrefs.GetString("level" + level + "_" + "ram" + "_" + i)) as GameObject) != null)
                {
                    ram[pacuan] = (Resources.Load("Komponen/" + PlayerPrefs.GetString("level" + level + "_" + "ram" + "_" + i)) as GameObject).name;
                }
                else
                {
                    ram[pacuan] = "";
                }
                pacuan++;
            }

            if(banyak_ram == 3)
            {
                gagal = true;
            }
            else
            {
                if(banyak_ram == 2)
                {
                    if( (!ram[0].Equals("") && ram[1].Equals("") && !ram[2].Equals("") && ram[3].Equals("")) || (ram[0].Equals("") && !ram[1].Equals("") && ram[2].Equals("") && !ram[3].Equals("")) )
                    {
                        ram_terpasang = "- RAM dengan ukuran 8 GB (Sudah Terpasang)\n";

                    }
                    else
                    {
                        gagal = true;
                    }

                }
                else
                {
                    if(banyak_ram == 1)
                    {
                        ram_terpasang = "- RAM dengan ukuran 8 GB (Sudah Terpasang)\n";
                    }
                }
            }
        }

        string anggaran = "- Sisakan anggaran minimal 100$ (Belum terpenuhi)";
        if ((total_anggaran - total_biaya >= 150))
        {
             anggaran = "- Sisakan anggaran minimal 100$ (Sudah terpenuhi)";
        }
        else
        {
            gagal = true;
        }

        if (!gagal)
        {
            text_hasil.SetText("Level Berhasil ^_^");
            PlayerPrefs.SetInt("level" + (level + 1) + "_terbuka", 1);
        }

        string detail = "- Motherboard (Terpasang)\n" +
                        "- Processor (Terpasang)\n" +
                        hardisk_terpasang +
                        ram_terpasang +
                        "- Graphic Card (Terpasang)\n" +
                        anggaran;

        text_detail.SetText(detail);
        for(int i =0; i < ram.Length; i++)
        {
            Debug.Log(ram[i]);

        }

    }
}
