using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

    void Awake ()
    {
        GameObject[] musicPlayer = GameObject.FindGameObjectsWithTag("music");
        if (musicPlayer.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);


        GameObject[] endMusicPlayer = GameObject.FindGameObjectsWithTag("endMusic");
        if (endMusicPlayer.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
