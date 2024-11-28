using UnityEngine;

[System.Serializable]
public class GenericAttribute<T> : BaseAttribute<T>
{
    public GenericAttribute(T value)
    {
        this.value = value;
    }

    public static implicit operator GenericAttribute<T>(T v)
    {
        return new GenericAttribute<T>(v);
    }
}