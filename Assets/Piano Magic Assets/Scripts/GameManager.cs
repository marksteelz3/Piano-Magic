using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public GameObject recNote;

    private bool recording = false;
    private bool playing = false;
    private float recordStart = 0;
    // Use this for initialization
    void Start () {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	public void Record () {
		if (recording == false)
        {
            recordStart = Time.realtimeSinceStartup;
            recording = true;
            return;
        }
        if (recording == true)
        {
            recordStart = 0;
            recording = false;
            return;
        }
    }

    public float GetRecordStart()
    {
        return recordStart;
    }

    public void RecordNote(Transform keyLoc, float relPos, float noteLength, float startPos)
    {
        if (recording == true)
        {
            GameObject noteStamp = Instantiate(recNote, keyLoc) as GameObject;
            noteStamp.transform.position = new Vector3(keyLoc.position.x + relPos*(0.025f), keyLoc.position.y, keyLoc.position.z + (startPos)/(4f) + 0.5f);
            //noteStamp.transform.localScale.z = noteStamp.transform.localScale.z*noteLength;
        }
    }

    public void PlayRecording()
    {
        if (playing == false)
        {
            playing = true;
            return;
        }
        if (playing == true)
        {
            playing = false;
            return;
        }
    }

    public bool isPlaying()
    {
        return playing;
    }
}
