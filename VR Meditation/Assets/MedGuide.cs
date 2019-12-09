using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedGuide : MonoBehaviour {

    public AudioSource MusicSource;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MusicSource.Play();
        }
    }
}
