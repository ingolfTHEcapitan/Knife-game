using System;
using UnityEngine;

namespace Project.Scripts
{
    [Serializable]
    public struct SpawnObject
    {
        [field: SerializeField] public Shield Prefab;
        [field: SerializeField]  public float MinDelay;
        [field: SerializeField]  public float MaxDelay;
    }
}