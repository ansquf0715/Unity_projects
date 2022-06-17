using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_move_sts : MonoBehaviour
{
    Vector3 pos;
    public float delta = 2.0f;
    public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = pos;
        v.x += delta * Mathf.Sin(Time.time * speed); //�¿� �̵��� �ִ�ġ �� ����ó��
        transform.position = v;
    }
}
