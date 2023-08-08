using System.Collections;
using UnityEngine;

public class Boost : MonoBehaviour
{
    Character Character;
    private bool characterBoost = false;
    private bool aIBoost = false;
    ParticleSystem boostEffect;
    private void Start()
    {
        boostEffect = GameObject.Find("BoostEffect").GetComponent<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !characterBoost)
        {
            StartCoroutine(SetCharacterBoost());
        }
        if(other.gameObject.tag == "AI" && !aIBoost)
        {
            StartCoroutine(SetAIBoost(other.gameObject.GetComponentInParent<AI>()));
        }
    }

    IEnumerator SetCharacterBoost()
    {
        characterBoost = true;
        boostEffect.Play();
        Character.Instance.y = Character.Instance.characterData.jumpPower;
        Character.Instance.moveSpeed += 10f;
        Debug.Log("Character Boost" + characterBoost);
        Debug.Log(Character.Instance.moveSpeed);
        yield return new WaitForSeconds(1f);
        Character.Instance.moveSpeed = Character.Instance.SetMoveSpeed();
        boostEffect.Stop();
        characterBoost = false;
        Debug.Log("Character Boost" + characterBoost);
        Debug.Log(Character.Instance.moveSpeed);
    }

    IEnumerator SetAIBoost(AI aI)
    {
        aIBoost = true;
        aI.moveSpeed = aI.SetMoveSpeed() + 10f;
        aI.y = 7f;
        yield return new WaitForSeconds(1f);
        aIBoost = false;
        aI.SetMoveSpeed();
    }
}
