using UnityEngine;
using UnityEngine.InputSystem;
public class FishingLuckBehaviour : MonoBehaviour
{
    [SerializeField] private ToolUpgrades ToolUpgrades; // assigned in Inspector
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // New Input System equivalent of GetMouseButtonDown(0)
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            int catchValue = Random.Range(1, 101);
            Debug.Log("You rolled: " + catchValue);
            if (ToolUpgrades.RodLevel==2)
            {
                catchValue+=10;
            }

            HandleFishingResult(catchValue);

            if(ToolUpgrades.RodLevel == 1)
            {
            Debug.Log("You have level 1 pole");
            }
        }
    }

    void HandleFishingResult(int value)
    {
        if (value >= 90)
            Debug.Log("Legendary catch!");
        else if (value >= 50)
            Debug.Log("Nice catch!");
        else
            Debug.Log("Just an old boot...");
    }
}
