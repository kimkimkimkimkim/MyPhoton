using UnityEngine.UI;
using UnityEngine;

public class Message : Photon.MonoBehaviour {

    PhotonView pView;
    float moveSpeed = -60;    // 1秒間に動く距離

    void Update() {
        // 他プレイヤーのクライアントが生成したオブジェクトの場合は実行しない
        if (this.pView.isMine == false) {
            return;
        }

        // 指定した座標地点まで移動
        if (this.gameObject.transform.localPosition.x >= -500) {
            this.transform.Translate(this.moveSpeed * Time.deltaTime, 0, 0);
        } else {
            // 他プレイヤーにオブジェクトを破棄したことを同期
            this.pView.RPC("RpcDestroy", PhotonTargets.All);
        }
    }

    // PhotonNetwork.Instantiateでインスタンスを生成した時に呼ばれる
    void OnPhotonInstantiate(PhotonMessageInfo info) {
        this.pView = PhotonView.Get(this);
        // Messageオブジェクトの親(Canvas）設定を同期
        this.pView.RPC("RpcSetParentCanvas", PhotonTargets.All);
    }

    // テキストをセット(InputController.csから呼び出される)
    public void SetText(string setText) {
        this.pView.RPC("RpcSetText", PhotonTargets.All, setText);
    }

    // 破棄を同期
    [PunRPC]
    void RpcDestroy() {
        Destroy(this.gameObject);
    }

    // 親設定を同期
    [PunRPC]
    void RpcSetParentCanvas() {
        // タグからオブジェクトを取得
        Transform t = GameObject.FindWithTag("Canvas").transform;
        this.transform.SetParent(t);
    }

    // メッセージ内容を同期
    [PunRPC]
    void RpcSetText(string setText) {
        this.GetComponent<Text>().text = setText;
    }
}