using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerJoy : MonoBehaviour
{
    public static ManagerJoy instance;

    private void Awake()
    {
        instance = this;
    }

    public int TotalItems()
    {
        return transform.childCount;
    }
}
