using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBGM : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] bgms = GameObject.FindGameObjectsWithTag("BGM");
        Debug.Log(bgms[0].name);
        if (bgms.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
}
