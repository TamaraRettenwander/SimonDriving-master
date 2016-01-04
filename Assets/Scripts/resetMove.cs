using UnityEngine;
using System.Collections;

public class resetMove : MonoBehaviour {

	void OnTriggerEnter(Collider col) 
	{
		if (col.gameObject.tag == "Resetter") 
		{
			col.transform.position = new Vector3(col.transform.position.x, col.transform.position.y, col.transform.position.z + 40 *4);
		}
		if(col.gameObject.tag == "Vehicle")
		{
			Destroy(col.gameObject);
		}



	}

}
