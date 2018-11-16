using UnityEngine;


public class Network : MonoBehaviour {
 
    void Start() {
        // Photonサーバーに接続する(引数でゲームのバージョンを指定できる)
        // 前準備で設定ファイルのAuto-Join Lobbyをtrueにしていると、ここでそのままロビーに接続
        PhotonNetwork.ConnectUsingSettings(null);
    }
 
    // ロビーに接続すると呼ばれる
    void OnJoinedLobby() {
        Debug.Log("ロビーに入りました。");
 
        // ルームに入室する
        PhotonNetwork.JoinRandomRoom();
    }
 
    // ルームに入室すると呼ばれる
    void OnJoinedRoom() {
        Debug.Log("ルームへ入室しました。");
    }
 
    // ルームの入室に失敗すると呼ばれる
    void OnPhotonRandomJoinFailed() {
        Debug.Log("ルームの入室に失敗しました。");
 
        // ルームがないと入室に失敗するため、ルームがない場合は自分で作る
        PhotonNetwork.CreateRoom("myRoomName");
    }
}
