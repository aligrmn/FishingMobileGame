using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class FishingLuckBehaviour : MonoBehaviour
{
    [SerializeField] private ToolUpgrades ToolUpgrades;
    [SerializeField] private Animator animator;
    [SerializeField] private string castAnimName = "CastLine";
    [SerializeField] private float extraPause = 1f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            animator.Play(castAnimName);
            StartCoroutine(FishingSequence());
        }
    }

    IEnumerator FishingSequence()
    {
        yield return null; // let Animator register the new state

        float animLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animLength); // wait for cast animation to finish

        yield return new WaitForSeconds(extraPause); // extra pause after animation

        RollForFish();
    }
    void RollForFish()
    {
        int catchValue = Random.Range(1, 101);
        Debug.Log("You rolled: " + catchValue);

        if (ToolUpgrades.RodLevel==2)
        {
            catchValue+=5;
        }

        HandleFishingResult(catchValue);
    
        
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
