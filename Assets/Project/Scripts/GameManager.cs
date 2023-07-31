using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int currentLevel = 1;
    [SerializeField] int totalNumOfLevels = 30;

    [SerializeField] GameObject levelNumberCanvas;
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] int endSceneIndex;
    [SerializeField] GameObject music;

    private void Awake() {
        SingleTon();
        DontDestroyOnLoad(this.gameObject);
        LoadCurrentLevelNum();
        
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public int GetTotalLevel()
    {
        return totalNumOfLevels;
    }

    public void SetLevel()
    {
        currentLevel++;

        Invoke(nameof(EndLevel), 6f);
    }

    private void EndLevel()
    {
        if(currentLevel > totalNumOfLevels)
        {
            SceneManager.LoadScene(endSceneIndex);
        }
    }

    public void MusicOn()
    {
        music.SetActive(true);
    }

    public void ShowLevelcard()
    {
        textMesh.text = GameManager.instance.GetCurrentLevel().ToString();
        levelNumberCanvas.gameObject.SetActive(true);

        Invoke(nameof(DisableLevelCanvas), 2.5f);
    }

    private void DisableLevelCanvas()
    {
        levelNumberCanvas.gameObject.SetActive(false);
    }

    private void SaveCurrentLevelNum()
    {
        //if needed
    }

    private void LoadCurrentLevelNum()
    {

    }

    private void SingleTon()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
}
