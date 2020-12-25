using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera_rakit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 1.8f, 5);
    }
}
