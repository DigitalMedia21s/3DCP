using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostAI : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent navAgent;

    public bool isMove;

    // Start is called before the first frame update
    void Start()
    {
        //[WIndows] - [AI] - [Navigation] > [Bake] > [Bake]. 귀신 이동 반경에 Static 체크

        target = GameObject.FindGameObjectWithTag("Player").transform; //타겟에 Player 태그 필수
        navAgent = GetComponent<NavMeshAgent>(); //귀신 오브젝트에 NavMeshAgent 컴포넌트 추가

        isMove = true;

        GameObject.Find("PlayerArmature").GetComponent<PlayerControl>().isGhost = true;

        StartGhost();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    isMove = false;
        //}
    }

    void StartGhost()
    {
        StartCoroutine(Ghost());
    }

    IEnumerator Ghost()
    {
        yield return new WaitUntil(() => isMove == true);
        yield return new WaitForSecondsRealtime(1.0f);
        while (isMove == true)
        {
            navAgent.SetDestination(target.position);

            yield return null;
        }

        yield return new WaitUntil(() => isMove == false);
        Debug.Log("공격");
        yield return new WaitForSecondsRealtime(5.0f);
        while (isMove == false)
        {
            navAgent.SetDestination(target.position);

            yield return null;
        }
    }
}