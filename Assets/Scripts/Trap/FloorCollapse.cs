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
    [SerializeField] private GameObject floorNormal;
    private Mesh originalMesh;
    private const string fractureName = "floorFracture";
    private GameObject[] fragmentList;
    private GameObject player;
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
        fragObg.tag = "Fragment";
        Debug.Log("form enableGravity name: " + other.gameObject.transform.parent.name);
        this.player = other.gameObject.transform.parent.gameObject;
        this.player.layer = 6;
        Invoke("resumePlayerLayer", 0.3f);
        Destroy(fragObg, Random.Range(1f, 2f));
    }
    public void handleFragment() {
        GameObject[] fragmentList = GameObject.FindGameObjectsWithTag("Fragment");
        Debug.Log("form handle frag num: " + fragmentList.Length);

        for (int i = 0; i < fragmentList.Length; i++) {
            fragmentList[i].tag = "Untagged";
            Destroy(fragmentList[i], Random.Range(1f, 2f));
        }
    }
    private void resumePlayerLayer() => player.layer = 3;
    public void respawnFloor() {
        for (int i = 0; i < floorGroup1.transform.childCount; i++)
            Destroy(floorGroup1.transform.GetChild(i).gameObject);
        for (int i = 0; i < floorGroup2.transform.childCount; i++)
            Destroy(floorGroup2.transform.GetChild(i).gameObject);
        for (int i = 0; i < floorGroupDark1.transform.childCount; i++)
            Destroy(floorGroupDark1.transform.GetChild(i).gameObject);
        for (int i = 0; i < floorGroupDark2.transform.childCount; i++)
            Destroy(floorGroupDark2.transform.GetChild(i).gameObject);
        for (int i = 0; i < 8; i++) {
            if (i % 2 == 0)
                Instantiate(floorNormal, new Vector3(20 - (int)(i / 2) * 5, 0, 0), floorGroup1.transform.rotation, floorGroup1.transform);
            else
                Instantiate(floorNormal, new Vector3(20 - (int)(i / 2) * 5, 0, -2.5f), floorGroup1.transform.rotation, floorGroup1.transform);
            if (i % 2 == 0)
                Instantiate(floorNormal, new Vector3(17.5f - (int)(i / 2) * 5, 0, 0), floorGroup2.transform.rotation, floorGroup2.transform);
            else
                Instantiate(floorNormal, new Vector3(17.5f - (int)(i / 2) * 5, 0, -2.5f), floorGroup2.transform.rotation, floorGroup2.transform);
            if (i % 2 == 0)
                Instantiate(floorNormal, new Vector3(20 - (int)(i / 2) * 5, 0, 0), floorGroupDark1.transform.rotation, floorGroupDark1.transform);
            else
                Instantiate(floorNormal, new Vector3(20 - (int)(i / 2) * 5, 0, -2.5f), floorGroupDark1.transform.rotation, floorGroupDark1.transform);
            if (i % 2 == 0)
                Instantiate(floorNormal, new Vector3(17.5f - (int)(i / 2) * 5, 0, 0), floorGroupDark2.transform.rotation, floorGroupDark2.transform);
            else
                Instantiate(floorNormal, new Vector3(17.5f - (int)(i / 2) * 5, 0, -2.5f), floorGroupDark2.transform.rotation, floorGroupDark2.transform);
        }
        Invoke("restart",0.05f);
    }
    void restart() {
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
}
