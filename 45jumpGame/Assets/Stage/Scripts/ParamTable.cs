using UnityEngine;

[CreateAssetMenu(menuName = "45/ParamTable")]
public class ParamTable : ScriptableObject
{
    public int module = 0;
    public int fuel = 0;
    public int life = 3;
    public int rtg = 1;
    public int luck = 0;
    public int additionalEngine = 0;
}
