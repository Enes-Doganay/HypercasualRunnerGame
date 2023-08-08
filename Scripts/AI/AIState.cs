using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIStateID
{
    Idle,
    Running,
    Death,
    Win
}
public interface AIState
{
    AIStateID GetID();
    void Enter(AI ai);
    void Update(AI ai);
    void Exit(AI ai);
}