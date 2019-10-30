using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScriptableInt : MonoBehaviour
{
    public int Value => value;

    [SerializeField] private int value = 0;
}