using UnityEngine;
using System.Collections;

public class TrackMove : MonoBehaviour {

	public float speed;
	Vector2 offset; //movement texture

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//SATU
		offset = new Vector2 (0, Time.time * speed);// time.time means equal to second, sync with second

		GetComponent<Renderer> ().material.mainTextureOffset = offset;
	}
}
