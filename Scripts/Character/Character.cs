using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public enum SIDE { Mid,Left,Right}
public class Character : MonoBehaviour
{
    [Header("Character Data")]
    public int level = 1;
    public int gold;
    public int moveSpeedLevel;
    public int luckLevel;
    



    public static Character Instance { get; private set; }
    public CharacterData characterData;



    UIManager UIManager;

    [SerializeField] EventTrigger eventTrigger;

    public Animator animator;
    public CharacterController characterController;

    public SIDE mSide = SIDE.Mid;
    
    float newXPos = 0f;

    public bool swipeLeft, swipeRight, swipeUp, swipeDown;
    public bool inJump;
    
    public float swipeRange;
    
    public float xValue;
    public float x,y;
    public float moveSpeed;

    Vector2 startTouchPosition;
    Vector2 endTouchPosition;
    Vector2 distance;
    public bool boost;
    public bool start = false;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        SetMoveSpeed();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        SwipeInput();
        if (start)
        {
            Swipe();
        }
    }

    public void SwipeInput()
    {
        swipeLeft = swipeRight = false;



        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchPosition = Input.GetTouch(0).position;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTouchPosition = Input.GetTouch(0).position;
                distance = endTouchPosition - startTouchPosition;

                if (distance.x >= swipeRange)
                {
                    swipeRight = true;
                }
                else if (distance.x <= -swipeRange)
                {
                    swipeLeft = true;
                }

                if (distance.y >= swipeRange)
                    swipeUp = true;
            }
        }
    }

    public void Swipe()
    {
        if (swipeLeft)
        {
            if (mSide == SIDE.Mid)
            {
                newXPos = -xValue;
                mSide = SIDE.Left;
            }
            else if (mSide == SIDE.Right)
            {
                newXPos = 0;
                mSide = SIDE.Mid;
            }
            animator.Play("Left");
        }
        else if (swipeRight)
        {
            if (mSide == SIDE.Mid)
            {
                newXPos = xValue;
                mSide = SIDE.Right;
            }
            else if (mSide == SIDE.Left)
            {
                newXPos = 0;
                mSide = SIDE.Mid;
            }
            animator.Play("Right");
        }
        Movement();
        Jump();
    }

    public void Movement()
    {
        x = Mathf.Lerp(x, newXPos, Time.deltaTime * characterData.dodgeSpeed);
        Vector3 moveVector = new Vector3(x - transform.position.x, y * Time.deltaTime, moveSpeed * Time.deltaTime);
        characterController.Move(moveVector);
    }

    public void Jump()
    {
        if (characterController.isGrounded)
        {
            if (swipeUp)
            {
                y = characterData.jumpPower;
                inJump = true;
                animator.Play("Jump");
                swipeUp = false;
            }
        }
        else
        {
            y -= characterData.jumpPower * 2 * Time.deltaTime;
            if(characterController.velocity.y < -0.1f)
            {
                inJump = false;
                animator.Play("Falling");
            }
        }
    }
    public void Started()
    {
        start = true;
        animator.SetBool("Start", start);
        UIManager.Instance.SetStartPanel();
    }
    public void LevelingUp(){ characterData.level++; }
    public int GetLevel() { return characterData.level; }
    public float SetMoveSpeed()
    {
        moveSpeed = characterData.moveSpeed;
        return moveSpeed;
    }
}
