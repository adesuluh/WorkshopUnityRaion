using UnityEngine;
using System.Collections;

public class CarSpawner : MonoBehaviour {

	public GameObject[] cars;
	int index;
	public float spawnPos;

	public float delay;
	float timer;


	// Use this for initialization
	void Start () {
		//Vector3 carPos = new Vector3 (Random.Range(-spawnPos, spawnPos), transform.position.y, transform.position.z);

		//Instantiate (car, carPos, transform.rotation);
		timer = delay;
	}
	
	// Update is called once per frame
	void Update () {
		
		timer -= Time.deltaTime;// first willbe 1 then 1 second after is 0 then instantiate

		if(timer  <= 0) {
			Vector3 carPos = new Vector3 (Random.Range(-spawnPos, spawnPos), transform.position.y, transform.position.z);

			index = Random.Range (0,2);
			Instantiate (cars[index], carPos, transform.rotation);

			timer = delay;
		}


	}
}
