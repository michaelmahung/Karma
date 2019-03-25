using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerups : MonoBehaviour {

	public AudioSource powerupSounds;
	public AudioClip coinSound;
	public AudioClip slowSound;
	public AudioClip speedSound;
	public AudioClip corruptSound;
	public AudioClip missClip;
	public AudioClip doubleClip;
	public float slowMo;
	public float normTime;
	public float fastMo;
	public float slowWait;
	public float regWait;
	public float slowFall;
	public float regFall;
	public static bool timeChanged;
	public float coinValue;
	public float corruptionValue;
	public bool coinGot;
	public float corruptionTime;
	public static float coinTime;
	private IEnumerator coin;
	public Slider powerupSlider;
	public GameObject slider;
	public static bool murderOnly;
	public static float missBonus;
	public TextMesh bonusText;
	public GameObject textHolder;
	public Transform holderPosition;
	public bool canMiss;
	public float blockTime;
	public float horiScale;
	public static float horiMax;
	//public float minTimeScale = 0.5f;

	// Use this for initialization
	void Start () {
		horiScale = 2;
		canMiss = true;
		holderPosition = textHolder.transform;
		powerupSounds.volume = 0.7f;
		murderOnly = false;
		powerupSlider.minValue = 1;
		powerupSlider.maxValue = 10;
		coin = gotCoin ();
		coinGot = false;
		timeChanged = false;
		slider.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {

		if (blockTime > 0.25f) {
			blockTime = 0.25f;
		}

		if (coinTime > 10) {
			coinTime = 10;
		}

		if (horiScale > horiMax) {
			horiScale = horiMax;
		}

		if (PlayerHealth.damaged || PlayerHealth.murdered) {
			blockTime = 0.25f;
			if (canMiss) {
				StartCoroutine (missBlock ());
			} else {
			}
		}

		if (levelManager.currentLevel <= 5)
		{
			horiScale = 1;
			horiMax = 2;
		}

		if (levelManager.currentLevel >= 6) {
			horiScale = 2;
			horiMax = 3;
		}

		/*if (levelManager.currentLevel >= 7) {
			horiScale = 3;
			horiMax = 3;
		}*/

		missBonus = 5 * ScoreManager.increasedMult;

		powerupSlider.value = coinTime;
		powerupSlider.direction = Slider.Direction.BottomToTop;
		
		slowFall = FallingScript.regSpeed * 0.5f;
		regFall = FallingScript.regSpeed;
		slowWait = Spawner.currentTime * 2f;
		regWait = Spawner.currentTime;

		if (coinGot) {
			ScoreManager.multIncrease = 1.5f;
			//slider.SetActive (true);
		}

		if (!coinGot) {
			ScoreManager.multIncrease = 1;
			//slider.SetActive (false);
		}
	}
		
	IEnumerator gotCoin ()
	{
		//Debug.Log ("Coin!");
		while (coinTime > 0) 
		{
			coinGot = true;
			yield return new WaitForSeconds (1);
			coinTime -= 1;
			//Debug.Log ("Coin Time Left is: " + coinTime);
			//Debug.Log (coinGot);
		}

		if (coinTime <= 0)
		{
			coinGot = false;
			//Debug.Log (coinGot);
		}

	}

	IEnumerator Corrupted ()
	{
		//Debug.Log ("Corrupt!");
		while (corruptionTime > 0) {
			murderOnly = true;
			yield return new WaitForSeconds (1);
			corruptionTime -= 1;
		}

		if (corruptionTime <= 0) 
		{
			murderOnly = false;
		}

	}

	IEnumerator missBlock ()
	{
		while (blockTime > 0) 
		{
			canMiss = false;
			yield return new WaitForSeconds (0.25f);
			blockTime -= 1;
		}

		if (blockTime <= 0) 
		{
			canMiss = true;
		}
	}



	IEnumerator slowTime ()
	{
	Debug.Log ("Slowing Time");
	timeChanged = true;
	Time.timeScale = slowMo;
	Time.fixedDeltaTime = 0.02f * Time.timeScale;
	powerupSounds.clip = slowSound;
	powerupSounds.Play ();
	FallingScript.fallSpeed = slowFall;
	Spawner.waitTime = slowWait;
	BGMAudio.bgmAudio.pitch = 0.85f;
	yield return new WaitForSeconds (2);
	Debug.Log ("Back to Normal");
	Time.timeScale = normTime;
	Time.fixedDeltaTime = 0.02f * Time.timeScale;
	FallingScript.fallSpeed = regFall;
	Spawner.waitTime = regWait;
	BGMAudio.bgmAudio.pitch = 1f;
	timeChanged = false;
	Destroy (this.gameObject);
	yield break;	
	}
		

	void OnTriggerEnter (Collider other)
	{

		if (other.tag == "Doubler") {
			HorizontalSpawner.spawnsLeft += horiScale;
			powerupSounds.Stop ();
			powerupSounds.clip = doubleClip;
			powerupSounds.Play ();
			Destroy (other.gameObject);
		}



		if (other.tag == "Coin") {
			bonusText.text = "+3";
			Instantiate (bonusText, holderPosition);
			coinTime = coinTime + 3f;
			powerupSounds.Stop ();
			powerupSounds.clip = coinSound;
			powerupSounds.Play ();
			ScoreManager.tailgateBonus += coinValue;
			Destroy (other.gameObject);
			//thisImage.enabled = false;
			//thisCollider.enabled = false;

			if (coinGot) {
				/*StopCoroutine (coin);
				StartCoroutine (coin);
				Destroy (this.gameObject);*/
			}

			if (!coinGot) {
				//Debug.Log ("Starting Countdown");
				StartCoroutine (gotCoin ());
			}
		}

		if (other.tag == "Near Miss") {
			Destroy (other.GetComponent<Collider> ());
			if (canMiss) {
				StartCoroutine (missCheck ());
			} else {
			}


			if (coinGot) {
				/*StopCoroutine (coin);
				StartCoroutine (coin);
				Destroy (this.gameObject);*/
			}

			if (!coinGot) {
				//Debug.Log ("Starting Countdown");
				StartCoroutine (gotCoin ());
			}
		}

		if (other.tag == "Corruption") {
			PlayerHealth.corrupt = true;
			corruptionTime = 5f;
			powerupSounds.clip = corruptSound;
			powerupSounds.Play ();
			ScoreManager.currentScore += corruptionValue;
			PlayerHealth.corrupt = false;
			Destroy (other.gameObject);

			if (murderOnly) {

			}

			if (!murderOnly) {
				Debug.Log ("Corrupted");
				StartCoroutine (Corrupted ());

			}
		}
	}

		IEnumerator missCheck ()
	{
			yield return new WaitForSeconds (0.1f);

		if (canMiss && !PlayerHealth.isDead)
		{
			bonusText.text = "+1";
			Instantiate (bonusText, holderPosition);
			//Debug.Log ("Near Miss!");
			coinTime = coinTime + 1f;
			powerupSounds.Stop ();
			powerupSounds.clip = missClip;
			powerupSounds.Play ();
			//StartCoroutine (dodgeBonus());
			ScoreManager.tailgateBonus += missBonus;
			//PlayerHealth.currentHealth += 5f;
			StopCoroutine (missCheck());
		}

		if (!canMiss) 
		{
			StopCoroutine (missCheck ());
		}
			

	}


}
