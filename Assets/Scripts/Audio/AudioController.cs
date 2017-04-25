using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioSource audio_source;
    public AudioClip explosion;
    public AudioClip enemyDeath;
    public AudioClip playerDeath;
    public AudioClip playerRespawn;



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

    public void playerDeathAudio()
    {
        audio_source.clip = playerDeath;
        GetComponent<AudioSource>().Play();
    }

    public void playerRespawnAudio()
    {
        audio_source.clip = playerRespawn;
        GetComponent<AudioSource>().Play();
    }

    void Awake()
    {
        GameObject stopMusic = GameObject.FindGameObjectWithTag("music");
        Destroy(stopMusic);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
