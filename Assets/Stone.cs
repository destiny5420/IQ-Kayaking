using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

	private void OnCollisionEnter2D(Collision2D other) {
		
		Debug.Log("here1");
		if (other.gameObject.name == "Group_Potato")
		{
			Debug.Log("here2");

			var rand = Random.Range(0, 2);

			if (rand == 1)
				other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y + 0.5f, other.gameObject.transform.position.z);
				// other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 100);
			else
				other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y - 0.5f, other.gameObject.transform.position.z);
				// other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);
		}
	}
}
