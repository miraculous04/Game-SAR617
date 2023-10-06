using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 1.3f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        transform.Rotate(0f, rotateSpeed, 0f, Space.World);
    }
}
