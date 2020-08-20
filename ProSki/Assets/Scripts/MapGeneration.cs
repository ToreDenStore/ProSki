﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public GameObject flatBlockPrefab;
    public GameObject curveBlockPrefab;
    public GameObject startBlock;

    public int numberOfBlocks;
    public int seed;
    public int baseWidth;
    public int baseHeight;

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
            float widthScaleLatest = latestBlock.localScale.x;
            float heightScaleLatest = latestBlock.localScale.y;

            int flatOrCurveBlock = Random.Range(i, i+2) - i;
            print("Flat or curve? " + flatOrCurveBlock);

            float widthScaleNew = (Random.Range(0.5f + i, 1.5f + i) - i);
            print("New width scale: " + widthScaleNew);

            float xNew = xLatest + widthScaleLatest * baseWidth;
            print("New position x: " + xNew);
            
            float heightScaleNew = (Random.Range(0.5f + i, 1.5f + i) - i);
            print("New height scale: " + heightScaleNew);

            float yNew = yLatest - (heightScaleNew - heightScaleLatest) * baseHeight;
            print("New position y: " + yNew);

            Vector3 positionNew = new Vector3(xNew, yNew, 0);

            if (flatOrCurveBlock == 1)
            {
                //Flat
                latestBlock = GameObject.Instantiate(flatBlockPrefab, positionNew, new Quaternion()).transform;
            } else
            {
                //Curve
                latestBlock = GameObject.Instantiate(curveBlockPrefab, positionNew, new Quaternion()).transform;
            }

            latestBlock.localScale = new Vector3(widthScaleNew, heightScaleNew, 1);
        }
    }
}
