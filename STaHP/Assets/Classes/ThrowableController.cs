using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableController : MonoBehaviour
{

    public int bombTimer;
    public float explosionRadius;
    public int resetTimer;
    public bool exploded;
    public Animation anim;
    public Rigidbody2D throwableRigidbody;
    public float throwSpeed;
    public float gravity;

    public bool initFlight = false;

    private PlayerCharacter thePlayer;

    // Use this for initialization
    void Start()
    {
        throwableRigidbody = GetComponent<Rigidbody2D>();
        thePlayer = FindObjectOfType<PlayerCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = throwableRigidbody.velocity - new Vector2(transform.position.x, transform.position.y);

        //transform.rotation = Quaternion.LookRotation(throwableRigidbody.velocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Surface")
        {
            throwableRigidbody.velocity = new Vector2(0, 0);
        }
    }

    public void SetThrowDestination(Vector2 throwDestination)
    {
        throwableRigidbody.AddForce(throwDestination * throwSpeed);
        Debug.Log("We Goin " + throwDestination);
    }
}
