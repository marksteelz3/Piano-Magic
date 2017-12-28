using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour {

    public Material[] materials;

    private Renderer rend;
    private bool playing;
    // Use this for initialization
    void Awake()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        playing = false;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (playing == false)
        {
            GameManager.instance.PlayRecording();
            playing = true;
            if (materials.Length > 0)
            {
                rend.sharedMaterial = materials[1];
            }
            return;
        }
        if (playing == true)
        {
            playing = false;
            if (materials.Length > 0)
            {
                rend.sharedMaterial = materials[0];
            }
            return;
        }
    }
}
