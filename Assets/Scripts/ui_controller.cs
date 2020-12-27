using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui_controller : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tutupUI(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void bukaUI(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void bukaScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
