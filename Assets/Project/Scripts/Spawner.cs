using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] int totalNumOfLevels = 30;
    
    [SerializeField] float timeBetweenLevel = 5f;

    [SerializeField] GameObject[] ezObstacles;
    [SerializeField] GameObject[] midObstacles;
    [SerializeField] GameObject[] difficultObstacles;
    [SerializeField] GameObject[] hardObstacles;

    private BoxCollider touchSpawner;
    private float difficulty = 0.1f;
    private int currentLevel = 0;
    private int objCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        touchSpawner = GetComponent<BoxCollider>();
        totalNumOfLevels = GameManager.instance.GetTotalLevel();
        currentLevel = GameManager.instance.GetCurrentLevel();
        StartLevel();
        GameManager.instance.MusicOn();
    }

    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "Obstacle")
        {
            if(objCount < 18)
            {
                Spawn();
                objCount++;
            }
            else 
            {
                currentLevel++;
                GameManager.instance.SetLevel();
                Invoke(nameof(ShowLevelcard), 6f);
                ChangeLevel();
                objCount = 0;
            }

        }
    }

    private void ShowLevelcard()
    {
        if(currentLevel <= totalNumOfLevels)
        {
            GameManager.instance.ShowLevelcard();
        }

    }

    private void ChangeLevel()
    {
        
        difficulty = 5f * ((float)currentLevel / (float)totalNumOfLevels);

        if(currentLevel <= totalNumOfLevels)
        {
            Invoke(nameof(Spawn), timeBetweenLevel);
        }



        if(touchSpawner.center.z < -38f)
        {
            touchSpawner.center = new Vector3(touchSpawner.center.x, touchSpawner.center.y, -60f + ((12f * currentLevel)/ totalNumOfLevels));
        }

    }

    private void StartLevel()
    {
        ShowLevelcard();
        difficulty = 5f * ((float)currentLevel / (float)totalNumOfLevels);
        Invoke(nameof(Spawn), 0.1f);


        if(touchSpawner.center.z < -38f)
        {
            touchSpawner.center = new Vector3(touchSpawner.center.x, touchSpawner.center.y, -60f + ((12f * currentLevel)/ totalNumOfLevels));
        }

    }

    private void Spawn()
    {
        float roll = Random.Range(0f, 15f);

        float scale1 = (difficulty * 2f);
        float scale2 = (difficulty * 1f);

        if(roll < (6 - scale1)) 
        {
            int objRoll =  Random.Range(0, ezObstacles.Length);
            int rotateRoll = Random.Range(0, 73);
            Instantiate(ezObstacles[objRoll], transform.position, Quaternion.Euler(0f, 0f, 5f * rotateRoll)); 
            
        }
        else if(roll >= (6 - scale1) && roll < (10 - scale1)) 
        { 
            int objRoll =  Random.Range(0, midObstacles.Length);
            int rotateRoll = Random.Range(0, 73);
            Instantiate(midObstacles[objRoll], transform.position, Quaternion.Euler(0f, 0f, 5f * rotateRoll));
        }
        else if(roll >= (10 - scale1) && roll < (13 - scale2)) 
        { 
            int objRoll =  Random.Range(0, difficultObstacles.Length);
            int rotateRoll = Random.Range(0, 73);
            Instantiate(difficultObstacles[objRoll], transform.position, Quaternion.Euler(0f, 0f, 5f * rotateRoll)); 
        }
        else if(roll >= (13 - scale2))
        { 
            int objRoll =  Random.Range(0, hardObstacles.Length);
            int rotateRoll = Random.Range(0, 73);
            Instantiate(hardObstacles[objRoll], transform.position, Quaternion.Euler(0f, 0f, 5f * rotateRoll)); 
        }
    }

}
