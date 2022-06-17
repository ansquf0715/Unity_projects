using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    // 순간이동 하는 발판
    // 1. 닿았는지 확인
    // 2. 현재 위치를 파악, 닿은 오브젝트의 이름 파악
    // 3. 다른 오브젝트로 이동 시킴

    public GameObject[] teleportObjects;

    public AudioClip audioTeleport;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        for(int i=0;i<8; i=i+2)//짝수일 때 0 2 4 6
        {
            if (other.name == "teleport"+i)
            {
                if (UI.score >= 3)
                {
                    audioSource.clip = audioTeleport;
                    audioSource.Play();

                    UI.score -= 3;
                    gameObject.transform.position = teleportObjects[i+1].transform.position;


                    teleportObjects[i+1].GetComponent<CapsuleCollider>().enabled = false;
                    string fuctionName = "SetTeleport" +(i+1)+ "Collider";
                    Invoke(fuctionName, 3.0f);
                }
                else return;
            }
        }

        for (int i = 1; i < 8; i = i + 2) //홀수 일 때 1 3 5 7
        {
            if (other.name == "teleport" + i)
            {
                if (UI.score >= 3)
                {
                    audioSource.clip = audioTeleport;
                    audioSource.Play();

                    UI.score -= 3;
                    gameObject.transform.position = teleportObjects[i - 1].transform.position;


                    teleportObjects[i - 1].GetComponent<CapsuleCollider>().enabled = false;
                    string fuctionName = "SetTeleport" + (i - 1) + "Collider";
                    Invoke(fuctionName, 3.0f);
                }
                else return;
            }
        }
    }

    void SetTeleport0Collider()
    {
        teleportObjects[0].GetComponent<CapsuleCollider>().enabled = true;
    }
    void SetTeleport1Collider()
    {
        teleportObjects[1].GetComponent<CapsuleCollider>().enabled = true;
    }
    void SetTeleport2Collider()
    {
        teleportObjects[2].GetComponent<CapsuleCollider>().enabled = true;
    }
    void SetTeleport3Collider()
    {
        teleportObjects[3].GetComponent<CapsuleCollider>().enabled = true;
    }
    void SetTeleport4Collider()
    {
        teleportObjects[4].GetComponent<CapsuleCollider>().enabled = true;
    }
    void SetTeleport5Collider()
    {
        teleportObjects[5].GetComponent<CapsuleCollider>().enabled = true;
    }
    void SetTeleport6Collider()
    {
        teleportObjects[6].GetComponent<CapsuleCollider>().enabled = true;
    }
    void SetTeleport7Collider()
    {
        teleportObjects[7].GetComponent<CapsuleCollider>().enabled = true;
    }
}
