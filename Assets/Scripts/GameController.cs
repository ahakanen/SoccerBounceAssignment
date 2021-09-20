using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
	public GameObject football;
	public float forceMultiplier = 500;
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI gameOverText;
	public AudioSource hitSound;
	bool isDead = false;
	int score;
    // Start is called before the first frame update
    void Start()
    {
		InitGame();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
		{
			if (isDead == true)
			{
				InitGame();
				return;
			}
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 distance = mousePos - football.transform.position;
			if (distance.magnitude < 15)
			{
				Vector3 force = distance.magnitude * distance.normalized * forceMultiplier;
				football.GetComponent<Rigidbody2D>().AddForce(-force);
				score++;
				scoreText.text = "Score: " + score.ToString();
				hitSound.Play();
			}
		}
    }

	public void Death()
	{
		isDead = true;
		scoreText.text = "Score: " + score.ToString();
		gameOverText.gameObject.SetActive(true);
		//show score and show "touch to restart"
	}

	public void InitGame()
	{
		score = 0;
		scoreText.text = "Score: " + score.ToString();
		football.transform.position = Vector3.zero;
		isDead = false;
		gameOverText.gameObject.SetActive(false);
	}
}
