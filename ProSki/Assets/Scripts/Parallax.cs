using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    /*
        Taken from https://www.youtube.com/watch?v=zit45k6CUMk&list=PLGaBX05rw2wUeuQjERZuDm7o1VwFr3qf3&index=2&t=0s
    */

    private float length;
    private float startPosition;

    public GameObject cam;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));

        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPosition + dist, transform.position.y, transform.position.z);

        if(temp > startPosition + length)
        {
            startPosition += length;
        } else if (temp < startPosition - length)
        {
            startPosition -= length;
        }
    }
}
