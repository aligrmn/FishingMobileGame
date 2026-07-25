using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpgradeUIBehaciour : MonoBehaviour
{
    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private Button rodUpgrButton;
    [SerializeField] private TextMeshProUGUI rodUpgValueText;
    [SerializeField] private Button reelUpgrButton;
    [SerializeField] private TextMeshProUGUI reelUpgValueText;
    [SerializeField] private ToolUpgrades toolUpgrades;
    void Start()
    {
        
    }

    void Update()
    {
        ValueTexter();
        RodCostControl();
        ReelCostControl();
    }
    public void UpradeRodOne()
    {
        GameData.Instance.rodLevel++;
        GameData.Instance.totalCoin = GameData.Instance.totalCoin-toolUpgrades.rodUpgradeCost;
        Debug.Log("You have"+GameData.Instance.totalCoin+"left");
        Debug.Log("Your rod level is 2");
    }

     public void UpradeReelOne()
    {
        GameData.Instance.reelSpeed++;
        GameData.Instance.totalCoin = GameData.Instance.totalCoin-toolUpgrades.reelUpgradeCost;
        Debug.Log("You have"+GameData.Instance.totalCoin+"left");
        Debug.Log("Your reel level is 2");
    }

    public void ValueTexter()
    {
        rodUpgValueText.text=""+toolUpgrades.rodUpgradeCost;
        reelUpgValueText.text=""+toolUpgrades.reelUpgradeCost;
    }
    public void CloseMenu()
    {
        upgradePanel.SetActive(false);
    }
    public void RodCostControl()
    {
        if(toolUpgrades.rodUpgradeCost>GameData.Instance.totalCoin)
        {
            rodUpgrButton.interactable = false;
        }
        else
        {
            rodUpgrButton.interactable = true;
        }
    }
    public void ReelCostControl()
    {
        if(toolUpgrades.reelUpgradeCost>GameData.Instance.totalCoin)
        {
            reelUpgrButton.interactable = false;
        }
        else
        {
            reelUpgrButton.interactable = true;
        }
    }
}
