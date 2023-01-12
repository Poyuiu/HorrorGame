using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSave : MonoBehaviour {
	public int nowSP { get; set; }
	Save.PlayerData playerData;
	void Awake() {
		// uncomment below if you want to clear save data
		// PlayerPrefs.DeleteAll();
		nowSP = 0;
        
	}
	public void changePos(int nowSP){
		switch(nowSP){
            case 1:
                this.transform.position = new Vector3(22f,1f,-2.5f);
                this.transform.rotation = Quaternion.Euler(new Vector3(0f,270f,0f));
                break;
        }
	}
	public void Save(int saveSp) {
		playerData = new Save.PlayerData();
		playerData.sp = saveSp;
        nowSP = saveSp;
		PlayerPrefs.SetString("PlayerData", JsonUtility.ToJson(playerData));
	}
	public void Load() {
		playerData = JsonUtility.FromJson<Save.PlayerData>(PlayerPrefs.GetString("PlayerData"));
        if (playerData != null)
			nowSP = playerData.sp;
	}
}
