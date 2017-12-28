using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPlay : MonoBehaviour {

    public AudioClip aud;
    public Material[] materials;
    public float relPos;
    //public GameObject recordNote;

    private Renderer rend;
    private AudioSource source;
    private Transform keyLoc;
    private float startTime;
    private float noteLength;
    /*
    
    private GameObject recNote;
    private bool recording;
    private float recordStart;
    
    
    */

    // Use this for initialization
    void Awake () {
        source = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        keyLoc = GetComponent<Transform>();
        /*
        recording = false;
        recordStart = 0;
        */
    }

    void OnTriggerEnter(Collider other)
    {
        /*
        if (key.tag == "Recorder")
        {
            if (recording == false)
            {
                recording = true;
                recordStart = Time.realtimeSinceStartup;
                if (materials.Length > 2)
                {
                    rend.sharedMaterial = materials[2];
                }
            }
            if (recording == true)
            {
                recording = false;
                recordStart = 0;
                if (materials.Length > 2)
                {
                    rend.sharedMaterial = materials[0];
                }
            }
        }
        */

        //source.Stop();
        source.PlayOneShot(aud, 1F);
        if (materials.Length > 0)
        {
            rend.sharedMaterial = materials[1];
        }
        startTime = Time.realtimeSinceStartup - GameManager.instance.GetRecordStart();
        noteLength = Time.realtimeSinceStartup;
    }

    
    void OnTriggerExit(Collider other)
    {
        noteLength = Time.realtimeSinceStartup - noteLength;
        GameManager.instance.RecordNote(keyLoc, relPos, noteLength, startTime);
        source.Stop();
        if (materials.Length > 0)
        {
            rend.sharedMaterial = materials[0];
        }

        
        //recNote.transform.localScale = new Vector3(noteLength,1,1);
        noteLength = 0;
        startTime = 0;
    }
    
}
