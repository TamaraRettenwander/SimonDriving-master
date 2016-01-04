using UnityEngine;
using System.Collections;

public class VehicleMove : MonoBehaviour 
{
	
	public float speed;

	private GameObject controller;
	private float randomValue;

	void Start() 
	{
		randomValue = Random.Range (0.5f, 1.5f);
		controller = GameObject.Find ("_GameController");

	}

	void Update () 
	{
		transform.Translate (Vector3.left * Time.deltaTime * speed * randomValue);
	}

	void OnCollisionEnter(Collision col) 
	{
		print (col.gameObject.tag);

		if (col.gameObject.tag == "Player") 
		{
			controller.SendMessage("FinishGame");
		}
	}
}
