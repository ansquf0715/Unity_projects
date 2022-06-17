using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawn : MonoBehaviour
{
    public GameObject obj;

    void Start()
    {
        for (int i= 0; i<4; i++)
        {
            float randomX = Random.Range(-6.0f, 2.0f);
            float randomZ = Random.Range(9.0f, 25.0f);
            Debug.Log(randomX);
            Debug.Log(randomZ);
            Instantiate(obj, new Vector3(randomX, 0, randomZ), Quaternion.identity);
        }
    }

}//스크립트 종료
