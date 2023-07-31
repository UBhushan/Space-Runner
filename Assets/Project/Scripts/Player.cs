using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 50f;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] float height = 0.75f;
    [SerializeField] float rayHeight = 0.5f;

    private Vector3 newPosition;
    private Vector3 newUp;
    private Rigidbody rbPlayer;

    private void Start() {
        newPosition = transform.position;
        newUp = transform.up;
        rbPlayer = GetComponent<Rigidbody>();
    }

    private void Update() {
        
        if(Input.GetKey(KeyCode.A))
        {
            groundHit(-transform.right);
            newPosition += (-transform.right * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            groundHit(transform.right);
            newPosition += (transform.right * speed * Time.deltaTime);
        }

        
        transform.position = newPosition;
        transform.up = Vector3.Slerp(transform.up, newUp, rotationSpeed * Time.deltaTime);
        
    }

    private void groundHit(Vector3 dir)
    {
        Vector3 rayOrigin = transform.position - Vector3.up * rayHeight;

        Physics.Raycast(rayOrigin , dir, out RaycastHit hit, 0.85f);
        if(hit.collider != null)
        {
            if(hit.collider.gameObject.tag == "Ground")
            {
                newUp = hit.normal;
                newPosition = hit.point + hit.normal.normalized * height;
            }
        }
    }

    
    

}
