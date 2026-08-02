using UnityEngine;
using UnityEngine.InputSystem;

public class ToolUpgrades : MonoBehaviour
{
    [SerializeField] private GameObject upgradePanel;
    public int rodUpgradeCost;
    public int reelUpgradeCost;
    private Camera mainCam;   
    void Start()
    {
        mainCam= Camera.main;
        rodUpgradeCost = 10;
        reelUpgradeCost = 10;
    }

    // Update is called once per frame
    void Update()
    {
        EnterUpgradePanel();
        RodPriceIncrease();
        ReelPriceIncrease();
        

    }
    public void EnterUpgradePanel()
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
                    Debug.Log("TIKLANDI");
                }
            }
        }
    }
    public void OpenMenu()
    {
        upgradePanel.SetActive(true);
    }
    
    public void RodPriceIncrease()
    {
        if(GameData.Instance.rodLevel==1)
        {
            rodUpgradeCost=10;
        }
        else if (GameData.Instance.rodLevel==2)
        {
            rodUpgradeCost=20;
        }
        else if (GameData.Instance.rodLevel==3)
        {
            rodUpgradeCost=50;
        }
        else if (GameData.Instance.rodLevel==4)
        {
            rodUpgradeCost=100;
        }
        else if (GameData.Instance.rodLevel==5)
        {
            rodUpgradeCost=150;
        }
    }

    public void ReelPriceIncrease()
    {
        if(GameData.Instance.reelSpeed==1)
        {
            reelUpgradeCost=10;
        }
        else if (GameData.Instance.reelSpeed==2)
        {
            reelUpgradeCost=30;
        }
        else if (GameData.Instance.reelSpeed==3)
        {
            reelUpgradeCost=60;
        }
        else if (GameData.Instance.reelSpeed==4)
        {
            reelUpgradeCost=120;
        }
        else if (GameData.Instance.reelSpeed==5)
        {
            reelUpgradeCost=240;
        }
    }

    
}
