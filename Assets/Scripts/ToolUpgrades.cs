using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class ToolUpgrades : MonoBehaviour
{
    [SerializeField] private TransactionManager TransactionManager;
    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private Button rodUpgrButton;
    [SerializeField] private TextMeshProUGUI rodUpgValueText;
    [SerializeField] private Button reelUpgrButton;
    [SerializeField] private TextMeshProUGUI reelUpgValueText;


    public int rodUpgradeCost;
    public int reelUpgradeCost;
    private Camera mainCam;
    public int RodLevel;
    public int ReelSpeed;    
    void Start()
    {
        mainCam= Camera.main;
        RodLevel = 1;
        ReelSpeed = 1;
        rodUpgradeCost = 10;
        reelUpgradeCost = 10;
    }

    // Update is called once per frame
    void Update()
    {
        EnterUpgrade();
        RodCostControl();
        RodPriceIncrease();
        ReelCostControl();
        ReelPriceIncrease();
        ValueTexter();
        

    }

    
    public void EnterUpgrade()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Ray ray = mainCam.ScreenPointToRay(mousePos);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                   Debug.Log("TIklanabilir");
                    OpenMenu();
                }
            }
        }
    }
    public void OpenMenu()
        {
            upgradePanel.SetActive(true);
        }

    public void CloseMenu()
        {
            upgradePanel.SetActive(false);
        }
    
    public void RodCostControl()
    {
        if(rodUpgradeCost>TransactionManager.totalCoin)
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
        if(reelUpgradeCost>TransactionManager.totalCoin)
        {
            reelUpgrButton.interactable = false;
        }
        else
        {
            reelUpgrButton.interactable = true;
        }
    }
    public void RodPriceIncrease()
    {
        if(RodLevel==1)
        {
            rodUpgradeCost=10;
        }
        else if (RodLevel==2)
        {
            rodUpgradeCost=20;
        }
        else if (RodLevel==3)
        {
            rodUpgradeCost=50;
        }
        else if (RodLevel==4)
        {
            rodUpgradeCost=100;
        }
        else if (RodLevel==5)
        {
            rodUpgradeCost=150;
        }
    }

    public void ReelPriceIncrease()
    {
        if(ReelSpeed==1)
        {
            reelUpgradeCost=10;
        }
        else if (ReelSpeed==2)
        {
            reelUpgradeCost=30;
        }
        else if (ReelSpeed==3)
        {
            reelUpgradeCost=60;
        }
        else if (ReelSpeed==4)
        {
            reelUpgradeCost=120;
        }
        else if (ReelSpeed==5)
        {
            reelUpgradeCost=240;
        }
    }
    public void UpradeRodOne()
    {
        RodLevel++;
        TransactionManager.totalCoin=TransactionManager.totalCoin-rodUpgradeCost;
        Debug.Log("You have"+TransactionManager.totalCoin+"left");
        Debug.Log("Your rod level is 2");
    }

    public void UpradeReelOne()
    {
        ReelSpeed++;
        TransactionManager.totalCoin=TransactionManager.totalCoin-reelUpgradeCost;
        Debug.Log("You have"+TransactionManager.totalCoin+"left");
        Debug.Log("Your reel level is 2");
    }

    public void ValueTexter()
    {
        rodUpgValueText.text=""+rodUpgradeCost;
        reelUpgValueText.text=""+reelUpgradeCost;

    }
}
