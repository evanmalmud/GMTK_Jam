using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "MultiplierEntry")]
public class MultiplierEntry : ScriptableObject
{
    [SerializeField]
    public int multiVal;
    [SerializeField]
    public string multiString;
    [SerializeField]
    public int enemiesRequired;
    [SerializeField]
    public float timeRequired;
    [SerializeField]
    public int bumperMinus;
}