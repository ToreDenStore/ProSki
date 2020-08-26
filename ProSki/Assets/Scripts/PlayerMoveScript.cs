using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    private AudioSource moveAudio;
    private bool audioIsPlaying;
    private Rigidbody2D rb;
    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveAudio = GetComponent<AudioSource>();
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        moveAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!isPaused)
        {
            if (!audioIsPlaying && rb.velocity.magnitude > 0.5)
            {
                print("Start audio");
                moveAudio.Play();
                audioIsPlaying = true;
            }
            else if (audioIsPlaying && rb.velocity.magnitude <= 0.5)
            {
                print("Stop audio");
                moveAudio.Stop();
                audioIsPlaying = false;
            }

            if (audioIsPlaying)
            {
                moveAudio.pitch = rb.velocity.magnitude / 3;
                moveAudio.volume = Mathf.Sqrt(rb.velocity.magnitude / 6);
            }
        } else if(audioIsPlaying)
        {
            print("Stop audio");
            moveAudio.Stop();
            audioIsPlaying = false;
        }
    }

    public void SetPaused(bool _isPaused)
    {
        isPaused = _isPaused;
    }

    public Vector2 GetForce(float maxSpeed, float maxForce, float fatigue)
    {
        float currentSpeedForward = Mathf.Sqrt(Mathf.Pow(Mathf.Max(0, rb.velocity.x), 2) + Mathf.Pow(Mathf.Max(0, rb.velocity.y), 2));

        float factor = Mathf.Sqrt(Mathf.Max((maxSpeed - currentSpeedForward), 0) / maxSpeed);

        if (fatigue >= 90)
        {
            factor = factor / 2;
        }

        print("Staka force factor: " + factor);

        print("Forward vector: " + rb.transform.right);

        Vector2 forceVector = new Vector3(factor * maxForce * rb.transform.right.x, factor * maxForce * rb.transform.right.y);

        print("Staka force: " + forceVector);

        return forceVector;
    }

    public void SetDrag(float newDrag)
    {
        rb.drag = newDrag;
        return;
    }
}
