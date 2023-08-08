using UnityEngine;

public class AI : MonoBehaviour
{
    public static AI Instance;
    public AIStateMachine stateMachine;
    public AIStateID initialState;
    public Animator animator;
    public Ragdoll ragdoll;
    public GameObject leftRayObj;
    public GameObject midRayObj;
    public GameObject rightRayObj;
    public CharacterController characterController;
    public AICollisionDetection collisionDetection;
    public Character Character;
    public CharacterData data;
    public float moveSpeed;
    public float y;

    private void Start()
    {
        Instance = this;
        moveSpeed = SetMoveSpeed();
        collisionDetection = GetComponentInChildren<AICollisionDetection>();
        Character = Character.Instance;
        characterController = GetComponent<CharacterController>();
        animator.GetComponent<Animator>();
        ragdoll = GetComponentInChildren<Ragdoll>();
        stateMachine = new AIStateMachine(this);
        stateMachine.RegisterState(new AIRunningState());
        stateMachine.RegisterState(new AIDeathState());
        stateMachine.RegisterState(new AIWinState());
        stateMachine.RegisterState(new AIIdleState());
        
        stateMachine.ChangeState(initialState);
    }
    private void Update()
    {
        stateMachine.Update();
        if(y > 0)
        {
            y -= 7f * 2 * Time.deltaTime;
        }
    }
    public float SetMoveSpeed()
    {
        return Random.Range(data.moveSpeed - 5, data.moveSpeed + 5);
    }
}
