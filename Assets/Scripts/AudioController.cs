using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioSource audio_source;
    public AudioClip explosion;
    public AudioClip enemyDeath;

    public void explosionAudio()
    {
        audio_source.clip = explosion;
        GetComponent<AudioSource>().Play();
    }

    public void enemyDeathAudio()
    {
        audio_source.clip = enemyDeath;
        GetComponent<AudioSource>().Play();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
