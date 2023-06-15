using UnityEngine;
public abstract class BaseForActions : MonoBehaviour
{
    public int PowerMultiplyValue = 1;
    public abstract void SetPowerMultiplyValue(int value = 1);
    public abstract void Actions(bool ToEnemy = false);
}
