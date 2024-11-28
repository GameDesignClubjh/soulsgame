using UnityEngine;

[System.Serializable]
public class StringAttribute : BaseAttribute<string>
{
    public StringAttribute(string value)
    {
        this.value = value;
    }

    public static implicit operator StringAttribute(string v)
    {
        return new StringAttribute(v);
    }
}
