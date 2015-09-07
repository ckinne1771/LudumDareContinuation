using UnityEngine;
using System.Collections;

public class EnemyStatScript : MonoBehaviour {


	public int health;
	public int speed;
	public int attack;

	private bool collision = false;
	private Vector3 playerPosition;

	// Use this for initialization
	void Start () {
	
		//playerPosition = new Vector3 (GameObject.Find ("Player").transform.position.x, GameObject.Find ("Player").transform.position.y, GameObject.Find ("Player").transform.position.z);

	}
	
	// Update is called once per frame
	void Update () {
		MoveObject ();
	}

	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log ("called");
		if(other.GetComponent<Collider2D>().tag == "Player")
		{

			collision = true;
			//Debug.Log ("entered");

		} 
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.GetComponent<Collider2D> ().tag == "Player") {
			collision = false;
		}
	}

	void MoveObject()
	{
		if (collision == true) {

			playerPosition = new Vector3 (GameObject.Find ("Player").transform.position.x, GameObject.Find ("Player").transform.position.y, GameObject.Find ("Player").transform.position.z);
			//Debug.Log (playerPosition.x - transform.position.x);
			if ((playerPosition.x - transform.position.x) < 0) {
				//Debug.Log("Entered");
				transform.parent.Translate (Vector2.left * speed * Time.deltaTime);
			}
		
			if ((playerPosition.x - transform.position.x) > 0) {
				transform.parent.Translate (Vector2.right * speed * Time.deltaTime);
			}
		}
	}

}