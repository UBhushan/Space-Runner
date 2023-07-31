using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    private Vector3 newRotation;

    private void Start() {
        newRotation = Vector3.zero;
    }

    private void Update() {
        
        newRotation = Vector3.zero;

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newRotation = new Vector3(0f, 0f, -speed * Time.deltaTime);
            transform.eulerAngles += newRotation;
            
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newRotation = new Vector3(0f, 0f, speed * Time.deltaTime);
            transform.eulerAngles += newRotation;
        }

    }

    public Vector3 GetRotation()
    {
        return newRotation;
    }
    
    private void SetSpeed()
    {
        speed = 25 + (20 * (GameManager.instance.GetCurrentLevel()/ GameManager.instance.GetTotalLevel()));
    }
}
        
        
