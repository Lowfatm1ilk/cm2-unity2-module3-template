using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballScript : MonoBehaviour
{
    private Rigidbody rb;
    private CannonControlScript cannon;
    public float airSpeed = 100;
    public float explosionPower = 100;
    public float explosionRadius = 100;
    [SerializeField]
    private ParticleSystem explosion;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Launch(CannonControlScript cannon, float power, float angle)
    {
        this.cannon = cannon;
        rb.AddRelativeForce(transform.up * power, ForceMode.Impulse);
    }

    void Update()
    {
        float x = Input.GetAxis("Horizantal") * airSpeed;
        float z = Input.GetAxis("Vertical") * airSpeed;
        rb.AddForce(new Vector3(x, 0, z));
    }

    private void OnCollisionEnter(Collision other) 
    {
        explosion.Play();
        Explode();
        StartCoroutine(cannon.ReturnCamera());
        Destroy(this.gameObject, 1);
    }

    public void Explode()
    {
        foreach(var rayhit in Physics.SphereCastAll(transform.position,explosionRadius, transform.forward, explosionRadius*2))
        {
            DestructableBuilding block = rayhit.collider.GetComponent<DestructableBuilding>();
            Rigidbody blockRB = block.GetRigidbody();
            if(blockRB != null)
            {
                blockRB.AddExplosionForce(explosionPower, this.transform.position, explosionRadius);
            }
        }
    }
}
