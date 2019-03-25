using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
#if UNITY_IPHONE
using UnityEngine.SocialPlatforms.GameCenter;
#endif
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour {

	public static string leaderboardID;
	public static string deathsID;
	public static string timeID;
	public static string totalID;
	public ILeaderboard totalTime;
	public ILeaderboard topScores;
	public ILeaderboard combinedTotal;
	public Int64 reportedScore;
	public static float alive;
	public GameObject loginButton;
	private Image buttonColor;
	public static string achiev1;
	public static string achiev2;
	public static string achiev3;
	public static string achiev4;
	public static string achiev5;
	public static string achiev6;
	public static string achiev7;
	public static string achiev8;
	public static string achiev9;
	public static string achiev10;

	void Start ()
	{
		buttonColor = loginButton.GetComponent<Image>();

		#if UNITY_ANDROID


		/*PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder ().Build();
		PlayGamesPlatform.InitializeInstance (config);
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate ();

		signIn ();	*/

		achiev1 = "CgkI64Xdv_8ZEAIQBg";
		achiev2 = "CgkI64Xdv_8ZEAIQBw";
		achiev3 = "CgkI64Xdv_8ZEAIQCA";
		achiev4 = "CgkI64Xdv_8ZEAIQCQ";
		achiev5 = "CgkI64Xdv_8ZEAIQCg";
		achiev6 = "CgkI64Xdv_8ZEAIQCw";
		achiev7 = "CgkI64Xdv_8ZEAIQDA";
		achiev8 = "CgkI64Xdv_8ZEAIQDQ";
		achiev9 = "CgkI64Xdv_8ZEAIQDg";
		achiev10 = "CgkI64Xdv_8ZEAIQDw";

		//Debug.Log ("Detecting Android");
		deathsID = "CgkI64Xdv_8ZEAIQBA";
		leaderboardID = "CgkI64Xdv_8ZEAIQAg";
		timeID = "CgkI64Xdv_8ZEAIQAw";

		#endif


		#if UNITY_IPHONE

		achiev1 = "grp.understanding";
		achiev2 = "grp.intention";
		achiev3 = "grp.speech";
		achiev4 = "grp.action";
		achiev5 = "grp.livelihood";
		achiev6 = "grp.effort";
		achiev7 = "grp.mindfulness";
		achiev8 = "grp.concentration";
		achiev9 = "grp.unfoldedandascended";
		achiev10 = "grp.nosuchthingasluck";
		GameCenterPlatform.ShowDefaultAchievementCompletionBanner (true);

		if (!Social.localUser.authenticated) {
			AuthenticateToGameCenter ();
			isAuthenticatedToGameCenter = true;
			//Debug.Log ("Detecting iPhone");
			deathsID = "grp.KarmaTotalDeaths";
			timeID = "grp.KarmaTotalTime";
			totalID = "grp.KarmaCombinedTotal";
			leaderboardID = "grp.KarmaTopScores";
			topScores.LoadScores (result =>
				{
					Debug.Log ("Received " + topScores.scores.Length + " scores");
					foreach (IScore score in topScores.scores)
						Debug.Log(score);
				});
		}

		#endif

	}
		



	
				

	void Update ()
	{
		reportedScore = sceneManager.sentScore;
	}


	#if UNITY_ANDROID

	public void signIn ()
	{

		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder ().Build();
		PlayGamesPlatform.InitializeInstance (config);
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate ();

		Social.localUser.Authenticate (success => {
		});

		if (Social.localUser.authenticated) {
			buttonColor.color = Color.green;
		} else {buttonColor.color = Color.red;
		}

		Social.LoadAchievements(achievements => {
			if (achievements.Length > 0)
			{
				//Debug.Log("Got " + achievements.Length + " achievement instances");
				string myAchievements = "My achievements:\n";
				foreach (IAchievement achievement in achievements)
				{
					myAchievements += "\t" +
						achievement.id + " " +
						achievement.percentCompleted + " " +
						achievement.completed + " " +
						achievement.lastReportedDate + "\n";
				}
				//Debug.Log(myAchievements);
			}
			else
				//Debug.Log("No achievements returned");
		});

		Social.LoadAchievementDescriptions(descriptions => {
			if (descriptions.Length > 0)
			{
				//Debug.Log("Got " + descriptions.Length + " achievement descriptions");
				string achievementDescriptions = "Achievement Descriptions:\n";
				foreach (IAchievementDescription ad in descriptions)
				{
					achievementDescriptions += "\t" +
						ad.id + " " +
						ad.title + " " +
						ad.unachievedDescription + "\n";
				}
				//Debug.Log(achievementDescriptions);
			}
			else
				//Debug.Log("Failed to load achievement descriptions");
		});
	}

	#endif
			

		
	public void ProcessAuthentication(bool success) {
		if(!success)
			Debug.LogWarning("Social Services not initiated");
		else {
			Debug.Log(Social.localUser.userName);
		}
	}

	public bool isAuthenticatedToGameCenter;

	public static void  AuthenticateToGameCenter()
	{
		Social.localUser.Authenticate(success =>
			{
				if (success)
				{
					//Debug.Log("Authentication successful");
					Social.LoadAchievements(achievements => {
						if (achievements.Length > 0)
						{
							//Debug.Log("Got " + achievements.Length + " achievement instances");
							string myAchievements = "My achievements:\n";
							foreach (IAchievement achievement in achievements)
							{
								myAchievements += "\t" +
									achievement.id + " " +
									achievement.percentCompleted + " " +
									achievement.completed + " " +
									achievement.lastReportedDate + "\n";
							}
							Debug.Log(myAchievements);
						}
						else
							Debug.Log("No achievements returned");
					});

					Social.LoadAchievementDescriptions(descriptions => {
						if (descriptions.Length > 0)
						{
							//Debug.Log("Got " + descriptions.Length + " achievement descriptions");
							string achievementDescriptions = "Achievement Descriptions:\n";
							foreach (IAchievementDescription ad in descriptions)
							{
								achievementDescriptions += "\t" +
									ad.id + " " +
									ad.title + " " +
									ad.unachievedDescription + "\n";
							}
							Debug.Log(achievementDescriptions);
						}
						else
							Debug.Log("Failed to load achievement descriptions");
					});
				}
				else
				{
					//Debug.Log("Authentication failed");
				}
			});
	}
		
			

	/*public bool ConnectToGoogleServices ()
	{
		if (!IsConnectedToGoogleServices) {
			Social.localUser.Authenticate ((bool success) => {
				IsConnectedToGoogleServices = success;
			});
		}

		return IsConnectedToGoogleServices;
	}*/
		
	//call to update the leaderboard with your score
	public void ReportScore(/*long reportedScore, string leaderboardID*/)
	{
		#if UNITY_IPHONE
		//Debug.Log("Reporting score " + reportedScore + " on leaderboard " + leaderboardID);
		Social.ReportScore(reportedScore, leaderboardID, success =>
			{
				if (success)
				{
					//Debug.Log("Reported score successfully");
				}
				else
				{
					//Debug.Log("Failed to report score");
				}

			});
		#endif

		#if !UNITY_IPHONE
		//Debug.Log("Reporting score " + reportedScore + " on leaderboard " + leaderboardID);
		Social.ReportScore(reportedScore, leaderboardID, success =>
			{
				if (success)
				{
					//Debug.Log("Reported score successfully");
				}
				else
				{
					//Debug.Log("Failed to report score");
				}

			});
		#endif
	}

	//call to show leaderboard
	public void ShowLeaderboard()
	{
		Social.ShowLeaderboardUI ();
	}

	public void ShowAchievements ()
	{
		Social.ShowAchievementsUI ();
	}
}


