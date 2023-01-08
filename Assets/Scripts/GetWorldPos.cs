using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWorldPos : MonoBehaviour
{
    public float worldPosX;
    public float worldPosY;
    public float worldPosZ;
    void Update()
    {
        worldPosX = transform.position.x;
        worldPosY = transform.position.y;
        worldPosZ = transform.position.z;
    }
}
