using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ArcExtensions
{
    public static class ArcExtensions
    {
        public static int toRange(this int value, int min, int max)
        {
            if (value > max)
                return max;
            if (value < min)
                return min;
            return value;
        }
        public static float toRange(this float value, float min, float max)
        {
            if (value > max)
                return max;
            if (value < min)
                return min;
            return value;
        }
    }
}