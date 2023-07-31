using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotate : MonoBehaviour
{
    [SerializeField] float rotSpeed = 15f;
    Vector3 newRotation;

    private void Start() {
        float rollLR = Random.Range(0f, 5f);

        if(rollLR <= 2)
        {
            rotSpeed = 15f + (5f * (GameManager.instance.GetCurrentLevel() / GameManager.instance.GetTotalLevel()));
        }
        else
        {
            rotSpeed = 15f + (5f * (GameManager.instance.GetCurrentLevel() / GameManager.instance.GetTotalLevel()));
            rotSpeed = rotSpeed * -1f;
        }

    }

    private void Update() {
        newRotation = new Vector3(0f, 0f, rotSpeed * Time.deltaTime);
        transform.eulerAngles += newRotation;
    }

    
}
