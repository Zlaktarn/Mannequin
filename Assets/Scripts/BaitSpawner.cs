using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitSpawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject rPrefab;
    SkinnedMeshRenderer skinner;
    Vector3[,] positioned = new Vector3[10,10];

    void Start()
    {
        RandomizeMannequins();

        //for (int i = 0; i < 10; i++)
        //{
        //    for (int j = 0; j < 10; j++)
        //    {
        //        float place = Random.Range(0, 99);
        //        if (place >= 70)
        //        {
        //            if (positioned[i, j] == new Vector3(0, 0, 0))
        //            {
        //                Instantiate(rPrefab, new Vector3(i * 2, -0.1664439f, j * 2), Quaternion.Euler(0, Random.Range(0, 360), 0));
        //            }
        //        }
        //    }
        //}
    }

    void RandomizeMannequins()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                float place = Random.Range(0, 99);
                if (place >= 70)
                {
                    positioned[i, j] = new Vector3(i * 2, -0.1664439f, j * 2);
                    Instantiate(prefab, positioned[i, j], Quaternion.Euler(0, Random.Range(0, 360), 0));
                    print(positioned[i, j]);
                }
                else
                    positioned[i, j] = new Vector3(0, 0, 0);
            }
        }
    }

    void RandomizeWalls()
    {

    }
}
