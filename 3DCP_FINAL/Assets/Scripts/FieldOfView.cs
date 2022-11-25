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
    //�־����, �ֳĸ� Ÿ�� ���̿� �ٸ� ������Ʈ�� �ִµ� �� ������Ʈ�� �����ؼ� ���� Ÿ�ٿ�����Ʈ�� �� �� ����

    public List<GameObject> visibleTargets = new List<GameObject>();
    GameObject targeting;
    float shortDis;

    public GameObject ghost;

    //public GameObject targetingUI;

    void Start()
    { //�÷��� �� FindTargetsDelay �ڷ�ƾ�� �����Ѵ�. 0.2�� ��������
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
        Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask); // viewRadius�� ���������� �� �� ���� �� targetMask ���̾��� �ݶ��̴��� ��� ������
        for (int i = 0; i < targetInViewRadius.Length; i++) //ViewRadius �ȿ� �ִ� Ÿ���� ���� = �迭�� �������� i�� ���� �� for ����
        {
            Transform target = targetInViewRadius[i].transform; //Ÿ��[i]�� ��ġ
            Vector3 dirToTarget = (target.position - transform.position).normalized; //vector3Ÿ���� Ÿ���� ���� ���� ���� = Ÿ���� ���⺤��, Ÿ���� position - �� ���ӿ�����Ʈ�� position) normalized = ���� ũ�� ����ȭ = ��������ȭ
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2) // ���� ���Ϳ� Ÿ�ٹ��⺤���� ũ�Ⱑ �þ߰��� 1/2�̸� = �þ߰� �ȿ� Ÿ�� ����
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position); //Ÿ�ٰ��� �Ÿ��� ���
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask)) //����ĳ��Ʈ�� �i�µ� obstacleMask�� �ƴ� �� ���̰� �Ʒ��� ������
                {
                    visibleTargets.Add(target.transform.gameObject); //���ӿ�����Ʈ�� ����Ʈ�� ���� ��, 
                    Debug.DrawRay(transform.position, dirToTarget * 10f, Color.red, 5f);
                    print("raycast hit!");
                }
            }
        }


        if (visibleTargets.Count != 0) //���� �ȿ� �ִ� ���ӿ�����Ʈ ����Ʈ ���� ��, �Ÿ� ��� ����
        {
            //if (targetingUI != null) //�þ� ���� �ȿ� �ְ�, ���� targetingUI�� ���� ���� ���, UI ����
            //{
            //    targetingUI.SetActive(false);
            //}

            targeting = visibleTargets[0];
            //ù��°�� ����, ù��°�� Ÿ���� ���, �������� �� ����Ʈ�� ���� ������ ArgumentOutOfRangeException ������ ����
            /*visibleTargets[0] != null visibleTargets[0]�� ���� ������� ������ �����Ϸ��� ������ ��� ���� �߻�.
           * ����Ʈ ������ ���� �ذ��� visibleTargets.Count != 0 
             */
            shortDis = Vector3.Distance(transform.position, visibleTargets[0].transform.position); //visibleTargets ����Ʈ�� ù��°���� �Ÿ��� �������� ���

            //����Ʈ���� ���� ����� �Ÿ��� ���� ������Ʈ ã��
            foreach (GameObject found in visibleTargets)
            {
                float distance = Vector3.Distance(transform.position, found.transform.position);
                if (distance < shortDis)
                {
                    targeting = found;
                    shortDis = distance;
                }
            }

            Debug.Log(targeting.name); //���� ����� �Ÿ��� ���ӿ�����Ʈã��

            if (targeting.name == "Mirror")
            {
                ghost.SetActive(true);
            }

            //// ���� ����� �Ÿ��� ���� ������Ʈ�� �ڽ� ������Ʈ Canvas�� ����
            //targetingUI = targeting.transform.Find("Canvas").transform.gameObject;

            ////Canvas Ȱ��ȭ = targetingUIȰ��ȭ
            //targetingUI.SetActive(true);
        }

        ////���� �ȿ� ���� ������Ʈ�� ����, targetingUI�� ������� ������ ���� UI ��Ȱ��ȭ
        //else if (visibleTargets.Count == 0 && targetingUI != null)
        //{
        //    targetingUI.SetActive(false);

        //}
    }
}
