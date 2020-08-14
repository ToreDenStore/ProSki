using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    private Rigidbody2D rb;

    public float stakaMaxSpeed = 10;
    public float stakaMaxForce = 500;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public Vector2 GetForceStaka()
    {
        float currentSpeedForward = Mathf.Sqrt(Mathf.Pow(Mathf.Max(0, rb.velocity.x), 2) + Mathf.Pow(Mathf.Max(0, rb.velocity.y), 2));

        float factor = (stakaMaxSpeed - currentSpeedForward) / stakaMaxSpeed;

        print("Staka force factor: " + factor);

        print("Forward vector: " + rb.transform.right);

        Vector2 stakaForceVector = new Vector3(factor * stakaMaxForce * rb.transform.right.x, factor * stakaMaxForce * rb.transform.right.y);

        print("Staka force: " + stakaForceVector);

        return stakaForceVector;
    }
}
