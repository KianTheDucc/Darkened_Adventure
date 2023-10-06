using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 temp;
    public float MinX, MaxX, MinY, MaxY;
    private Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        temp = transform.position;
        temp.x = Player.position.x;
        temp.y = Player.position.y;
        if (temp.x < MinX)
        {
            temp.x = MinX;

        }
        if (temp.x > MaxX)
        {
            temp.x = MaxX;
        }
        if (temp.y < MinY)
        {
            temp.y = MinY;
        }
        if (temp.y > MaxY)
        {
            temp.y = MaxY;
        }
        transform.position = temp;
    }
}