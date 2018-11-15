using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
    private static int score = 0;
    private static int highScore = 0;
    private static string path;

	// Use this for initialization
	void Start () 
    {
        path = Application.persistentDataPath;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        LoadHighScore();
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public static void SetScore(int newScore)
    {
        score += newScore;
        if (score > highScore)
            highScore = score;
    }

    public static void ResetScore()
    {
        score = 0;
    }

    public static int GetScore()
    {
        return score;
    }

    public static int GetHighScore()
    {
        return highScore;
    }

    public static void SaveHighScore()
    {
        if(score == highScore)
        {
            string strData = highScore.ToString();
            byte[] byteData = System.Text.Encoding.UTF8.GetBytes(strData);
            string[] data = { System.Convert.ToBase64String(byteData) };
            System.IO.File.WriteAllLines(path + "/Data.akh", data);
        }
    }

    void LoadHighScore()
    {
        try
        {
            string[] data = System.IO.File.ReadAllLines(path + "/Data.akh");

            if (data.Length > 0)
            {
                byte[] byteData = System.Convert.FromBase64String(data[0]);
                string strData = System.Text.Encoding.UTF8.GetString(byteData);
                highScore = System.Convert.ToInt32(strData);
            }
        }
        catch (System.Exception)
        {
            // Do nothing!
        }
    }
}
