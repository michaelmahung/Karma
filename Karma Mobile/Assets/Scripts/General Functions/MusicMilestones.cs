using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMilestones : MonoBehaviour {

	public float musicMilestoneScore;
	public float firstMusicMilestone;
	public static float musicMilestone;
	public static bool mMilestoneSet;
	public static bool firstMilestoneReached;


	void Start () {

		musicMilestone = 1;
		mMilestoneSet = false;
		firstMilestoneReached = false;
		
	}

	void Update () {
			
			
		if (levelManager.currentLevel == 1) 
		{
			firstMusicMilestone = 200;
		}

		if (levelManager.currentLevel == 2) 
		{
			firstMusicMilestone = 750;
		}

		if (levelManager.currentLevel == 3) 
		{
			firstMusicMilestone = 2000;
		}

		if (levelManager.currentLevel == 4) 
		{
			firstMusicMilestone = 3800;
		}

		if (levelManager.currentLevel == 5) 
		{
			firstMusicMilestone = 10000;
		}

		if (levelManager.currentLevel == 6) 
		{
			firstMusicMilestone = 24000;
		}

		if (levelManager.currentLevel == 7) 
		{
			firstMusicMilestone = 58000;
		}

		if (levelManager.currentLevel == 8) 
		{
			firstMusicMilestone = 110000;
		}

		if (!firstMilestoneReached)
		{
			musicMilestoneScore = firstMusicMilestone;
		} 

		if (firstMilestoneReached)
		{
			musicMilestoneScore = levelManager.endScore;
		} 

		if (ScoreManager.currentScore >= musicMilestoneScore && !mMilestoneSet)
		{

			mMilestoneSet = true;

			musicMilestone = musicMilestone + 1;
			//Debug.Log ("Music MileStone is! " + musicMilestone);
			if (musicMilestone >= 3) {
				musicMilestone = 3;
				BGMAudio.transitionPlayed = false;
				BGMAudio.musicSet = false;
				mMilestoneSet = true;
			} else {
				BGMAudio.transitionPlayed = false;
				BGMAudio.musicSet = false;
				firstMilestoneReached = true;
				mMilestoneSet = false;
			}

		}
		

		
	}
}
