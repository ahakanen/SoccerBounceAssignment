using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
	public GameController gameController;

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Collision with " + other);
		Debug.Log("DEATH!");
		gameController.Death();
	}
}
