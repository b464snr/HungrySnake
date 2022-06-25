using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public void OnTriggerEnter(Collider other) {
        if (other.tag == "Obstacle"){
            transform.position = new Vector3(Random.Range(-10,10f),-3,Random.Range(-10,-10));
        }
    }
}
