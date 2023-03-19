using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    public Rigidbody rb;
    void FixedUpdate()
    {
        // ローカルプレイヤーの時
        if (isLocalPlayer) {
            // 操作
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            if (Input.GetKeyDown(KeyCode.Q)) rb.velocity = Vector3.zero;
            CmdMoveSphere(x, z);
        }
    }
    
    // NetworkBehaviourの「Cmd」ではじまるメソッドに[Command]タグを付加することで、
    // クライアントから呼ばれた時、サーバー上で実行されるメソッドとして指定できる
    // https://note.com/npaka/n/na2c1e7e1d53b#:~:text=%E3%82%AF%E3%83%A9%E3%82%A4%E3%82%A2%E3%83%B3%E3%83%88%E3%81%8B%E3%81%A9%E3%81%86%E3%81%8B-,%E2%97%8E%C2%A0%E3%82%B3%E3%83%9E%E3%83%B3%E3%83%89,-NetworkBehaviour%E3%81%AE%E3%80%8C
    [Command]
    void CmdMoveSphere(float x, float z) 
    {
        Vector3 v = new Vector3(x, 0, z) * 5f;
        GetComponent<Rigidbody>().AddForce(v);
    }
}