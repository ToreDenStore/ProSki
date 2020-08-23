using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public GameObject flatBlockPrefab;
    public GameObject curveBlockPrefab;
    public GameObject startBlock;
    public GameObject finishBlock;

    public int numberOfBlocks;
    public int seed;
    public int baseWidth;
    public int baseHeight;
    
    void Start()
    {
        Random.InitState(seed);
        GenerateMap();
    }

    void GenerateMap()
    {
        GameObject latestBlock = startBlock;

        for (int i = 0; i < numberOfBlocks; i++)
        {
            float xLatest = latestBlock.transform.position.x;
            float yLatest = latestBlock.transform.position.y;
            float widthScaleLatest = latestBlock.transform.localScale.x;
            float heightScaleLatest = latestBlock.transform.localScale.y;

            int newBlockType = Random.Range(i, i+3) - i;
            print("Flat or curve? " + newBlockType);

            float widthScaleNew = (Random.Range(0.5f + i, 1.5f + i) - i);
            print("New width scale: " + widthScaleNew);

            float xNew = xLatest + widthScaleLatest * baseWidth;
            print("New position x: " + xNew);
            
            float heightScaleNew = (Random.Range(0.5f + i, 1.5f + i) - i);
            print("New height scale: " + heightScaleNew);

            float yNew = yLatest - (heightScaleNew - heightScaleLatest) * baseHeight;
            print("New position y: " + yNew);

            Vector3 positionNew;

            if (latestBlock.tag == "Flat")
            {
                positionNew = new Vector3(xNew, yNew, 0);
                print("previous object is flat");
            } else if (latestBlock.tag == "DownCurve")
            {
                positionNew = new Vector3(xNew -= baseWidth * widthScaleLatest, yNew, 0); //Due to previous rotation I need to remove the width of the previous
                print("previous object is a down-curve");
            } else
            {
                positionNew = new Vector3(xNew, yNew + heightScaleLatest * baseHeight, 0);
                print("previous object is an up-curve");
            }

            if (i == numberOfBlocks - 1)
            {
                //Finish block
                latestBlock = GameObject.Instantiate(finishBlock, positionNew, new Quaternion());
            } else if (newBlockType == 1)
            {
                //Flat
                latestBlock = GameObject.Instantiate(flatBlockPrefab, positionNew, new Quaternion());
            } else if (newBlockType == 2)
            {
                //Curve up
                latestBlock = GameObject.Instantiate(curveBlockPrefab, positionNew, new Quaternion());
            } else
            {
                //Curve down
                positionNew.x += baseWidth * widthScaleNew; //Due to rotation I need to add its width again
                positionNew.y -= baseHeight * heightScaleNew;
                latestBlock = GameObject.Instantiate(curveBlockPrefab, positionNew, Quaternion.AngleAxis(180, Vector3.up));
                latestBlock.tag = "DownCurve";
            }

            latestBlock.transform.localScale = new Vector3(widthScaleNew, heightScaleNew, 1);
        }
    }
}
