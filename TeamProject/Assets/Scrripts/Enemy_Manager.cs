using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : MonoBehaviour //�� ���� ����
{

    public GameObject[] enemys;
    private BoxCollider area;
    public int count = 100; //������ ���� ����

    private List<GameObject> gameobject = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        area = GetComponent<BoxCollider>(); //���������� ���ؼ� ������ �� ũ���� �ݶ��̴�

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

    Vector3 GetRandomPosition() //�� ���� ���� ��ġ ����
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


//https://angliss.cc/random-gameobject-created/ -�� �ȿ��� ���� ����