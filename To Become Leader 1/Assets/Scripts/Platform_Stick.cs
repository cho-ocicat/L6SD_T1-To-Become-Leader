using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Stick : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")) {
            other.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.CompareTag("Player")) {
            other.gameObject.transform.SetParent(null);
        }
    }
}
