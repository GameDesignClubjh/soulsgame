using Mono.Cecil;
using System;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;


public abstract class BaseAttribute<T>
{
    public T value;
    private T cached;
    private bool resetCache = true;
    protected Dictionary<string, AttributeModifier<T>> modifiers = new();
    protected T overrideValue;
    protected string overrideName = null;

    protected T Modify(T value)
    {
        if (modifiers.Count > 0)
            Debug.LogWarning("Failure to modify generic attribute");

        return value;
    }

    /// <summary>
    /// Adds a modifier with an attributed name.
    /// </summary>
    /// <param name="name">The name of the modifier, only one modifier can be under each name.</param>
    /// <param name="modiferType">The type of modifier. Non-number types only implement override.</param>
    /// <param name="other">The the value of the modifier.</param>
    public void SetModifier(string name, AttributeModiferType modiferType, T other)
    {
        if (modiferType == AttributeModiferType.Override)
        {
            modifiers.Remove(name);
            overrideName = name;
            overrideValue = other;
            resetCache = true;
            return;
        } else if (modiferType == AttributeModiferType._Ignore)
        {
            return;
        }
        modifiers[name] = new AttributeModifier<T>(other, modiferType);
        resetCache = true;
    }

    /// <summary>
    /// Removes a modifier with the attributed name.
    /// </summary>
    /// <param name="name"></param>
    public void RemoveModifer(string name) {
        if (overrideName == name)
        {
            overrideName = null;
        }
        else
        {
            modifiers.Remove(name);
            resetCache = true;
        }
    }
    
    /// <summary>
    /// Grab the value of the attribute after modifiers.
    /// </summary>
    /// <returns></returns>
    public T Get() {
        if (resetCache)
        {
            resetCache = false;
            cached = Modify(overrideName == null ? value : overrideValue);
        }

        return cached;
    }
}
