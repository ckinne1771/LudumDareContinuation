using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {

	public float speed = 10.0f;
	public float jumpPower = 20.0f;

	private bool jump = false;
	private bool doubleJump = false;

	public static bool facingRight;
	// Use this for initialization
	void Start () {
		facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.D)) {
			Debug.Log (facingRight.ToString ());
			facingRight = true;
			float newX = transform.position.x + (1.0f * speed * Time.deltaTime);
			transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
		}
		if (Input.GetKey (KeyCode.A)) {
			Debug.Log (facingRight.ToString ());
			facingRight = false;
			float newX = transform.position.x - (1.0f * speed * Time.deltaTime);
			transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
		}

		if(Input.GetKeyDown(KeyCode.W))
		   {
			//Debug.Log ("Phase 1");
			Debug.Log (jump.ToString ());
			if (jump == false)
			{
				//Debug.Log ("Phase 2");
				Jumping ();
				//gameObject.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up*jumpPower*Time.deltaTime);
				jump = true;
			}
			else if( jump == true && doubleJump == false)
			{
				//Debug.Log ("Phase 3");
				Jumping ();
				//gameObject.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up*jumpPower*Time.deltaTime);
				doubleJump = true;
			}


	}
}

	void OnCollisionEnter2D( Collision2D other)
	{
		if (other.gameObject.tag == "Floor") {
			jump = false;
			doubleJump = false;
		}
	}

	void Jumping()
	{
		Debug.Log("Jumping");
		gameObject.GetComponent<Rigidbody2D> ().AddForce (gameObject.transform.up * jumpPower * speed);

}
}
