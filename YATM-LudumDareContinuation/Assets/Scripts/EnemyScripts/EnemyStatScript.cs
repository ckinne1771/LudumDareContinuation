using UnityEngine;
using System.Collections;

public class EnemyStatScript : MonoBehaviour {


	public int health;
	public int speed;
	public int attack;

	private Vector3 playerPosition;

	// Use this for initialization
	void Start () {
	
		//playerPosition = new Vector3 (GameObject.Find ("Player").transform.position.x, GameObject.Find ("Player").transform.position.y, GameObject.Find ("Player").transform.position.z);

	}
	
	// Update is called once per frame
	void Update () {
		playerPosition = new Vector3 (GameObject.Find ("Player").transform.position.x, GameObject.Find ("Player").transform.position.y, GameObject.Find ("Player").transform.position.z);
		//Debug.Log (playerPosition.ToString ());

		RaycastHit2D hitLeft = Physics2D.Raycast (transform.position, Vector2.left);
		RaycastHit2D hitRight = Physics2D.Raycast (transform.position, Vector2.right);
		if (hitLeft.collider != null) {
			//Debug.Log ("hit");
			float distance = Mathf.Abs (hitLeft.point.x - transform.position.x);
			Debug.Log (distance.ToString ());
			if (distance <= 3.0f  && hitLeft.collider.tag=="Player") {

				//transform.LookAt (new Vector3 (playerPosition.x, transform.position.y, transform.position.z));
				transform.Translate (Vector3.left * speed * Time.deltaTime);
			}
		}
		if (hitRight.collider != null) {
			float distance = Mathf.Abs (hitLeft.point.x - transform.position.x);
			if (distance <= 3.0f && hitRight.collider.tag=="Player") {
				
				//transform.LookAt (new Vector3 (playerPosition.x, transform.position.y, transform.position.z));
				transform.Translate (Vector3.right * speed * Time.deltaTime);
			}
		}

	}
}
