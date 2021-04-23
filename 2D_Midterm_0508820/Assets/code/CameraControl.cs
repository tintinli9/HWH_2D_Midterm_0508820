﻿using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("追蹤速度"), Range(0, 50)]
    public float speed = 1.5f;
    [Header("左右邊界")]
    public Vector2 limitX = new Vector2(-12, 8);
    [Header("玩家")]
    public Transform player;

    private void Update()
    {
        Track();
    }

    private void Track()
    {
        Vector3 posCam = transform.position;
        Vector3 posPla = player.position;

        posCam = Vector3.Lerp(posCam, posPla, 0.5f * speed * Time.deltaTime);
        posCam.z = -10;
        posCam.y = 0;
        posCam.x = Mathf.Clamp(posCam.x, limitX.x, limitX.y);

        transform.position = posCam;
    }


}
