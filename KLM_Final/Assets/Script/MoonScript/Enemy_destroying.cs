using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_destroying : MonoBehaviour
{
    public int max_health = 3; //최대 체력
    private int cur_health; //현재 체력

    public GameObject obj_effect; //충돌효과

    public Slider healthBarSlider;

    // Start is called before the first frame update
    void Start()
    {
        cur_health = max_health;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            Debug.Log("Collision!" + cur_health);
            attacked();

            if (cur_health == 0)
            {
                Destroy(gameObject);

                Instantiate(obj_effect, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                Quaternion.identity);

                UI.score += max_health;
            }
        }
    }


    private void attacked()
    {
        cur_health -= Attack.damage;
        healthBarSlider.value = cur_health;
    }


}
