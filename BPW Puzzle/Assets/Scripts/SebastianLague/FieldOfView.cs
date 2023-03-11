using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SebastianLague
{
    public class FieldOfView : MonoBehaviour
    {
        public float viewRadius;

        [Range(0, 360)] public float viewAngle;

        public LayerMask targetMask;
        public LayerMask obstacleMask;

        //[HideInInspector] public List<Transform> visibleTargets = new List<Transform>();

        [SerializeField] private AI _ai;

        void Start()
        {
            //StartCoroutine ("FindTargetsWithDelay", .01f);
        }

        private void Update()
        {
            FindVisibleTargets();
        }

        IEnumerator FindTargetsWithDelay(float delay) //Optimalisatie ding
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);
                FindVisibleTargets();
            }
        }

        void FindVisibleTargets() //Currently causes to set the _ai.Maymove on False when the target enters the overlapsphere.
        {
            List<AI> visibleTargets = new();
            Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

            for (int i = 0; i < targetsInViewRadius.Length; i++)
            {
                Transform target = targetsInViewRadius[i].transform;
                Vector3 dirToTarget = (target.position - transform.position).normalized;

                if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
                {
                    float dstToTarget = Vector3.Distance(transform.position, target.position);

                    if (Physics.Raycast(transform.position, dirToTarget, dstToTarget, ~targetMask))
                    {
                        visibleTargets.Add(target.GetComponent<AI>());
                        Debug.Log("saw a weeping angel");
                        _ai.MayMove = false;
                    }
                }
            }
        }


        public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
        {
            if (!angleIsGlobal)
            {
                angleInDegrees += transform.eulerAngles.y;
            }

            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        }
    }
}