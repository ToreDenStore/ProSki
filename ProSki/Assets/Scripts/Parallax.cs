using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    /*
        Taken from https://www.youtube.com/watch?v=zit45k6CUMk&list=PLGaBX05rw2wUeuQjERZuDm7o1VwFr3qf3&index=2&t=0s
    */

    private float lengthX;
    private float lengthY;
    private float startPositionX;
    private float startPositionY;

    public GameObject cam;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startPositionX = transform.position.x;
        startPositionY = transform.position.y;
        lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
        lengthY = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distX = (cam.transform.position.x * parallaxEffect);
        float distY = (cam.transform.position.y * parallaxEffect);
        transform.position = new Vector3(startPositionX + distX, startPositionY + distY, transform.position.z);

        //Recreating background images X-wise
        float tempX = (cam.transform.position.x * (1 - parallaxEffect));

        if (tempX > startPositionX + lengthX)
        {
            startPositionX += lengthX;
        } else if (tempX < startPositionX - lengthX)
        {
            startPositionX -= lengthX;
        }
    }
}
