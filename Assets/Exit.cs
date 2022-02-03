using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Exit : MonoBehaviour
{
#if UNITY_EDITOR
    public static string path = @"C:\Data\Save";
#else
    public static string path = Application.persistentDataPath + @"\Save";
#endif
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        transform.Find("ExitCanvas").gameObject.SetActive(false);
        LoadGame();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            transform.Find("ExitCanvas").gameObject.SetActive(true);
        }
    }
    public void ExitYes()
    {
        Application.Quit();
    }
    public void ExitNo()
    {
        Time.timeScale = 1f;
        transform.Find("ExitCanvas").gameObject.SetActive(false);
    }
    public void LoadGame()
    {
        try
        {
            if (File.Exists(path))
            {
                string[] save = File.ReadAllLines(path);
                Score.bestScore = int.Parse(save[0].Trim());
                Coin.coin = int.Parse(save[1].Trim());
            }
        }
        catch
        {
            Score.bestScore = 0;
            Coin.coin = 0;
        }
    }
    public void SaveGame()
    {
        File.WriteAllText(path, $"{Score.bestScore}\n{Coin.coin}");
    }
    private void OnApplicationQuit()
    {
        try
        {
            SaveGame();
        }
        catch { }
    }
}