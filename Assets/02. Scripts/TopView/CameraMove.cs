using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{public Transform playerTransform; // 캐릭터의 Transform 컴포넌트

    public float smoothSpeed = 0.125f; // 부드러운 이동을 위한 스피드 값

    private Vector3 offset; // 카메라와 캐릭터 사이의 거리

    void Start()
    {
        // 카메라와 캐릭터 사이의 거리 계산
        offset = transform.position - playerTransform.position;
    }

    void FixedUpdate()
    {
        // 새로운 카메라 위치 계산
        Vector3 desiredPosition = playerTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // 카메라 위치 업데이트
        transform.position = smoothedPosition;
    }
}
