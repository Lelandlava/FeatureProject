using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject expl;
    public float explForce, radius;
    public Rigidbody rb;
    [SerializeField]
    private float speed = 20f;
    [SerializeField]
    private float explTime = 0.2f;

    private void Awake()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnCollisionEnter (Collision collision)
    {
        GameObject _expl = Instantiate(expl, transform.position, transform.rotation);
        Destroy(_expl, explTime);
        knockBack();
        Destroy(gameObject);
    }

    public void knockBack()
    {
        var surroundingObjects = Physics.OverlapSphere(transform.position, radius);
        foreach (var obj in surroundingObjects)
        {
            Debug.Log(obj);
            var rb = obj.GetComponent<Rigidbody>();
            Debug.Log(rb);
            if (rb == null) continue;

            rb.AddExplosionForce(explForce, transform.position, radius);

        }
        GameObject _expl = Instantiate(expl, transform.position, transform.rotation);
        Destroy(_expl, explTime);
        Destroy(gameObject);
        /*
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearby in colliders)
        {
            Rigidbody rigg = nearby.GetComponent<Rigidbody>();
            Debug.Log(nearby);
            if(rigg != null)
            {
                rigg.AddExplosionForce(explForce, transform.position, radius);
            }
        }
        */
    }
}
