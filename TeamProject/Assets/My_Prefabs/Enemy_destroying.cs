using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_destroying : MonoBehaviour
{
    public int health = 3;
    public GameObject obj_effect; //충돌효과

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="BulletTag")
        {
            Debug.Log("Collision!");
            //attacked();

            if(health==0)
            {
                Destroy(gameObject);

                Instantiate(obj_effect, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                Quaternion.identity);
            }
        }
    }

    private void attacked()
    {
        //helth -= Attack.damage;
        //health -= 1;
        
    }
}
