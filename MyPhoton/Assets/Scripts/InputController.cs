using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour {

    public InputField inputField;

    // 入力が完了したら呼ばれる(Enterや入力領域以外をクリック)
    public void OnEndEdit () {

		// 他プレイヤーのクライアントと同期するオブジェクトはこの関数を使って生成する
        GameObject obj = PhotonNetwork.Instantiate("Message", Vector3.zero, Quaternion.identity, 0);

        // 初期位置を適当に設定
        float x = 380f;
        float y = Random.Range(-150f, 150f);
        Vector3 pos = new Vector3(x, y, 0);
        obj.GetComponent<RectTransform>().localPosition = pos;

        // 入力されているテキストをセット(Messageスクリプトについては後述)
        obj.GetComponent<Message>().SetText(this.inputField.textComponent.text);
        // 入力内容を空に
        this.inputField.text = ""; 
		
        Debug.Log("入力完了");
    }
}