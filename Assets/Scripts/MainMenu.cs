using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button level2;
    public Button level3;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("level2_terbuka") == 1)
        {
            level2.interactable = true;
        }
        else
        {
            level2.interactable = false;
        }

        if (PlayerPrefs.GetInt("level3_terbuka") == 1)
        {
            level3.interactable = true;
        }
        else
        {
            level3.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadScene(string nama)
    {
        SceneManager.LoadScene(nama);
    }
}
