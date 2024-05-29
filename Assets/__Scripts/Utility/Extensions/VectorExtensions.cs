using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtensions
{
    public static Vector3 With(this Vector3 v1, float? x = null, float? y = null, float? z = null)
    {
        return new Vector3(x ?? v1.x, y ?? v1.y, z ?? v1.z);
    }
    public static Vector3 Add(this Vector3 v1, float? x = null, float? y = null, float? z = null)
    {
        return new Vector3(v1.x + (x ?? 0), v1.y + (y ?? 0), v1.z + (z ?? 0));
    }
}
