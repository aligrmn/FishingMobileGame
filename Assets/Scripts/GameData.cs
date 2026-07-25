using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    public int totalCoin = 20;
    public int rodLevel = 1;
    public int reelSpeed = 1;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}