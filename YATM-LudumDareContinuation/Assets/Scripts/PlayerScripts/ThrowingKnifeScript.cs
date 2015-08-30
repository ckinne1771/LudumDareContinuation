using UnityEngine;
using System.Collections;

public class ThrowingKnifeScript : MonoBehaviour {

	public float speed = 20.0f;

	Renderer renderer;
	private bool startRight = true;
	// Use this for initialization
	void Start () {
	if (Controller.facingRight == true) {
			startRight = true;
		}
	if(Controller.facingRight == false)
		{
			startRight = false;
		}

	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate (Vector2.left * speed * Time.deltaTime);
		if (startRight == true) {
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		}
		if (startRight == false) {
			transform.Translate (Vector2.left * speed * Time.deltaTime);
		}

	}

	public void moveLeft()
	{
		transform.Translate (Vector2.left * speed * Time.deltaTime);
	}

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}

}
