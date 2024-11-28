using Unity.VisualScripting;
using UnityEngine;


[System.Serializable]
public class FloatAttribute : BaseAttribute<float>
{
    public FloatAttribute(float value)
    {
        this.value = value;
    }

    public static implicit operator FloatAttribute(float v)
    {
        return new FloatAttribute(v);
    }

    protected new float Modify(float value)
    {
        float sum = 0f;
        float factor = 1f;
        float percentile = 1f;

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

        return value * factor * percentile + sum;
    }

    public new float Get()
    {
        return Modify(overrideName == null ? value : overrideValue);
    }
}