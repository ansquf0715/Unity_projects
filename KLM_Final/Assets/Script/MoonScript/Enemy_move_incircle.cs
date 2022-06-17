using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_move_incircle : MonoBehaviour
{

    public int orbitSpeed;
    Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 targetPosition = transform.position;

        float posX = targetPosition.x + 1.5f;
        float posY = targetPosition.y + 1.5f;
        float posZ = targetPosition.z + 1.5f;

        targetPos = new Vector3(posX, posY, posZ);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(targetPos, Vector3.down, orbitSpeed * Time.deltaTime);
    }

}
