using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraMove : MonoBehaviour
{
    public Transform playerTransform; // 캐릭터의 Transform 컴포넌트
    
    [Header("하위 옵션은 Serialized Field임. 디버그 확인 용도이므로 수정 금지")] 
    [SerializeField] private bool allowCameraMove = true;

    private void LateUpdate()
    {
        if (allowCameraMove)
        {
            var position = playerTransform.position;
            var targetPos = new Vector3(position.x, position.y, -10.0f);
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 10f);
        }
    }

    public void ChangeCameraState() // 카메라 이동 상태 변환 함수. 필요할 때 호출하면 토글 방식으로 변환
    {
        if (allowCameraMove) // 카메라의 부드러운 이동 상태 -> 플레이어 원점 고정 상태
        {
            allowCameraMove = false;
            transform.parent = playerTransform;
        }
        else // 플레이어 원점 고정 상태 -> 카메라의 부드러운 이동 상태 
        {
            allowCameraMove = true;
            transform.parent = null;
        }
    }
}