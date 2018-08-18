using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartController : MonoBehaviour {

    private bool fart1() { return (Input.GetKeyDown(KeyCode.Alpha6)); }
    private bool fart2() { return (Input.GetKeyDown(KeyCode.Alpha7)); }
    private bool fart3() { return (Input.GetKeyDown(KeyCode.Alpha8)); }

    private float startVolume = .25f;

    [SerializeField]
    private AudioSource _fart1;
    [SerializeField]
    private AudioSource _fart2;
    [SerializeField]
    private AudioSource _fart3;

    // Use this for initialization
    void Awake () {
        InitFarts();

	}
	
	// Update is called once per frame
	void Update () {
        TriggerFarts();
    }

    private void InitFarts()
    {
        AudioSource[] farts = GetComponents<AudioSource>();
        farts[0] = _fart1;
        farts[1] = _fart2;
        farts[2] = _fart3;

        farts[0].playOnAwake = false;
        farts[1].playOnAwake = false;
        farts[2].playOnAwake = false;
        farts[0].loop = false;
        farts[1].loop = false;
        farts[2].loop = false;
        farts[0].volume = startVolume;
        farts[1].volume = startVolume;
        farts[2].volume = startVolume;
    }

    private void TriggerFarts()
    {
        if (fart1())
        {
            _fart1.Play();
        }
        if (fart2())
        {
            _fart2.Play();
        }
        if (fart3())
        {
            _fart3.Play();
        }

    }
}
