using System.Reflection;
using UnityEngine;

public enum AttributeModiferType
{
    Override, 
    Add, 
    Subtract, 
    Multiply, 
    Divide, 
    Percent,
    _Ignore
}

public class AttributeModifier<T>
{
    public T other;
    public AttributeModiferType modifierType;

    public AttributeModifier(T other, AttributeModiferType modifier_type)
    {
        switch (modifierType)
        {
            case AttributeModiferType.Add:
                if (typeof(T).GetMethod("op_Addition", BindingFlags.Static | BindingFlags.Public) == null)
                {
                    modifierType = AttributeModiferType._Ignore;
                    Debug.LogError("Cannot add type with no addition operator defined.");
                }
                break;
            case AttributeModiferType.Subtract:
                if (typeof(T).GetMethod("op_Subtraction", BindingFlags.Static | BindingFlags.Public) == null)
                {
                    modifierType = AttributeModiferType._Ignore;
                    Debug.LogError("Cannot subtract type with no subtraction operator defined.");
                }
                break;
            case AttributeModiferType.Multiply:
                if (typeof(T).GetMethod("op_Multiply", BindingFlags.Static | BindingFlags.Public) == null)
                {
                    modifierType = AttributeModiferType._Ignore;
                    Debug.LogError("Cannot multiply type with no multiplication operator defined.");
                }
                break;
            case AttributeModiferType.Divide:
                if (typeof(T).GetMethod("op_Division", BindingFlags.Static | BindingFlags.Public) == null)
                {
                    modifierType = AttributeModiferType._Ignore;
                    Debug.LogError("Cannot divide type with no division operator defined.");
                }
                break;
        }

        this.other = other;
        this.modifierType = modifier_type;
    }
}
