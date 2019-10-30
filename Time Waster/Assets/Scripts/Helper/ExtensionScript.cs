using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionScript
{
    public static bool Is(this TouchPhase currPhase, TouchPhase phase)
    {
        return currPhase == phase;
    }

    public static int ToSeconds(this int seconds)
    {
        return seconds % 60;
    }

    public static int ToMinutes(this int seconds)
    {
        return (seconds / 60) % 60;
    }

    public static int ToHours(this int seconds)
    {
        return ((seconds / 60) / 60) % 24;
    }

    public static int ToDays(this int seconds)
    {
        return (((seconds / 60) / 60) / 24) % 365;
    }

    public static int ToYears(this int seconds)
    {
        return (((seconds / 60) / 60) / 24 / 365) % 100;
    }
}