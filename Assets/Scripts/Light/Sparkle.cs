using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparkle : MonoBehaviour {
	[SerializeField] private Light[] sparkleLight;
	[SerializeField] private Renderer[] lampMaterial;
	private List<bool> isComplete;

	// Start is called before the first frame update
	void Start() {
		this.isComplete = new List<bool>(sparkleLight.Length);
		for (int i = 0; i < sparkleLight.Length; i++)
			this.isComplete.Add(true);
	}

	// Update is called once per frame
	void Update() {
		for (int i = 0; i < this.isComplete.Count; i++)
			if (this.isComplete[i])
				StartCoroutine(this.lightSparkle(i));
	}
	IEnumerator lightSparkle(int target) {
		this.isComplete[target] = false;
		yield return new WaitForSeconds(Random.Range(4f, 6f));
		sparkleLight[target].enabled = false;
		lampMaterial[target].material.SetColor("_EmissiveColor", Color.white * 0);
		yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
		sparkleLight[target].enabled = true;
		lampMaterial[target].material.SetColor("_EmissiveColor", Color.white * 10);
		yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
		sparkleLight[target].enabled = false;
		lampMaterial[target].material.SetColor("_EmissiveColor", Color.white * 0);
		yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
		sparkleLight[target].enabled = true;
		lampMaterial[target].material.SetColor("_EmissiveColor", Color.white * 10);
		this.isComplete[target] = true;
	}
}
