using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D rig;
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] audioClips;

    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioClips[0]);
        Destroy(this.gameObject, 3f);
    }

    public void Launch(Vector2 direction, float speed)
    {
        rig.AddForce(direction.normalized * speed, ForceMode2D.Impulse);
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (!collision.gameObject.CompareTag("Baddie") || !collision.gameObject.CompareTag("Rocket"))
        {
            audioSource.PlayOneShot(audioClips[1]);
            Destroy(this.gameObject, 0.33f);
        }
    }
}
