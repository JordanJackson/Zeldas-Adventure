using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCamera : MonoBehaviour 
{
    Transform playerTransform;
    Transform currentSceneRoot;
    public Vector2 roomDimensions;
    public Vector3 roomOffset;
    Vector3 targetPosition;

    public float kh;

    private void Start()
    {
        SetPlayerTransform();
    }

    private void Update()
    {
        if (!playerTransform)
        {
            SetPlayerTransform();
        }
        else
        {
            float posX = Mathf.RoundToInt(playerTransform.position.x / roomDimensions.x) * roomDimensions.x;
            float posZ = Mathf.RoundToInt(playerTransform.position.z / roomDimensions.y) * roomDimensions.y;
            targetPosition =  new Vector3(posX, 0.0f, posZ) + roomOffset;
            this.transform.position += (targetPosition - this.transform.position) * kh * Time.deltaTime;
        }
    }

    void SetPlayerTransform()
    {
        Player player = FindObjectOfType<Player>();
        if (player)
        {
            playerTransform = player.transform;
        }
    }
}
