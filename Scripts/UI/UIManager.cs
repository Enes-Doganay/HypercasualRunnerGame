using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour,IDataPersistence
{
    public static UIManager Instance { get; private set; }

    public GameObject startPanel;
    public GameObject gameOverPanel;
    public GameObject victoryPanel;
    [SerializeField] TextMeshProUGUI rankText;
    [SerializeField] TextMeshProUGUI goldEarningText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] CharacterData characterData;
    Rank rank;
    string suffix;
    int gold;
    
    public bool button = false;
    public Button skillButton;
    public Image skillButtonImage;
    Character Character;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        rank = Object.FindObjectOfType<Rank>();
        //levelText.text = "Level " + characterData.level.ToString();
        //goldText.text = characterData.gold.ToString();
        levelText.text = "Level " + Character.Instance.level.ToString();
        goldText.text = Character.Instance.gold.ToString();
    }
    public void SetStartPanel()
    {
        startPanel.SetActive(false);
    }
    public void SetGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    public void SetVictoryPanel()
    {
        victoryPanel.SetActive(true);
        SetSuffix();
        SetGoldEarning();
        rankText.text = rank.rank.ToString() + suffix;
        goldEarningText.text = "You earned " + gold.ToString() + " gold";
        Character.Instance.level++;
    }
    private void SetSuffix()
    {
        switch (rank.rank)
        {
            case 1: suffix = "st";
                break;
            case 2: suffix = "nd";
                break;
            case 3: suffix = "rd";
                break;
            default: suffix = "th";
                break;
        }
    }
    private void SetGoldEarning()
    {
        switch (rank.rank)
        {
            case 1:
                gold = 200;
                Character.Instance.gold += gold;
                break;
            case 2:
                gold = 100;
                Character.Instance.gold += gold;
                break;
            case 3:
                gold = 50;
                Character.Instance.gold += gold;
                break;
            default:
                gold = 10;
                Character.Instance.gold += gold;
                break;
        }
    }
    public void SetSkillButton(Sprite sprite)
    {
        skillButton.GetComponent<Image>().sprite = sprite;
    }

    public void LoadData(GameData data)
    {
        Character.Instance.gold = data.gold;
        Character.Instance.level = data.level;
    }

    public void SaveData(ref GameData data)
    {
        data.gold = Character.Instance.gold;
        data.level = Character.Instance.level;
    }
}
