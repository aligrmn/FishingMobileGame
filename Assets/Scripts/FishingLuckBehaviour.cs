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
                catchValue+=5;
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
        if (value >= 95)
            Debug.Log("Legendary catch!");
        else if (value >= 80)
            Debug.Log("Epic");
        else if (value >= 50)
            Debug.Log("Random Cod");
        else if (value >= 20)
            Debug.Log("Nice catch!");
        else
            Debug.Log("Just an old boot...");
    }
}
