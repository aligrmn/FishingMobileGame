using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Linq;

public class FishingLuckBehaviour : MonoBehaviour
{
    [SerializeField] private ToolUpgrades ToolUpgrades;
    [SerializeField] private Animator animator;
    [SerializeField] private string castAnimName = "CastLine";
    [SerializeField] private float extraPause = 5f;
    [SerializeField] private FishData[] allFish; // assign all fish assets in Inspector

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
        yield return null;

        float animLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animLength);

        yield return new WaitForSeconds(extraPause);

        RollForFish();
    }

    void RollForFish()
    {
        FishData caughtFish = GetHookedFish();

        if (caughtFish == null)
        {
            Debug.LogWarning("No fish available at this rod level.");
            return;
        }

        Debug.Log($"Hooked: {caughtFish.fishName} (Lv.{caughtFish.fishLevel})");
        // SpawnFish(caughtFish); // hook up your spawn/inventory/UI logic here
    }

    FishData GetHookedFish()
    {
        int rodLevel = GameData.Instance.rodLevel;

        var eligibleFish = allFish.Where(f => f.fishLevel <= rodLevel).ToArray();

        if (eligibleFish.Length == 0)
            return null;

        float[] weights = new float[eligibleFish.Length];
        float totalWeight = 0f;

        for (int i = 0; i < eligibleFish.Length; i++)
        {
            int levelGap = rodLevel - eligibleFish[i].fishLevel;
            float weight = GetProbabilityWeight(levelGap);
            weights[i] = weight;
            totalWeight += weight;
        }

        float roll = Random.Range(0f, totalWeight);
        float cumulative = 0f;

        for (int i = 0; i < eligibleFish.Length; i++)
        {
            cumulative += weights[i];
            if (roll <= cumulative)
                return eligibleFish[i];
        }

        return eligibleFish[eligibleFish.Length - 1];
    }

    float GetProbabilityWeight(int levelGap)
    {
        return 1f / (levelGap + 1f);
    }
}