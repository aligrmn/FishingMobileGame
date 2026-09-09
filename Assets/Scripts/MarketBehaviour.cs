using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;


public class MarketBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject MarketPanel;
    [SerializeField] private TextMeshProUGUI marketCostTxt;
    [SerializeField] private Button marketActivationBtn;
    private Camera mainCam;
    bool isMarketActive;
    int marketCost = 50;
    int marketLevel=1;
    void Start()
    {
        mainCam= Camera.main;
        isMarketActive = false;
    }

    // Update is called once per frame
    void Update()
    {
         if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Ray ray = mainCam.ScreenPointToRay(mousePos);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                MarketPanel.SetActive(true);;
                }
            }
        }
        MarketIncome();
        ActivationPriceController();
        marketPriceTexter();

    }
    public void ClosePanel()
    {
        MarketPanel.SetActive(false);
    } 

    public void MarketActivation()
    {
        GameData.Instance.totalCoin -= marketCost;
        isMarketActive = true;
        marketCost+=20;
        marketLevel++;
    }

    void MarketIncome()
    {
        if(isMarketActive)
        {
        int multiplier = marketLevel switch
        {
        1 => 5,
        2 => 7,
        3 => 9,
        _ => 0
        };
        GameData.Instance.totalCoin += multiplier * GameData.Instance.fishingAmount;
        }

        
    }

    void ActivationPriceController()
    {
        if(GameData.Instance.totalCoin>=marketCost)
        {
            marketActivationBtn.interactable=true;
        }
        else
        {
            marketActivationBtn.interactable=false;
        }
    }

    void marketPriceTexter()
    {
        marketCostTxt.text=""+marketCost;
    }
}
