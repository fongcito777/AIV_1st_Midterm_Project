using UnityEngine;

public static class Utility
{
    public static GameObject[] GetObjectsWithTag(string tag)
    {
        return GameObject.FindGameObjectsWithTag(tag);
    }
}