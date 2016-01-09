using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {



	public GameObject player;
	public GameObject[] obstacles;
	public GameObject[] spawnPoints;

	//public Transform[] spawnPointsCoin; //Coin

	public GameObject coin; //Coin


	private float spawnTime = 5.0f; //Coin



	private Vector3 offset;
	private int randomVehicleNumber;
	private int randomSpawnPointNumber;
	private Vector3 lookingdirection;
	private Vector3 coinSpawn;

	void Start()
	{
		InvokeRepeating ("SpawnCoins", spawnTime, spawnTime); //Coin

		offset = transform.position - player.transform.position;
		Instantiate (obstacles[randomVehicleNumber], spawnPoints[0].transform.position, Quaternion.LookRotation(Vector3.right));
		Instantiate (obstacles[randomVehicleNumber], spawnPoints[1].transform.position, Quaternion.LookRotation(Vector3.right));
		Instantiate (obstacles[randomVehicleNumber], spawnPoints[2].transform.position, Quaternion.LookRotation(Vector3.left));
		Instantiate (obstacles[randomVehicleNumber], spawnPoints[3].transform.position, Quaternion.LookRotation(Vector3.left));
		StartCoroutine (SpawnCar());
	}

	void SpawnCoins() //Coin

	{
		int spawnIndex = Random.Range (0, spawnPoints.Length);
		coinSpawn = new Vector3 (spawnPoints [spawnIndex].transform.position.x, coin.transform.position.y, spawnPoints [spawnIndex].transform.position.z);

		Instantiate (coin,coinSpawn,Quaternion.identity);

	}



	IEnumerator SpawnCar() 
	{
		yield return new WaitForSeconds (2);

		randomVehicleNumber = Random.Range(0, obstacles.Length);
		randomSpawnPointNumber = Random.Range(0, spawnPoints.Length);

		switch(randomSpawnPointNumber)
		{
			case 0: 
			case 1: lookingdirection = Vector3.right; break;
			case 2:
			case 3: lookingdirection = Vector3.left; break;
		}

		Instantiate (obstacles[randomVehicleNumber], spawnPoints[randomSpawnPointNumber].transform.position, Quaternion.LookRotation(lookingdirection));

		StartCoroutine (SpawnCar());

	}

	void LateUpdate() 
	{
		transform.position = new Vector3(2.5f , player.transform.position.y, player.transform.position.z) + offset;

	}
}
