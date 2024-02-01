using UnityEngine;

public class BoxColliderDetector : MonoBehaviour
{
    public GameObject outerBox; // Public variable to assign the outer box
	public Material newMaterial; // Drag the new material here in the inspector
    public Material invisible;
	public Material oldMaterialProblem;
	public Material oldMaterialStudent;
	
	private bool materialChanged = false;
    void Update()
    {
        if (outerBox != null)
        {
            DetectBoxColliderInside();
        }
    }

    void DetectBoxColliderInside()
    {
        Vector3 center = outerBox.transform.position;
        Vector3 size = outerBox.transform.localScale;

        Collider[] hitColliders = Physics.OverlapBox(center, size / 2);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject != outerBox && hitCollider is BoxCollider)
            {
                
			//Debug.Log("Box Collider detected inside the outer box: " + hitCollider.gameObject.name);
            if (IsPositionApproximatelyEqual(outerBox.transform.position,hitCollider.transform.position))
            {
                //Debug.Log("The inner box is at the same position as the outer box.");
				ChangeMaterial(outerBox, newMaterial);
				ChangeMaterial(hitCollider.gameObject, invisible);
                materialChanged = true;
            }
            else
            {
				if(materialChanged){}
                //Debug.Log("The inner box is not at the same position as the outer box.");
				//ChangeMaterial(outerBox, oldMaterialProblem);
				//ChangeMaterial(hitCollider.gameObject, oldMaterialStudent);
            }
			}
        }
    }
	
	
	 bool IsPositionApproximatelyEqual(Vector3 pos1, Vector3 pos2, float tolerance = 0.4f)
    {
        return Vector3.Distance(pos1, pos2) < tolerance;
    }
	
	 void ChangeMaterial(GameObject obj, Material newMat)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = newMat;
        }
    }
}
