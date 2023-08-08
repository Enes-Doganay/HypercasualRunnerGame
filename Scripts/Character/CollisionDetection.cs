using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CollisionDetection : MonoBehaviour
{
    UIManager UIManager;
    Ragdoll ragdoll;
    Character character;
    Rank rank;
    SkillManager SkillManager;
    private void Start()
    {
        rank = Object.FindObjectOfType<Rank>();
        ragdoll = GetComponent<Ragdoll>();
        character = GetComponentInParent<Character>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle" && character.start)
        {
            character.enabled = false;
            character.start = false;
            collision.rigidbody.isKinematic = false;
            UIManager.Instance.SetGameOverPanel();
            ragdoll.ActivateRagdoll();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Skill")
        {
            SkillManager.Instance.activeSkill = other.gameObject.GetComponent<Skill>().ability.id;
            UIManager.Instance.skillButtonImage.sprite = other.gameObject.GetComponent<Skill>().ability.sprite;
            UIManager.Instance.skillButtonImage.color = Color.white;
        }
        if (other.gameObject.tag == "Win" && character.start)
        {
            character.enabled = false;
            character.start = false;
            rank.enabled = false;
            character.animator.Play("Win");
            UIManager.Instance.SetVictoryPanel();
            character.LevelingUp();
        }
    }
}
