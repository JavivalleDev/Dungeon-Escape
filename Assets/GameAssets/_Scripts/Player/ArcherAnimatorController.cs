using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent((typeof(Animator)))]
public class ArcherAnimatorController : MonoBehaviour
{
    private const string SPEED_KEY = "Speed";
    private const string EQUIP_KEY = "Equip";
    private const string EQUIPED_KEY = "Equiped";
    private const string DISARM_KEY = "Disarm";
    private const string SHOOT_KEY = "Shoot";

    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat(SPEED_KEY, speed);
    }

    public void SetEquip()
    {
        _animator.SetTrigger(EQUIP_KEY);
        _animator.SetBool(EQUIPED_KEY, true);
    }

    public void SetDisarm()
    {
        _animator.SetTrigger(DISARM_KEY);
        _animator.SetBool(EQUIPED_KEY, false);
    }

    public void SetShoot(bool shoot)
    {
        _animator.SetBool(SHOOT_KEY, shoot);
    }

    public void SetCrouch(bool crouching)
    {
        _animator.SetLayerWeight(1, crouching ? 1 : 0);
    }
}
