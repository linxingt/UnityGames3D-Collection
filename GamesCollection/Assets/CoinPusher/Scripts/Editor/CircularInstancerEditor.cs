using UnityEngine;
using UnityEditor;

public class CircularInstancerEditor
{
    [MenuItem("Tools/Circular Duplicate in YZ Plane (use 'center' object)")]
    public static void DuplicateInCircleYZ()
    {
        GameObject original = Selection.activeGameObject;
        GameObject centerObject = GameObject.Find("center");

        Vector3 center = centerObject.transform.position;
        float radius = 1.5f;
        int numberOfCopies = 12;

        for (int i = 0; i < numberOfCopies; i++)
        {
            float angle = i * Mathf.PI * 2f / numberOfCopies;

            float y = center.y + Mathf.Cos(angle) * radius;
            float z = center.z + Mathf.Sin(angle) * radius;
            float x = center.x;

            Vector3 position = new Vector3(x, y, z);

            GameObject copy = Object.Instantiate(original, position, Quaternion.identity);
            copy.name = original.name + "_copy_" + i;

            Vector3 angles = copy.transform.eulerAngles;
            angles.x = 360 / numberOfCopies * i;
            copy.transform.eulerAngles = angles;

            copy.transform.SetParent(centerObject.transform);
        }
    }
}