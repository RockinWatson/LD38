using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAudioController : MonoBehaviour {

    public AudioSource title_audio_source;
    public AudioClip space;

    public void TitleSpace()
    {
        title_audio_source.clip = space;
        GetComponent<AudioSource>().Play();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
