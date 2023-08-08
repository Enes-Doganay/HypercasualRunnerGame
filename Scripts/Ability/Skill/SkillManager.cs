using UnityEngine;
using UnityEngine.UI;
public class SkillManager : MonoBehaviour
{
    public Skill[] skils;
    public int activeSkill = 0;
    public UIManager uIManager;
    public static SkillManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void UseSkill()
    {
        if (activeSkill != -1)
        {
            Debug.Log("Force :" + skils[activeSkill].forceVal);
            skils[activeSkill].UseSkill(skils[activeSkill].forceVal);
        }
        activeSkill = -1;
    }
}
