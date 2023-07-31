using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woosh : MonoBehaviour
{
    private AudioSource asWoosh;

    private void Awake() {
        asWoosh = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Obstacle")
        {
            asWoosh.Play();
        }
    }
}

