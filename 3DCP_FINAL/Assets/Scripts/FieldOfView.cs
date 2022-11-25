using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;
    //있어야함, 왜냐면 타겟 사이에 다른 오브젝트가 있는데 그 오브젝트를 투과해서 뒤의 타겟오브젝트를 볼 수 있음

    public List<GameObject> visibleTargets = new List<GameObject>();
    GameObject targeting;
    float shortDis;

    public GameObject ghost;

    //public GameObject targetingUI;

    void Start()
    { //플레이 시 FindTargetsDelay 코루틴을 실행한다. 0.2초 간격으로
        StartCoroutine("FindTargetsDelay", 0.2f);
    }

    IEnumerator FindTargetsDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindTargets();
        }
    }

    void FindTargets()
    {
        visibleTargets.Clear();
        Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask); // viewRadius를 반지름으로 한 원 영역 내 targetMask 레이어인 콜라이더를 모두 가져옴
        for (int i = 0; i < targetInViewRadius.Length; i++) //ViewRadius 안에 있는 타겟의 개수 = 배열의 개수보다 i가 작을 때 for 실행
        {
            Transform target = targetInViewRadius[i].transform; //타겟[i]의 위치
            Vector3 dirToTarget = (target.position - transform.position).normalized; //vector3타입의 타겟의 방향 변수 선언 = 타겟의 방향벡터, 타겟의 position - 이 게임오브젝트의 position) normalized = 벡터 크기 정규화 = 단위벡터화
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2) // 전방 벡터와 타겟방향벡터의 크기가 시야각의 1/2이면 = 시야각 안에 타겟 존재
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position); //타겟과의 거리를 계산
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask)) //레이캐스트를 쐇는데 obstacleMask가 아닐 때 참이고 아래를 실행함
                {
                    visibleTargets.Add(target.transform.gameObject); //게임오브젝트가 리스트에 들어가긴 함, 
                    Debug.DrawRay(transform.position, dirToTarget * 10f, Color.red, 5f);
                    print("raycast hit!");
                }
            }
        }


        if (visibleTargets.Count != 0) //범위 안에 있는 게임오브젝트 리스트 존재 시, 거리 계산 시작
        {
            //if (targetingUI != null) //시야 범위 안에 있고, 이전 targetingUI가 남아 있을 경우, UI 꺼줌
            //{
            //    targetingUI.SetActive(false);
            //}

            targeting = visibleTargets[0];
            //첫번째를 지정, 첫번째는 타겟팅 대상, 실행했을 때 리스트에 값이 없으면 ArgumentOutOfRangeException 에러가 나옴
            /*visibleTargets[0] != null visibleTargets[0]의 값이 비어있지 않으면 실행하려고 했으나 계속 에러 발생.
           * 리스트 개수를 통해 해결함 visibleTargets.Count != 0 
             */
            shortDis = Vector3.Distance(transform.position, visibleTargets[0].transform.position); //visibleTargets 리스트의 첫번째와의 거리를 기준으로 잡기

            //리스트에서 가장 가까운 거리의 게임 오브젝트 찾기
            foreach (GameObject found in visibleTargets)
            {
                float distance = Vector3.Distance(transform.position, found.transform.position);
                if (distance < shortDis)
                {
                    targeting = found;
                    shortDis = distance;
                }
            }

            Debug.Log(targeting.name); //가장 가까운 거리의 게임오브젝트찾음

            if (targeting.name == "Mirror")
            {
                ghost.SetActive(true);
            }

            //// 가장 가까운 거리의 게임 오브젝트의 자식 오브젝트 Canvas에 접근
            //targetingUI = targeting.transform.Find("Canvas").transform.gameObject;

            ////Canvas 활성화 = targetingUI활성화
            //targetingUI.SetActive(true);
        }

        ////범위 안에 게임 오브젝트가 없고, targetingUI가 비어있지 않으면 이전 UI 비활성화
        //else if (visibleTargets.Count == 0 && targetingUI != null)
        //{
        //    targetingUI.SetActive(false);

        //}
    }
}
