using UnityEngine;

[CreateAssetMenu(fileName = "BuildingSetting", menuName = "ScriptableObjects/BuildingSetting", order = 1)]
public class BuildingSettings : ScriptableObject
{
    public RewardType type;
    public int rewardAmount;
    public float maxOffset;
    public string targetTag = "Player";

    [System.Serializable]
    public enum RewardType
    {
        Butchery,
        Bank
    }
}
