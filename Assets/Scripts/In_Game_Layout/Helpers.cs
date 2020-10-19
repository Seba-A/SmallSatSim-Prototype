using UnityEngine;

static class Helpers
{
    //this will return the same vector without the Y component
    public static Vector3 XZ(this Vector3 input)
    {
        return new Vector3(input.x, 0, input.z);
    }
}
