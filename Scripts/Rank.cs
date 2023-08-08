using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Rank : MonoBehaviour
{
    Character Character;
    public AISpawner ai;
    public TextMeshProUGUI rankText;
    public int rank;
    int inFrontOf;
    private void Start()
    {
        InvokeRepeating("CheckRank", 0.1f, 1f);
    }
    void CheckRank()
    {
        inFrontOf = 0;
        for (int i = 0; i < ai.aITransform.Length; i++)
        {
            if (Character.Instance.transform.position.z > ai.aITransform[i].position.z)
            {
                inFrontOf++;
            }
        }
        rank = 5 - inFrontOf;
        if(Character.Instance.start)
            rankText.text = rank.ToString() + "/ 5";
    }
}