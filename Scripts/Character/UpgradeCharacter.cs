using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpgradeCharacter : MonoBehaviour
{
    [SerializeField] UpgradeSO[] upgrade;
    [SerializeField] CharacterData characterData;
    [SerializeField] TextMeshProUGUI[] costText;
    [SerializeField] TextMeshProUGUI[] upgradeLevelText;
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] Button[] upgradeButton;

    private void Start()
    {
        RefreshUI();
    }

    public bool CheckPurchaseble(int i)
    {
        return characterData.gold >= GetUpgradeCost(i);
    }
    public void Purchase(int i)
    {
        if (CheckPurchaseble(i))
        {
            characterData.gold -= GetUpgradeCost(i);
            upgrade[i].level += 1;
            if (i == 0)
                characterData.moveSpeed = characterData.moveSpeed + upgrade[0].level * 0.2f;
            RefreshUI();
        }
    }

    public float GetUpgradeCost(int i)
    {
        return upgrade[i].baseCost * upgrade[i].level;
    }
    public int GetLevel(int i)
    {
        return upgrade[i].level;
    }
    public void RefreshUI()
    {
        for (int i = 0; i < upgradeLevelText.Length; i++)
        {
            upgradeLevelText[i].text = "Level " + GetLevel(i).ToString();
            costText[i].text = GetUpgradeCost(i).ToString();
            goldText.text = characterData.gold.ToString();
            if (!CheckPurchaseble(i))
            {
                upgradeButton[i].interactable = false;
                costText[i].color = Color.red;
            }
            else
            {
                upgradeButton[i].interactable = true;
                costText[i].color = Color.yellow;
            }
        }

    }
}
