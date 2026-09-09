using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    [SerializeField] private int _totalCoin;
    [SerializeField] private int _rodLevel;
    [SerializeField] private int _reelSpeed;
    [SerializeField] private int _fishingAmount;

    public int totalCoin
    {
        get => _totalCoin;
        set { _totalCoin = value; Save(); }
    }

    public int rodLevel
    {
        get => _rodLevel;
        set { _rodLevel = value; Save(); }
    }

    public int reelSpeed
    {
        get => _reelSpeed;
        set { _reelSpeed = value; Save(); }
    }

    public int fishingAmount
    {
        get => _fishingAmount;
        set { _fishingAmount = value; Save(); }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Load();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        PlayerPrefs.SetInt("TotalCoin", _totalCoin);
        PlayerPrefs.SetInt("RodLevel", _rodLevel);
        PlayerPrefs.SetInt("ReelSpeed", _reelSpeed);
        PlayerPrefs.SetInt("FishingAmount", _fishingAmount);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        _totalCoin = PlayerPrefs.GetInt("TotalCoin", 20);
        _rodLevel = PlayerPrefs.GetInt("RodLevel", 1);
        _reelSpeed = PlayerPrefs.GetInt("ReelSpeed", 1);
        _fishingAmount = PlayerPrefs.GetInt("FishingAmount", 0);
    }

    void OnApplicationPause(bool pause)
    {
        if (pause) Save();
    }

    void OnApplicationQuit()
    {
        Save();
    }
}