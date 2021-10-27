using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baddie : MonoBehaviour
{

    private Rigidbody2D rig;
    private float speed;

    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * this.speed/3);
    }

    public void AssignTarget(Base target, float speed)
    {
        this.speed = speed;
        rig.AddForce((target.transform.position - transform.position).normalized * speed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            collision.gameObject.GetComponent<Base>().Damage(1);
        }

        if (!collision.gameObject.CompareTag("Baddie"))
        {
            Destroy(this.gameObject);
        }
    }
}
