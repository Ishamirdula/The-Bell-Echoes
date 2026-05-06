using UnityEngine;

[ExecuteInEditMode]   // <-- THIS is the magic line
public class AddCollidersUnderGenerator : MonoBehaviour
{
    [Header("Root parent name")]
    public string rootObjectName = "generator";

    void Start()
    {
        GameObject root = GameObject.Find(rootObjectName);

        if (root == null)
        {
            Debug.LogError("Parent object named '" + rootObjectName + "' not found!");
            return;
        }

        AddMeshColliderRecursive(root.transform);
        Debug.Log("Colliders added to all children under: " + rootObjectName);
    }

    void AddMeshColliderRecursive(Transform obj)
    {
        if (!obj.GetComponent<Collider>())
        {
            MeshFilter mf = obj.GetComponent<MeshFilter>();
            if (mf != null && mf.sharedMesh != null)
            {
                MeshCollider mc = obj.gameObject.AddComponent<MeshCollider>();
                mc.convex = false;
            }
        }

        foreach (Transform child in obj)
        {
            AddMeshColliderRecursive(child);
        }
    }
}
