using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManifest : MonoBehaviour
{
    public GameObject Map;
    bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        Map = GameObject.Find("Map");
        Map.SetActive(false);
    }

    // Update is called once per frame
    public void OnPointerClick()
    {
        Manifest(isOpen);
        isOpen = !isOpen;
    }
    
    private void Manifest(bool isOpen)
    {
        if (isOpen)
            Map.SetActive(false);
        else
            Map.SetActive(true);

    }
}
