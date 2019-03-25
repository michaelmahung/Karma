using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingScript : MonoBehaviour {

	//float fall = 0;
	public static float fallSpeed = 0.2f;
	public static float regSpeed = 0.2f;
	public static float hardSpeed = 0.2f;
	public static bool timeChange = false;
	public static float murderBase;
	public static float oneShotBase;
	public static float menuSpeed;
	public Scene thisScene;
	private bool inMenu;
	//public float timeCheck;

	void Start ()
	{
		thisScene = SceneManager.GetActiveScene ();
		oneShotBase = 5;
		menuSpeed = 0.05f;
	}
		
	void FixedUpdate () {

		transform.position += new Vector3 (0, -1, 0) * (fallSpeed);

		if (thisScene.name == "Main Menu") {
			inMenu = true;
			fallSpeed = menuSpeed;
		} else {inMenu = false;
		}

		ScoreManager.scaledBonus = murderBase * ScoreManager.increasedMult;
		ScoreManager.osScaled = oneShotBase * ScoreManager.increasedMult;

		if (Spawner.hardMode && !ArrowKeyMovement.paused && !Powerups.timeChanged && !inMenu) {
			fallSpeed = hardSpeed;
		} else {if (!ArrowKeyMovement.paused && !Powerups.timeChanged && !inMenu)
			{fallSpeed = regSpeed;}}

		if (levelManager.currentLevel == 1 && !ArrowKeyMovement.paused && !timeChange && !inMenu) 
		{
			PlayerHealth.dps = 1f;
			PlayerHealth.mdps = 3.15f;
			regSpeed = 0.135f;
			//fallSpeed = 0.135f;
			hardSpeed = 0.155f;
			murderBase = 2.5f;
			PlayerHealth.mtpl = 0.90f;
			PlayerHealth.tgpl = 0.98f;
		}

		if (levelManager.currentLevel == 2  && !ArrowKeyMovement.paused && !timeChange && !inMenu) 
		{
			PlayerHealth.dps = 1.05f;
			PlayerHealth.mdps = 3.25f;
			regSpeed = 0.14f;
			hardSpeed = 0.165f;
			murderBase = 2.5f;
			PlayerHealth.mtpl = 0.90f;
			PlayerHealth.tgpl = 0.975f;
		} 

		if (levelManager.currentLevel == 3  && !ArrowKeyMovement.paused && !timeChange && !inMenu) 
		{
			PlayerHealth.dps = 1.10f;
			PlayerHealth.mdps = 3.5f;
			regSpeed = 0.15f;
			hardSpeed = 0.175f;
			murderBase = 3;
			PlayerHealth.mtpl = 0.90f;
			PlayerHealth.tgpl = 0.96f;
		} 

		if (levelManager.currentLevel == 4  && !ArrowKeyMovement.paused && !timeChange && !inMenu) 
		{
			PlayerHealth.dps = 1.20f;
			PlayerHealth.mdps = 3.5f;
			regSpeed = 0.165f;
			if (!Spawner.speedOverride) 
			{
				hardSpeed = 0.180f;
			}
			murderBase = 3.5f;
			PlayerHealth.mtpl = 0.925f;
			PlayerHealth.tgpl = 0.95f;
		} 

		if (levelManager.currentLevel == 5  && !ArrowKeyMovement.paused && !timeChange && !inMenu)
		{
			PlayerHealth.dps = 1.40f;
			PlayerHealth.mdps = 3.5f;
			regSpeed = 0.18f;
			if (!Spawner.speedOverride) 
			{
				hardSpeed = 0.195f;
			}
			oneShotBase = 6;
			murderBase = 4;
			PlayerHealth.mtpl = 0.915f;
			PlayerHealth.tgpl = 0.925f;
		}

		if (levelManager.currentLevel == 6  && !ArrowKeyMovement.paused && !timeChange && !inMenu) 
		{
			PlayerHealth.dps = 1.40f;
			PlayerHealth.mdps = 3.5f;
			regSpeed = 0.185f;
			if (!Spawner.speedOverride) 
			{
				hardSpeed = 0.2f;
			}
			oneShotBase = 7;
			murderBase = 4.5f;
			PlayerHealth.mtpl = 0.910f;
			PlayerHealth.tgpl = 0.925f;
		} 

		if (levelManager.currentLevel == 7  && !ArrowKeyMovement.paused && !timeChange && !inMenu) 
		{
			PlayerHealth.dps = 1.4f;
			PlayerHealth.mdps = 3.5f;
			regSpeed = 0.190f;
			if (!Spawner.speedOverride) 
			{
				hardSpeed = 0.225f;
			}
			oneShotBase = 8;
			murderBase = 5;
			PlayerHealth.mtpl = 0.905f;
			PlayerHealth.tgpl = 0.925f;
		} 

		if (levelManager.currentLevel == 8  && !ArrowKeyMovement.paused && !timeChange && !inMenu) 
		{
			PlayerHealth.dps = 1.4f;
			PlayerHealth.mdps = 3.5f;
			if (!Spawner.speedChange) {
				regSpeed = 0.200f;
			}
			if (!Spawner.speedOverride) 
			{
				hardSpeed = 0.25f;
			}
			//fallSpeed = 0.2f;
			oneShotBase = 10;
			murderBase = 6;
			PlayerHealth.mtpl = 0.9f;
			PlayerHealth.tgpl = 0.925f;
		} 
			
		//fall = Time.time;
		
	}
}
