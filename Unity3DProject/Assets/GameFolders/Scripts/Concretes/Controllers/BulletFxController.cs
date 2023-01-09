using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFxController : MonoBehaviour
{
    [SerializeField] float maxLifeTime = 5f;
    [SerializeField] float moveSpeed = 100f;

    Rigidbody rigidbody;
    ParticleSystem particleSystem;

    float currentLifeTime = 0f;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    void Start()
    {
        particleSystem.Play();
    }

    void Update()
    {
        currentLifeTime += Time.deltaTime;

        if (currentLifeTime > maxLifeTime)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }

    public void SetDirection(Vector3 direction)
    {
        rigidbody.velocity = direction * moveSpeed;
    }
}
