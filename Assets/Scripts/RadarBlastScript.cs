using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarBlastScript : MonoBehaviour
{
    [HideInInspector]public new ParticleSystem particleSystem;

	// Use this for initialization
	void Start ()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (Input.GetKeyDown("z") && particleSystem.isStopped)
        {
            particleSystem.Play();
        }
	}
}
