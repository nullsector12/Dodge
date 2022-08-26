using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed = 8f;
    public float destroyBulletRate = 8f; 
    
    private float _surviveTime;
    private Rigidbody _bulletRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        _bulletRigidBody = GetComponent<Rigidbody>();
        _bulletRigidBody.velocity = transform.forward * bulletSpeed;
        
        Destroy(gameObject, destroyBulletRate);
    }

    // Update is called once per frame 
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.Die();
            }
        }
    }
}
