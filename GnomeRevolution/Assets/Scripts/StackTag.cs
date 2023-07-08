using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackTag : MonoBehaviour
{
    public StackType currentStackType;

    public enum StackType
    {
        _gnomeInput,
        _render
    }
}
