using System.Collections;
using UnityEngine;

public class Buff : MonoBehaviour
{
    [SerializeField]
    protected Ability ability;

    [SerializeField]
    protected float buffValue;
    protected float buffTime = 3f;

    public Character Character;
    public AI aI;

    protected virtual void OnTriggerEnter(Collider other)
    {
    }

    protected virtual IEnumerator ApplyToPlayer(float buff)
    {
        buff += buffValue;
        Debug.Log(buff);
        yield return new WaitForSeconds(buffTime);
        TakeBackBuffPlayer();
    }
    protected virtual IEnumerator ApplyToAI(AI aI,float buff)
    {
        buff += buffValue;
        yield return new WaitForSeconds(buffTime);
        TakeBackBuffAI();
    }

    protected virtual void TakeBackBuffPlayer(float buff=0,float defaultValue = 0)
    {
        buff = defaultValue;
    }
    protected virtual void TakeBackBuffAI(float buff = 0, float defaultValue = 0)
    {
        buff = defaultValue;

    }
}
