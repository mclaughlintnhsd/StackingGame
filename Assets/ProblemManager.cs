using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemManager : MonoBehaviour
{
	public GameObject[] innerBlocks; // Assign this array in the Unity inspector

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   void Update()
{
    if (DoAllBlocksHaveSameMaterial())
    {
        Debug.Log("All blocks have the same material.");
    }
    else
    {
        Debug.Log("Not all blocks have the same material.");
    }
}

	bool DoAllBlocksHaveSameMaterial()
{
    if (innerBlocks.Length == 0) return true; // No blocks to compare.

    Renderer firstBlockRenderer = innerBlocks[0].GetComponent<Renderer>();
    if (firstBlockRenderer == null) return false; // First block doesn't have a Renderer.

    Material firstMaterial = firstBlockRenderer.material;

    for (int i = 1; i < innerBlocks.Length; i++)
    {
        Renderer renderer = innerBlocks[i].GetComponent<Renderer>();
        if (renderer == null || renderer.material != firstMaterial)
        {
            return false; // Found a block with a different material.
        }
    }

    return true; // All blocks have the same material.
}

}
