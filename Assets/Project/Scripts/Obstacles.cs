using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] float speed = 20f;

    private void Start() {
        speed = 20 + (5 * (GameManager.instance.GetCurrentLevel() / GameManager.instance.GetTotalLevel()));
    }

    private void Update() {
        CheckToDestroy();
        Move();
    }

    private void Move()
    {
        transform.position += new Vector3(0f, 0f, -1 * speed * Time.deltaTime);
    }

    private void CheckToDestroy()
    {
        if(transform.position.z < -20f)
        {
            Destroy(this.gameObject);
        }
    }
}
