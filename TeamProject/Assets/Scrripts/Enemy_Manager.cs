using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : MonoBehaviour //적 랜덤 생성
{

    public GameObject[] enemys;
    private BoxCollider area;
    public int count = 100; //생성할 적의 숫자

    private List<GameObject> gameobject = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        area = GetComponent<BoxCollider>(); //범위지정을 위해서 설정한 맵 크기의 콜라이더

        for(int i=0;i<count;i++)
        {
            Spawn();
            //Debug.Log("I'm out");
        }

        area.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn() 
    {
        int selection = Random.Range(0, enemys.Length);

        GameObject selectedPrefab = enemys[selection];

        Vector3 spawnPos = GetRandomPosition();

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        gameobject.Add(instance);
    }

    Vector3 GetRandomPosition() //적 랜덤 스폰 위치 지정
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size;

        float posX = basePosition.x + Random.Range(-size.x / 5f, size.x / 5f);
        //float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);
        float posZ = basePosition.z + Random.Range(-size.z / 5f, size.z / 5f);

        Vector3 spawnPos = new Vector3(posX, 0, posZ);

        return spawnPos;
    }
}


//https://angliss.cc/random-gameobject-created/ -맵 안에서 랜덤 생성