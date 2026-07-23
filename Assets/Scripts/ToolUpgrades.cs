using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ToolUpgrades : MonoBehaviour
{
    [SerializeField] private TransactionManager TransactionManager;
    [SerializeField] private GameObject UpgradePanel;
    [SerializeField] private Button rodUpgrButton;

    public int RodUpgradeCost;
    private Camera mainCam;
    public int RodLevel;
    public int ReelSpeed;    
    void Start()
    {
        mainCam= Camera.main;
        RodLevel = 1;
        ReelSpeed = 1;
        RodUpgradeCost = 10;
    }

    // Update is called once per frame
    void Update()
    {
        EnterUpgrade();
        CostControl();
        PriceIncrease();
        

    }

    public void OpenMenu()
        {
            UpgradePanel.SetActive(true);
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
                    OpenMenu();
                }
            }
        }
    }
    
    public void CostControl()
    {
        if(RodUpgradeCost>TransactionManager.totalCoin)
        {
            rodUpgrButton.interactable = false;
        }
        else
        {
            rodUpgrButton.interactable = true;
        }
    }
    public void PriceIncrease()
    {
        if(RodLevel==1)
        {
            RodUpgradeCost=10;
        }
        else if (RodLevel==2)
        {
            RodUpgradeCost=20;
        }
        else if (RodLevel==3)
        {
            RodUpgradeCost=50;
        }
        else if (RodLevel==4)
        {
            RodUpgradeCost=100;
        }
        else if (RodLevel==5)
        {
            RodUpgradeCost=150;
        }
    }
    public void UpradeOne()
    {
        RodLevel++;
        TransactionManager.totalCoin=TransactionManager.totalCoin-RodUpgradeCost;
        Debug.Log("You have"+TransactionManager.totalCoin+"left");
        Debug.Log("Your rod level is 2");
    }
}
