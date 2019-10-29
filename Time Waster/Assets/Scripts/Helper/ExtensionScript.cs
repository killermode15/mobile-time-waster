using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionScript
{
    public static bool Is(this TouchPhase currPhase, TouchPhase phase)
    {
        return currPhase == phase;
    }

    public static int SecondsToMinutes(this int seconds)
    {
        return seconds / 60;
    }
}