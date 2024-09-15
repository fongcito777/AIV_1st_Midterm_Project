using UnityEngine;

public static class Utility
{
    public static GameObject[] GetObjectsWithTag(string tag)
    {
        return GameObject.FindGameObjectsWithTag(tag);
    }

    public static GameObject IsCharacterNear(int distance, string tag, Transform transform)
    {
        foreach (GameObject character in Utility.GetObjectsWithTag(tag)) {
            if (Vector3.Distance(character.transform.position, transform.position) < distance) {
                return character;
            }
        }
        return null;
    }

    public static GameObject ClosestCharacter(string tag, Transform transform)
    {
        GameObject closestCharacter = null;
        float closestDistance = Mathf.Infinity;
        foreach (GameObject character in Utility.GetObjectsWithTag(tag)) {
            float distanceToCharacter = Vector3.Distance(character.transform.position, transform.position);
            if (distanceToCharacter < closestDistance) {
                closestCharacter = character;
                closestDistance = distanceToCharacter;
            }
        }
        return closestCharacter;
    }
}