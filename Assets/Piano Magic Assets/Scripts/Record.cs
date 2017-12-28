using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record : MonoBehaviour {

    public Material[] materials;

    private Renderer rend;
    private bool recording;
    // Use this for initialization
    void Awake () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        recording = false;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        GameManager.instance.Record();
        if (recording == false)
        {
            recording = true;
            if (materials.Length > 0)
            {
                rend.sharedMaterial = materials[1];
            }
            return;
        }
        if (recording == true)
        {
            recording = false;
            if (materials.Length > 0)
            {
                rend.sharedMaterial = materials[0];
            }
            return;
        }
    }
}
