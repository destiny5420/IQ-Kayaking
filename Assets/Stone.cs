using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

	private void OnCollisionEnter2D(Collision2D other) {
		
		if (other.gameObject.name == "Group_Potato")
		{
			var rand = Random.Range(0, 2);
			
			if (rand == 1)
				other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 100);
			else
				other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);
		}
	}
}
