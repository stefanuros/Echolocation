using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float camY;

    public GameObject player;
    private Camera cam;
	// Use this for initialization
	void Start ()
    {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        cam.transform.position = new Vector3(player.transform.position.x, camY,-10);
	}
}
