using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    private Rigidbody2D rb;

    //public float maxSpeed = 10;
    //public float maxForce = 500;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public Vector2 GetForce(float maxSpeed, float maxForce)
    {
        float currentSpeedForward = Mathf.Sqrt(Mathf.Pow(Mathf.Max(0, rb.velocity.x), 2) + Mathf.Pow(Mathf.Max(0, rb.velocity.y), 2));

        float factor = (maxSpeed - currentSpeedForward) / maxSpeed;

        print("Staka force factor: " + factor);

        print("Forward vector: " + rb.transform.right);

        Vector2 stakaForceVector = new Vector3(factor * maxForce * rb.transform.right.x, factor * maxForce * rb.transform.right.y);

        print("Staka force: " + stakaForceVector);

        return stakaForceVector;
    }
}
