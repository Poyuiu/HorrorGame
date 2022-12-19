using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollapse : MonoBehaviour {

    [SerializeField] private GameObject floorGroup1;
    [SerializeField] private GameObject floorGroup2;
    [SerializeField] private GameObject floorGroupDark1;
    [SerializeField] private GameObject floorGroupDark2;
    [SerializeField] private GameObject floorFracturePrefab;
    [SerializeField] private GameObject floorAudioPrefab;
    private Mesh originalMesh;
    private const string fractureName = "floorFracture";
    void Start() {
        List<GameObject> targetGroup = new List<GameObject>();
        List<GameObject> targetGroupDark = new List<GameObject>();
        originalMesh = floorFracturePrefab.GetComponent<MeshFilter>().sharedMesh;
        GameObject partFractureGroup;
        GameObject allFractureGroup;
        GameObject partFractureDarkGroup;
        GameObject allFractureDarkGroup;
        if (Random.value > 0.5f) {
            partFractureGroup = floorGroup1;
            partFractureDarkGroup = floorGroupDark1;
            allFractureGroup = floorGroup2;
            allFractureDarkGroup = floorGroupDark2;
        } else {
            partFractureGroup = floorGroup2;
            partFractureDarkGroup = floorGroupDark2;
            allFractureGroup = floorGroup1;
            allFractureDarkGroup = floorGroupDark1;
        }
        for (int i = 0; i < partFractureGroup.transform.childCount; i++) {
            targetGroup.Add(partFractureGroup.transform.GetChild(i).gameObject);
            targetGroupDark.Add(partFractureDarkGroup.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < 7; i += 2) {
            GameObject newFloor;

            if (Random.value > 0.5f) {
                newFloor = Instantiate(floorFracturePrefab, targetGroup[i].transform.position, targetGroup[i].transform.rotation, targetGroup[i].transform.parent.transform);
                Instantiate(floorAudioPrefab, targetGroup[i].transform.position - new Vector3(1.25f, 0f, 1.25f), targetGroup[i].transform.rotation, targetGroup[i].transform.parent.transform);
                Destroy(targetGroup[i]);
                Destroy(targetGroupDark[i]);
            } else {
                newFloor = Instantiate(floorFracturePrefab, targetGroup[i + 1].transform.position, targetGroup[i + 1].transform.rotation, targetGroup[i + 1].transform.parent
                .transform);
                Instantiate(floorAudioPrefab, targetGroup[i + 1].transform.position - new Vector3(1.25f, 0f, 1.25f), targetGroup[i + 1].transform.rotation, targetGroup[i + 1].transform.parent.transform);
                Destroy(targetGroup[i + 1]);
                Destroy(targetGroupDark[i + 1]);
            }
            newFloorInit(newFloor);
        }
        targetGroup = new List<GameObject>();
        targetGroupDark = new List<GameObject>();
        for (int i = 0; i < allFractureGroup.transform.childCount; i++) {
            targetGroup.Add(allFractureGroup.transform.GetChild(i).gameObject);
            targetGroupDark.Add(allFractureDarkGroup.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < 8; i++) {
            GameObject newFloor = Instantiate(floorFracturePrefab, targetGroup[i].transform.position, targetGroup[i].transform.rotation, targetGroup[i].transform.parent.transform);
            Instantiate(floorAudioPrefab, targetGroup[i].transform.position - new Vector3(1.25f, 0f, 1.25f), targetGroup[i].transform.rotation, targetGroup[i].transform.parent.transform);
            Destroy(targetGroup[i]);
            Destroy(targetGroupDark[i]);
            newFloorInit(newFloor);
        }
    }
    private void newFloorInit(GameObject newFloor) {
        newFloor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        newFloor.transform.position = newFloor.transform.position - new Vector3(1.25f, 0f, 1.25f);
        newFloor.name = fractureName;
        newFloor.layer = 6; 
        Mesh clonedMesh = new Mesh();
        clonedMesh.vertices = originalMesh.vertices;
        clonedMesh.triangles = originalMesh.triangles;
        clonedMesh.normals = originalMesh.normals;
        clonedMesh.uv = originalMesh.uv;
        newFloor.GetComponent<MeshFilter>().mesh = clonedMesh;
    }
    public void enableGravity(Collider other, GameObject fragObg, Vector3 fragVec) {

        fragObg.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        fragObg.GetComponent<Rigidbody>().useGravity = true;
        fragObg.layer = 6;
        Destroy(fragObg.gameObject, 3f);
    }
    public void destoryFracture() {
        GameObject target = GameObject.Find(fractureName + "Fragments");
        if (target != null)
            Destroy(target, Random.Range(1f, 2f));
    }
}
