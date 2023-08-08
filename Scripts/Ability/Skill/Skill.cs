using UnityEngine;
using System.Collections;
public class Skill : MonoBehaviour
{
    public Ability ability;
    public Vector3 spawnPoint;
    protected Character Character;
    public float forceVal = 4f;
    public UIManager UIManager;
    public ParticleSystem explosion;
    public AudioSource audioSource;

    public virtual void UseSkill(float forceValue)
    {
        SetSpawnPoint();
        GameObject skill = Instantiate(ability.abilityPrefab, spawnPoint, Quaternion.identity);
        Vector3 force = new Vector3(0, 0, Character.Instance.moveSpeed * forceValue);
        skill.GetComponentInChildren<Rigidbody>().AddForce(force, ForceMode.Impulse);
        UIManager.Instance.skillButtonImage.color = Color.clear;
    }
    public virtual void SetSpawnPoint()
    {
        spawnPoint = GameObject.Find("SkillSpawnPoint").transform.position;
    }
    public virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            ApplySkillToPlayer();
        }
        if (collision.gameObject.tag == "AI")
        {
            ApplySkillToAI(collision.gameObject.GetComponentInParent<AI>());
        }
    }
    public virtual void ApplySkillToPlayer()
    {
        ApplySkill();
    }
    public virtual void ApplySkillToAI(AI aI)
    {
        ApplySkill();
    }
    public virtual void ApplySkill()
    {
        explosion.Play();
        audioSource.Play();
    }
}
