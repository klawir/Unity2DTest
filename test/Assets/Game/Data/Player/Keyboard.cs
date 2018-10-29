using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    private Unit unit;
    private BoxCollider2D collider2D;
    public BladeSetup bladeSetup;

    private void Navigation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            unit.MoveVec -= unit.speedMove;
            unit.IsMoving = true;
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                unit.MoveVec += unit.speedMove;
                unit.IsMoving = true;
            }
            else
                unit.IsMoving = false;
        }
        if (unit.IsMoving)
            unit.PlayWalk();
        else
            unit.PlayIdle();
        transform.position = unit.Move;
    }
    
    private void Attack()
    {
        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Space))
        {
            unit.PlayAttack();
            collider2D.enabled = true;
            if (collider2D.offset.x < unit.colOffset.x && unit.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                collider2D.offset += bladeSetup.offset;
                collider2D.size += bladeSetup.size;
            }
            else
            {
                collider2D.offset = unit.StartColOffset;
                collider2D.size= unit.StartColSize;
            }
        }
        else
        {
            collider2D.enabled = false;
            collider2D.offset = unit.StartColOffset;
            collider2D.size = unit.StartColSize;
        }
    }

	void Start ()
    {
        unit = GetComponent<Unit>();
        collider2D = unit.sword.GetComponent<BoxCollider2D>();
    }
	void Update ()
    {
        Navigation();
        Attack();
    }
}