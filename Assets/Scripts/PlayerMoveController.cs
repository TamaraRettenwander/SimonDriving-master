using UnityEngine;
using System.Collections;

public class PlayerMoveController : MonoBehaviour {

	public float speed;
	public float dodgeSpeed;

	private GameObject controller;
	private Vector3 sidePosition;

	void Start() 
	{
		controller = GameObject.Find ("_GameController");
	}
	
	void Update () 
	{	
		if (controller.GetComponent<GameController> ().isRunning) 
		{
			transform.position += Vector3.forward * Time.deltaTime * speed;	

			float xAxis = Input.GetAxis ("Horizontal") * dodgeSpeed;
			sidePosition = new Vector3 (xAxis,0, 0);


				transform.Translate (sidePosition);
		}
	}

	void OnCollisionEnter(Collision col) 
	{
		print (col.gameObject.tag);
		
		if (col.gameObject.tag == "Bordstein") {
			controller.SendMessage ("FinishGame");
		} else if (col.gameObject.tag == "Coin")
		{ //Coin
			Destroy (col.gameObject); //Coin
			controller.SendMessage("AddToScore", 100);
		}


		
	
	}

}
