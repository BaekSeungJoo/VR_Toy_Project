using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public BulletObjectPool bulletObjPool;

    // { 총알 관련 변수
    // public Transform bulletImpact = default;          // 총알 파편 효과
    // private ParticleSystem bulletEffect = default;    // 총알 파편 파티클 시스템
    // private AudioSource bulletAudio = default;        // 총알 발사 사운드
    // } 총알 관련 변수

    // 조준점 관련 변수
    // public Transform crosshair;

    private void Start()
    {
        // 총알 FX(Effect) 파티클 시스템 컴포넌트 가져오기
        // bulletEffect = bulletImpact.GetComponent<ParticleSystem>();

        // 총알 FX 오디오 소스 컴포넌트 가져오기
        // bulletAudio = bulletImpact.GetComponent<AudioSource>();
    }

    private void Update()
    {
        // 크로스 헤어 표시
        //BSJVRInput.DrawCrosshair(crosshair);

        // 사용자가 IndexTrigger 버튼을 누르면
        if(BSJVRInput.GetDown(BSJVRInput.Button.IndexTrigger))
        {
            // 컨트롤러의 진동 재생
            BSJVRInput.PlayVibration(0.1f, 1f, 2f, BSJVRInput.Controller.RTouch);

            // 총알 발싸~
            GameObject bulletObj = bulletObjPool.GetPoolObj(PoolObjType.Bullet01);
            bulletObj.SetActive(true);

            bulletObj.transform.position = BSJVRInput.RHand.position;
            bulletObj.transform.rotation = BSJVRInput.RHand.rotation;


            // REGACY:
            //// { 총알 오디오 재생
            //bulletAudio.Stop();
            //bulletAudio.Play();
            //// } 총알 오디오 재생

            //// Ray를 카메라의 위치로부터 나가도록 만든다.
            //Ray ray = new Ray(BSJVRInput.RHandPosition, BSJVRInput.RHandDirection);

            //// Ray의 충돌 정보를 저장하기 위한 변수 지정
            //RaycastHit hitInfo = default;

            //// 플레이어 레이어 얻어오기
            //int playerLayer = 1 << LayerMask.NameToLayer("Player");

            //// 타워 레이어 얻어오기
            //int towerLayer = 1 << LayerMask.NameToLayer("Tower");
            //int layerMask = playerLayer | towerLayer;

            //// Ray를 쏜다. ray가 부딪힌 정보는 hitInfo에 담긴다.
            //if(Physics.Raycast(ray, out hitInfo, 200, ~layerMask))
            //{
            //    // 총알 이펙트 진행되고 있으면 멈추고 재생
            //    bulletEffect.Stop();
            //    bulletEffect.Play();

            //    // 부딪힌 지점 바로 위에서 이펙트가 보이도록 설정
            //    bulletImpact.position = hitInfo.point;

            //    // 부딪힌 지점의 방향으로 총알 이펙트의 방향을 설정
            //    bulletImpact.forward = hitInfo.normal;
            //}

        }
    }
}
