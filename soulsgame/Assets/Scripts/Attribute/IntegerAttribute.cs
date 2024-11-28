using UnityEngine;

[System.Serializable]
public class IntegerAttribute : BaseAttribute<int>
{
    public IntegerAttribute(int value)
    {
        this.value = value;
    }

    public static implicit operator IntegerAttribute(int v)
    {
        return new IntegerAttribute(v);
    }

    protected new int Modify(int value)
    {
        int sum = 0;
        float factor = 1;
        float percentile = 1;

        foreach (var item in modifiers)
        {
            switch (item.Value.modifierType)
            {
                case AttributeModiferType.Add:
                    sum += item.Value.other;
                    break;
                case AttributeModiferType.Subtract:
                    sum -= item.Value.other;
                    break;
                case AttributeModiferType.Multiply:
                    sum *= item.Value.other;
                    break;
                case AttributeModiferType.Divide:
                    sum /= item.Value.other;
                    break;
                case AttributeModiferType.Percent:
                    percentile *= item.Value.other / 100f;
                    break;
            }
        }

        return (int)(value * factor * percentile) + sum;
    }
}