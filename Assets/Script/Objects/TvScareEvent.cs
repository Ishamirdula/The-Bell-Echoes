using UnityEngine;
using System.Collections;

public class TvScareEvent : MonoBehaviour {

	public Texture2D noiseTexture;
	public Texture2D scareTexture;
	public AudioClip noiseSound;
	public AudioClip scareSound;
	public float scareTime = 3f;
	
	bool showScare = false; //private bool showscare
	
	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			// GetComponent<Renderer>().material.mainTexture = scareTexture;
			GetComponent<Renderer>().material.SetTexture("_BaseMap", scareTexture);
			GetComponent<AudioSource>().Stop();
			GetComponent<AudioSource>().loop = false;
			GetComponent<AudioSource>().clip = scareSound;
			GetComponent<AudioSource>().Play();
			
			showScare = true;
		}
	}
	
	void Update () 
	{
		if(showScare)
		{
			scareTime -= Time.deltaTime;
			if(scareTime <= 0)
			{
				// GetComponent<Renderer>().material.mainTexture = noiseTexture;
				GetComponent<Renderer>().material.SetTexture("_BaseMap", noiseTexture);
				GetComponent<AudioSource>().Stop();
				GetComponent<AudioSource>().loop = true;
				GetComponent<AudioSource>().clip = noiseSound;
				GetComponent<AudioSource>().Play();
				
				showScare = false;
			}
		}
	}
}
