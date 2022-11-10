using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = new Vector2(target.position.x, target.position.y + yOffset);
        transform.position = Vector2.Lerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}