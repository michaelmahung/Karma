using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public static GameObject player;
	public AudioSource touchPlayer;
	public AudioClip touchSound;
	public AudioClip blockSound;
	public static Vector3 leftPosition;
	public static Vector3 middlePosition;
	public static Vector3 rightPosition;
	public static Vector3 left2Position;
	public static Vector3 middle2Position;
	public static Vector3 right2Position;
	public BoxCollider2D boxCol;
	public static bool doubledLanes;

	void Start ()
	{
		player = GameObject.Find ("Player");
		//player.transform.position = middlePosition;
		doubledLanes = false;
		leftPosition = new Vector3 (-6, -4.25f, 0);
		middlePosition = new Vector3 (0, -4.25f, 0);
		rightPosition = new Vector3 (6, -4.25f, 0);
		left2Position = new Vector3 (-6, -2.25f, 0);
		middle2Position = new Vector3 (0, -2.25f, 0);
		right2Position = new Vector3 (6, -2.25f, 0);
		touchPlayer = GetComponent<AudioSource> ();
		touchPlayer.volume = 0.08f;
	}
		

	void OnMouseDown()
	{

		/*touchPlayer.clip = touchSound;
		touchPlayer.Play ();*/
		PlayerHealth.tailgating = false;
		PlayerHealth.murderTrail = false;

		if (ArrowKeyMovement.canMove && this.gameObject.name == "Left1") 
		{

			ArrowKeyMovement.currentLerpTime = 0;
			ImpactManager.currentFrameTime = 0;

			if (ArrowKeyMovement.lastPosition == ArrowKeyMovement.l) {
				touchPlayer.clip = blockSound;
				touchPlayer.Play ();
				ArrowKeyMovement.variableScale = ArrowKeyMovement.blockedScale;
				//Debug.Log ("Transform is " + player.transform.localScale);
				//ArrowKeyMovement.scalingFramesLeft = 10;
			} else { 
				touchPlayer.clip = touchSound;
				touchPlayer.Play ();
				ArrowKeyMovement.variableScale = ArrowKeyMovement.smallScale;
				//Debug.Log ("Transform is " + player.transform.localScale);
				//ArrowKeyMovement.scalingFramesLeft = 10;
			}
			player.transform.position = leftPosition;
			ArrowKeyMovement.lastPosition = ArrowKeyMovement.l;
		}

		if (ArrowKeyMovement.canMove && this.gameObject.name == "Mid1") 
		{

			ArrowKeyMovement.currentLerpTime = 0;
			ImpactManager.currentFrameTime = 0;

			if (ArrowKeyMovement.lastPosition == ArrowKeyMovement.m) {
				touchPlayer.clip = blockSound;
				touchPlayer.Play ();
				ArrowKeyMovement.variableScale = ArrowKeyMovement.blockedScale;
				//ArrowKeyMovement.scalingFramesLeft = 10;
			} else { 
				touchPlayer.clip = touchSound;
				touchPlayer.Play ();
				ArrowKeyMovement.variableScale = ArrowKeyMovement.smallScale;
				//ArrowKeyMovement.scalingFramesLeft = 10;
			}
			player.transform.position = middlePosition;
			ArrowKeyMovement.lastPosition = ArrowKeyMovement.m;
		}

		if (ArrowKeyMovement.canMove && this.gameObject.name == "Right1") 
		{

			ArrowKeyMovement.currentLerpTime = 0;
			ImpactManager.currentFrameTime = 0;

			if (ArrowKeyMovement.lastPosition == ArrowKeyMovement.r) {
				touchPlayer.clip = blockSound;
				touchPlayer.Play ();
				ArrowKeyMovement.variableScale = ArrowKeyMovement.blockedScale;
				//ArrowKeyMovement.scalingFramesLeft = 10;
			} else { 
				touchPlayer.clip = touchSound;
				touchPlayer.Play ();
				ArrowKeyMovement.variableScale = ArrowKeyMovement.smallScale;
				//ArrowKeyMovement.scalingFramesLeft = 10;
			}
			player.transform.position = rightPosition;
			ArrowKeyMovement.lastPosition = ArrowKeyMovement.r;
		}

		if (ArrowKeyMovement.canMove && this.gameObject.name == "Right2") 
		{

			ArrowKeyMovement.currentLerpTime = 0;
			ImpactManager.currentFrameTime = 0;

			if (ArrowKeyMovement.lastPosition == ArrowKeyMovement.r2) {
				touchPlayer.clip = blockSound;
				touchPlayer.Play ();
				ArrowKeyMovement.variableScale = ArrowKeyMovement.blockedScale;
				//ArrowKeyMovement.scalingFramesLeft = 10;
			} else { 
				touchPlayer.clip = touchSound;
				touchPlayer.Play ();
				ArrowKeyMovement.variableScale = ArrowKeyMovement.smallScale;
				//ArrowKeyMovement.scalingFramesLeft = 10;
			}
			player.transform.position = right2Position;
			ArrowKeyMovement.lastPosition = ArrowKeyMovement.r2;
		}

		if (ArrowKeyMovement.canMove && this.gameObject.name == "Mid2") 
		{

			ArrowKeyMovement.currentLerpTime = 0;
			ImpactManager.currentFrameTime = 0;

			if (ArrowKeyMovement.lastPosition == ArrowKeyMovement.m2) {
				touchPlayer.clip = blockSound;
				touchPlayer.Play ();
				ArrowKeyMovement.variableScale = ArrowKeyMovement.blockedScale;
				//ArrowKeyMovement.scalingFramesLeft = 10;
			} else { 
				touchPlayer.clip = touchSound;
				touchPlayer.Play ();
				ArrowKeyMovement.variableScale = ArrowKeyMovement.smallScale;
				//ArrowKeyMovement.scalingFramesLeft = 10;
			}
			player.transform.position = middle2Position;
			ArrowKeyMovement.lastPosition = ArrowKeyMovement.m2;
		}

		if (ArrowKeyMovement.canMove && this.gameObject.name == "Left2") 
		{

			ArrowKeyMovement.currentLerpTime = 0;
			ImpactManager.currentFrameTime = 0;

			if (ArrowKeyMovement.lastPosition == ArrowKeyMovement.l2) {
				touchPlayer.clip = blockSound;
				touchPlayer.Play ();
				ArrowKeyMovement.variableScale = ArrowKeyMovement.blockedScale;
				//ArrowKeyMovement.scalingFramesLeft = 10;
			} else { 
				touchPlayer.clip = touchSound;
				touchPlayer.Play ();
				ArrowKeyMovement.variableScale = ArrowKeyMovement.smallScale;
				//ArrowKeyMovement.scalingFramesLeft = 10;
			}
			player.transform.position = left2Position;
			ArrowKeyMovement.lastPosition = ArrowKeyMovement.l2;
		}


		//playerObject.transform.position = this.transform.position;
		if (Spawner.healTime && PlayerHealth.currentHealth < PlayerHealth.startingHealth && ArrowKeyMovement.canMove)
		{
			PlayerHealth.currentHealth += 3;
			if (PlayerHealth.currentHealth < 75 && PlayerHealth.currentHealth > 50) 
			{
				if (levelManager.whiteLevel) {

				} else {
					ScoreManager.currentScore = ScoreManager.currentScore * 0.995f;
				}

				
			}

			if (PlayerHealth.currentHealth > 75) 
			{
				if (levelManager.whiteLevel) {

				} else {
					ScoreManager.currentScore = ScoreManager.currentScore * 0.985f;
				}
			}
			//ScoreManager.pointLoss = ScoreManager.originalScore - ScoreManager.currentScore;
		}
	}

	public void Update ()
	{

		if (HorizontalSpawner.horiSpawning) {
			doubledLanes = true;
		}

		if (HorizontalSpawner.horiSpawning) {
			doubledLanes = false;
		}

		if (PlayerHealth.isDead) 
		{
			this.boxCol.enabled = false;	
			//this.circCollider.enabled = false;
		}

		if (doubledLanes) 
		{
			if (this.boxCol.name == "Right1") {
				this.boxCol.offset = new Vector2 (0.65f, -4);
				this.boxCol.size = new Vector2 (7.3f, 2);
			}

			if (this.boxCol.name == "Mid1") {
				this.boxCol.offset = new Vector2 (0f, -4);
				this.boxCol.size = new Vector2 (6, 2);
			}

			if (this.boxCol.name == "Left1") {
				this.boxCol.offset = new Vector2 (-0.63f, -4);
				this.boxCol.size = new Vector2 (7.26f, 2);
			}
		}

		if (!doubledLanes) 
		{
			if (this.boxCol.name == "Right1") {
				this.boxCol.offset = new Vector2 (0.65f, -1);
				this.boxCol.size = new Vector2 (7.3f, 8);
			}

			if (this.boxCol.name == "Mid1") {
				this.boxCol.offset = new Vector2 (0, -1);
				this.boxCol.size = new Vector2 (6, 8);
			}

			if (this.boxCol.name == "Left1") {
				this.boxCol.offset = new Vector2 (-0.63f, -1);
				this.boxCol.size = new Vector2 (7.26f, 8);
			}
		}


	}
		
		
}
