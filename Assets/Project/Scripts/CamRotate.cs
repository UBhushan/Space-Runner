using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed = 10f;

    private Vector3 rot;
    
    private void Start() {
        rot = Vector3.zero;
    }

    private void Update() {
        //rot = Vector3.Lerp(rot, player.GetRotation(), speed * Time.deltaTime);
        //rot = new Vector3(0f, 0f, rot.z);
        //transform.eulerAngles += rot;

        transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, speed * Time.deltaTime);
    }
}
