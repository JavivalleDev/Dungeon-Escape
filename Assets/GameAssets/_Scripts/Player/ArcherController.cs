using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(ArcherAnimatorController))]
[RequireComponent(typeof(NavMeshAgent))]
public class ArcherController : MonoBehaviour
{
    private ArcherAnimatorController _archerAnimator;
    private NavMeshAgent _navMeshAgent;

    private bool _bCrouching;

    void Awake()
    {
        _archerAnimator = GetComponent<ArcherAnimatorController>();
        _navMeshAgent = GetComponent<NavMeshAgent>();

        _bCrouching = false;
    }

    void ScreenRaycast()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.transform.CompareTag("Walkable"))
            {
                Move(hit.point);
            }
        }
    }

    void Move(Vector3 destination)
    {
        _navMeshAgent.SetDestination(destination);
        _archerAnimator.SetSpeed(_navMeshAgent.speed);
    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _bCrouching = !_bCrouching;
            _archerAnimator.SetCrouch(_bCrouching);
        }
    }

}
