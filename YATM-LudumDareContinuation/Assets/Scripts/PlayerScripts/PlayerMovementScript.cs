using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {

	public float speed = 10.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.D)) {
			float newX = transform.position.x + (1.0f * speed * Time.deltaTime);
			transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
		}
		if (Input.GetKey (KeyCode.A)) {
			float newX = transform.position.x - (1.0f * speed * Time.deltaTime);
			transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
		}
	}
}
