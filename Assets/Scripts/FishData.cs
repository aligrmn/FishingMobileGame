using UnityEngine;

[CreateAssetMenu(fileName = "NewFish", menuName = "Fishing/Fish")]
public class FishData : ScriptableObject
{
    public string fishName;
    public int fishLevel;
    public GameObject model3D;
}
