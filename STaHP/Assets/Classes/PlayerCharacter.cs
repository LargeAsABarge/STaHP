using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    public int[] distanceToThrow;
    public int[] bombToThrow;
    public GameObject throwable;
    public Transform throwOrigin;
    public Vector2 throwOriginVec;
    public Vector2 throwSpeed;
    public float gravity;
    //public Transform throwPointPos;
    public Vector2 throwDestination;
    public float flightSpeed;
    public float throwTimer;
    public float throwResetTimer;
    public float landingTime;
    public Vector2 clickPos;

    public ThrowableController thrownObject;
    public Rigidbody2D thrownRB;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (throwTimer > 0)
        {
            throwTimer -= Time.deltaTime;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            clickPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Debug.Log(clickPos);
            InstantOrigin();
            Vector2 throwDestination = new Vector2(clickPos.x - throwOriginVec.x, clickPos.y - throwOriginVec.y);
            throwDestination.Normalize();
            Debug.Log("Throw destination is " + throwDestination);
            Throw(throwDestination);
        }
    }

    public void InstantOrigin()
    {
        throwOriginVec = Camera.main.WorldToViewportPoint(throwOrigin.position);
        //throwOriginVec = new Vector2(throwOrigin.position.x, throwOrigin.position.y);
    }

    public void Throw(Vector2 throwDestination)
    {
        if (throwTimer > 0)
        {
            Debug.Log("Cooling down.");
            return;
        }

        throwTimer = throwResetTimer;
        Debug.Log("Throwing bomb to " + throwDestination);
        //Instantiate(bomb, throwOrigin.position, throwOrigin.rotation);
        GameObject newThrowable = Instantiate(throwable, throwOrigin.position, throwOrigin.rotation);
        thrownObject = newThrowable.GetComponent<ThrowableController>();
        thrownRB = newThrowable.GetComponent<Rigidbody2D>();
        newThrowable.GetComponent<ThrowableController>().throwableRigidbody = newThrowable.GetComponent<Rigidbody2D>();
        newThrowable.GetComponent<ThrowableController>().SetThrowDestination(throwDestination);
    }
}