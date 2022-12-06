using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostAI : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent navAgent;

    public bool isMove;
    public bool isGhost;

    // Start is called before the first frame update
    void Start()
    {
        //[WIndows] - [AI] - [Navigation] > [Bake] > [Bake]. 귀신 이동 반경에 Static 체크

        target = GameObject.FindGameObjectWithTag("Player").transform; //타겟에 Player 태그 필수
        navAgent = GetComponent<NavMeshAgent>(); //귀신 오브젝트에 NavMeshAgent 컴포넌트 추가

        isGhost = true;
        isMove = true;

        //StartGhost();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove == true)
        {
            navAgent.SetDestination(target.position);
        }
    }

    //void StartGhost()
    //{
    //    StartCoroutine(StopGhost());
    //}

    //IEnumerator StopGhost()
    //{
    //    isCorPlay = true;

    //    yield return new WaitUntil(() => isMove == true);
    //    yield return new WaitForSecondsRealtime(1.0f);

    //    //while (isMove == true)
    //    //{
    //    //    navAgent.SetDestination(target.position);

    //    //    yield return null;
    //    //}
    //    //navAgent.isStopped = true;

    //    //yield return new WaitUntil(() => isMove == false);
    //    //Debug.Log("공격");
    //    //yield return new WaitForSecondsRealtime(5.0f);

    //    //navAgent.isStopped = false;
    //    //isMove = true;

    //    //isCorPlay = false;

    //    //while (isCorPlay == false)
    //    //{
    //    //    StartCoroutine(Ghost());

    //    //    yield return null;
    //    //}
    //}
}