using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour {

    public InputField inputField;

    // 入力が完了したら呼ばれる(Enterや入力領域以外をクリック)
    public void OnEndEdit () {
        Debug.Log("入力完了");
    }
}