using UnityEngine;

public static class Utility
{
    public static GameObject[] GetObjectsWithTag(string tag)
    {
        return GameObject.FindGameObjectsWithTag(tag);
    }

    public static GameObject IsCharacterNear(int distance, string tag, Transform transform)
    {
        foreach (GameObject thief in Utility.GetObjectsWithTag(tag)) {
            if (Vector3.Distance(thief.transform.position, transform.position) < distance) {
                return thief;
            }
        }
        return null;
    }
}