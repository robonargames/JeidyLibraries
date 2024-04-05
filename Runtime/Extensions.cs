
using UnityEngine;

public static class Extensions
{
    public static string Formatted(this int value)
    {
        return value.ToString("N0");
    }
    public static int Clamp(this int value, int min, int max)
    {
        if (value < min) return min;
        if (value > max) return max;
        return value;
    }

    public static int Max(this int value, int max = 0)
    {
        return value < 0 ? max : value;
    }

    public static float MaxKey(this AnimationCurve curve)
    {
        if (curve != null && curve.keys.Length > 0)
            return curve.keys[curve.length - 1].time;

        return 0f;
    }    
}

