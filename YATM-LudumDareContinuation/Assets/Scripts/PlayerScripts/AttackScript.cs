using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {

	public GameObject rangedSpawnLeft;
	public GameObject rangedSpawnRight;
	public GameObject throwingKnife;


	GameObject throwingKnifeClone;
	// Use this for initialization
	void Start () {
	
	} 
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse1)) {
			rangedAttack ();
		} 

	
	}

	void rangedAttack(){

		if (Controller.facingRight == false) {
			throwingKnifeClone = (Instantiate (throwingKnife, rangedSpawnLeft.transform.position, rangedSpawnLeft.transform.rotation)) as GameObject;
		}
		
		if (Controller.facingRight == true) {
			throwingKnifeClone = (Instantiate (throwingKnife, rangedSpawnRight.transform.position, rangedSpawnRight.transform.rotation)) as GameObject;
		}
	}
}
