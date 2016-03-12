using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	public float carSpeed;
	Vector3 position;
	public float minPos;
	public float maxPos;

	public UIManager ui;


	// Use this for initialization
	void Start () {


		//ui = GetComponent<UIManager> ();
		position = transform.position;	
	}
	
	// Update is called once per frame
	void Update () {
		
		//DUA
		position.x += Input.GetAxis ("Horizontal") * carSpeed * Time.deltaTime;

		position.x = Mathf.Clamp (position.x, minPos, maxPos);

		transform.position = position; 


	}

	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.tag == "Enemy") {
			Destroy (gameObject);

			ui.GameOver ();
		}
	}
}
