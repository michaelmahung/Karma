using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public static float startingHealth = 100;
	public static float currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	private float flashSpeed = 2f;
	public Color hurtColor = new Color (1f, 0f, 0f, 1f);
	public Color healColor = new Color (0f, 255f, 0f, 1f);
	public Color playerHurt = new Color();
	public Color playerHeal = new Color();
	public GameObject playerObject;
	public static float dps = 2f;
	public static float mdps;
	public static float osdps;
	public float healthPercent;
	public Image sliderFill;
	public static Color dynamicPlayerColor;
	public static bool isDead = false;
	public static SpriteRenderer playerColor;
	public static float deathCount;
	public bool deathCounted = false;
	public static SphereCollider playerCol;
	public static Color startColor;
	public static Color endColor;
	public static float faderValue;
	public static bool canHurt;
	public static bool damaged;
	public static bool healing;
	public static bool corrupt;
	public static bool tailgating;
	public static bool murdered;
	public static bool murderTrail;
	public static float healthPer;
	public static float tgpl;
	public static float mtpl;
	public TrailRenderer playerTrail;
	public static bool osTrail;
	public static bool oneShot;
	public bool finalHope;


	public MonoBehaviour arrowKeyMovement;

	void Awake ()
	{
		if (FileBasedPrefs.HasKey ("Death Count")) 
		{
			deathCount = FileBasedPrefs.GetFloat ("Death Count");
		}
	}

	void Start ()
	{
		deathCounted = false;
		finalHope = false;
		canHurt = true;
		startingHealth = 100;
		healthPercent = (currentHealth / startingHealth * 100); 
		healthSlider.minValue = 0;
		healthSlider.maxValue = startingHealth;
		healthSlider.value = currentHealth;
		currentHealth = startingHealth;
		arrowKeyMovement = GetComponent<ArrowKeyMovement> ();
		playerColor = GetComponent<SpriteRenderer> ();
		playerCol = GetComponent <SphereCollider> ();
		isDead = false;
		tailgating = false;
		murderTrail = false;
		healing = false;
		damaged = false;
		murdered = false;
		corrupt = false;
		osTrail = false;
		faderValue = 0f;
	}
		
	void Update ()
	{

		if (levelManager.whiteLevel && Spawner.hardMode && !finalHope && !PlayerHealth.isDead && !ScoreManager.gameWinner) {
			Debug.Log ("Last Hope Commencing!");
			finalHope = true;
			StartCoroutine (lastHope ());
		}

		if (PlayerHealth.isDead && finalHope || ScoreManager.gameWinner && finalHope) {
			finalHope = false;
			Debug.Log ("Stopping Last Hope!");
			StopAllCoroutines ();
		}

		healthPer = (currentHealth / startingHealth) * 100f;

		playerColor.color = Color.Lerp(startColor, endColor, faderValue);

		playerTrail.startColor = playerColor.color;
		playerTrail.endColor = playerColor.color;

		healthSlider.value = currentHealth;

		healthPercent = (currentHealth / startingHealth * 100);

		if (currentHealth > startingHealth)
		{
			currentHealth = startingHealth;
		}

		if (currentHealth <= 0 && !isDead) 
		{
			//Debug.Log ("Player is dead!");
			Death ();
			isDead = true;
		}

		if (healthPercent >= 60) {
			sliderFill.color = Color.green;
		}

		if (healthPercent < 60 && healthPercent >= 30) {
			sliderFill.color = Color.yellow;
		}
		if (healthPercent < 30 && healthPercent > 5) {
			sliderFill.color = Color.red;
		}
		if (healthPercent <= 5 && healthPercent > 0) {
			sliderFill.color = Color.magenta;
		}
		if (healthPercent <= 0) {
			sliderFill.color = Color.gray;
		}
		
		if (damaged)  {
			CollisionSFX.isHurting = true;
			ScreenShaker.shake = 0.5f;
			playerColor.color = playerHurt;
			damageImage.color = hurtColor;

		} 

		if (!damaged)
		{
			CollisionSFX.isHurting = false;
			damaged = false;
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
			playerColor.color = playerColor.color;
		}

		if (oneShot) {
			CollisionSFX.isOneShot = true;
			ScreenShaker.shake = 2.5f;
		} else {
			CollisionSFX.isOneShot = false;
		}

		if (murdered) {

			CollisionSFX.isMurder = true;
			ScreenShaker.shake = 2.5f;
			playerColor.color = playerHeal;
			damageImage.color = hurtColor;

		} else {
			CollisionSFX.isMurder = false;
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
			playerColor.color = playerColor.color;
		}



		if (healing)  {

			CollisionSFX.isHealing = true;
			ScreenShaker.shake = 0;
			playerColor.color = playerHeal;
			damageImage.color = healColor;

		} else {
			CollisionSFX.isHealing = false;
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
			playerColor.color = playerColor.color;
		}
		healing = false;

		if (isDead == (true) && !deathCounted)
		{
			MenuButtons.totalDeaths = MenuButtons.totalDeaths + 1;
			deathCount = deathCount + 1;
			//FileBasedPrefs.SetFloat ("Death Count", deathCount);
			//FileBasedPrefs.SetFloat ("Total Deaths", MenuButtons.totalDeaths);
			deathCounted = true;
		}
			
	}

	IEnumerator lastHope ()
	{
		yield return new WaitForSeconds (5);
		currentHealth += 5;
		StartCoroutine (lastHope ());
	}

	public void Death ()
		{
		Spawner.speedChange = false;
		HorizontalSpawner.spawnsLeft = 0;
		Powerups.coinTime = 0;
		ArrowKeyMovement.canPause = false;
		oneShot = false;
		murdered = false;
		healing = false;
		damaged = false;
		corrupt = false;
		sceneManager.adWatched = false;
		isDead = true;
		sceneManager.heartsLeft -= 1;
		//FileBasedPrefs.SetFloat ("Continues", sceneManager.heartsLeft);
		//FileBasedPrefs.SetFloat ("Game Time", timeManager.gameTime);
		playerCol.enabled = false;
		arrowKeyMovement.enabled = false;
		} 

	void OnTriggerExit (Collider other) 
	{
		if (other.tag == "Danger")
		{
			ArrowKeyMovement.canPause = true;
			damaged = false;
		}

		if (other.tag == "Murder") 
		{
			ArrowKeyMovement.canPause = true;
			murdered = false;
		}

		if (other.tag == "Tailgating") 
		{
			tailgating = false;
		}

		if (other.tag == "Healing")
		{
			ScoreManager.hpps = 0;
			healing = false;
		}

		if (other.tag == "Murder Trail") 
		{
			murderTrail = false;
		}

		if (other.tag == "Corruption") 
		{
			ArrowKeyMovement.canPause = true;
			corrupt = false;
		}

		if (other.tag == "One Shot Trail") 
		{
			osTrail = false;
		}

		if (other.tag == "One Shot") 
		{
			ArrowKeyMovement.canPause = true;
			oneShot = false;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "One Shot") 
		{
			ArrowKeyMovement.canPause = false;
			oneShot = true;
			currentHealth = currentHealth - 25;
			Destroy (other.gameObject);
			oneShot = false;
		}

		if (other.tag == "Block Hit") 
		{
			currentHealth = currentHealth - 4f;
			Destroy (other.GetComponent<Collider>());
		}

		if (other.tag == "Murder Hit") 
		{
			currentHealth = currentHealth - 6f;
			Destroy (other.GetComponent<Collider>());
		}
			
	}
		

	void OnTriggerStay(Collider other) {
		
		if (other.tag == "Tailgating") 
		{
			tailgating = true;
		}

		if (other.tag == "One Shot Trail") 
		{
			osTrail = true;
		}
			

		if (other.tag == "Danger") 
		{
			ArrowKeyMovement.canPause = false;

			if (Spawner.hardMode) 
			{
				ScoreManager.tailgateBonus = ScoreManager.tailgateBonus * tgpl;
			} 

			if (!Spawner.hardMode) 
			{
				ScoreManager.tailgateBonus = 0f;
			}
			damaged = true;
			currentHealth = currentHealth - (1 * dps);
			ScoreManager.healPoints = 0;
		} 

		if (other.tag == "Murder") {
			ArrowKeyMovement.canPause = false;
			murdered = true;
			ScoreManager.tailgateBonus = ScoreManager.tailgateBonus * mtpl;
			currentHealth = currentHealth - (mdps * dps);
		}

			if (other.tag == "Healing") {
				healing = true;
				if (healing == true) 
			{
				if (levelManager.whiteLevel && currentHealth < startingHealth) {
					currentHealth += 0.1f;
				}
				ScoreManager.hpps = 20;
				ScoreManager.healPoints = ScoreManager.healPoints += (ScoreManager.hpps * Time.deltaTime) * (ScoreManager.scoreMultiplier) * (Spawner.spawnSpeedMultiplier);
			}

			}

		if (other.tag == "Murder Trail") 
		{
			murderTrail = true;
		}

	}
		
		
}
