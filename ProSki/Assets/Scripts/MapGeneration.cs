﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public GameObject flatBlockPrefab;
    public GameObject curveBlockPrefab;
    public GameObject startBlock;
    //public GameObject player;
    public int numberOfBlocks;
    public int seed;

    public int baseWidth = 20;

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(seed);
        GenerateMap();
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    void GenerateMap()
    {
        Transform latestBlock = startBlock.transform;

        for (int i = 0; i < numberOfBlocks; i++)
        {
            float xLatest = latestBlock.position.x;
            float yLatest = latestBlock.position.y;
            float widthLatest = latestBlock.localScale.x * baseWidth;
            float heightLatest = latestBlock.localScale.y;

            int flatOrCurveBlock = Random.Range(i, i+2) - i;
            print("Flat or curve? " + flatOrCurveBlock);

            float widthNew = (Random.Range(0.5f + i, 1.5f + i) - i) * baseWidth;
            print("New width: " + widthNew);

            float xNew = xLatest + widthLatest;
            print("New position x: " + xNew);

            Vector3 positionNew = new Vector3(xNew, -7, 0);

            if (flatOrCurveBlock == 1)
            {
                //Flat
                GameObject newObject = GameObject.Instantiate(flatBlockPrefab, positionNew, new Quaternion());
                latestBlock = newObject.transform;
            } else
            {
                //Curve
                GameObject newObject = GameObject.Instantiate(curveBlockPrefab, positionNew, new Quaternion());
                latestBlock = newObject.transform;
            }
        }
    }
}
