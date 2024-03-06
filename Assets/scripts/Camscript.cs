using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camscript : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping;

    private Vector3 velocity = Vector3.zero;
    
    private void FixedUpdate() {
        Vector3 movePosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
    }
}
