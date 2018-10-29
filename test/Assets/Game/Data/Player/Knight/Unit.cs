using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Unit : MonoBehaviour
{
    public Animator animator;
    public GameObject sword;
    public Vector2 colOffset;
    public Vector2 colSize;
    private Vector2 move;

    private Vector2 startColOffset;
    private Vector2 startColSize;

    private bool isMoveing;
    public float speedMove;

    public Vector2 Move
    {
        get { return move; }
        set { move = value; }
    }
    public float MoveVec
    {
        get { return move.x; }
        set { move.x = value; }
    }

    public void PlayIdle()
    {
        animator.SetBool("move", false);
        animator.SetBool("idle", true);
        animator.SetBool("attack", false);
        animator.SetFloat("Speed", 1f);
    }
    public void PlayWalk()
    {
        animator.SetBool("move", true);
        animator.SetBool("idle", false);
        animator.SetFloat("Speed", 1f);
    }
    public void PlayAttack()
    {
        animator.SetBool("attack", true);
        animator.SetBool("idle", false);
        animator.SetFloat("Speed", 1f);
    }
    public bool IsMoving
    {
        get { return isMoveing; }
        set { isMoveing = value; }
    }
    public Vector2 StartColOffset
    {
        get { return startColOffset; }
    }
    public Vector2 StartColSize
    {
        get { return startColSize; }
    }

    void Start()
    {
        move = transform.position;
        animator = GetComponent<Animator>();
        startColOffset= sword.GetComponent<BoxCollider2D>().offset;
        startColSize = sword.GetComponent<BoxCollider2D>().size;
        colOffset += startColOffset;
        colSize += startColSize;
    }
}