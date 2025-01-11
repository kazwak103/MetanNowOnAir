using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class KeyController : MonoBehaviour
{

    // 視聴者名ボタン
    [SerializeField]public UserButtonAction _TButton;   // 上ボタン
    [SerializeField]public UserButtonAction _LButton;   // 左ボタン
    [SerializeField]public UserButtonAction _RButton;   // 右ボタン
    [SerializeField]public UserButtonAction _BButton;   // 下ボタン
    [SerializeField]private UserList _uList;

    // チャット種類ボタン
    [SerializeField]public ChatCategoryButtonAction _SuperChatRedButton;    // 赤スパボタン
    [SerializeField]public ChatCategoryButtonAction _SuperChatButton;       // スパチャボタン
    [SerializeField]public ChatCategoryButtonAction _MemberShipButton;      // メンバー登録ボタン
    [SerializeField]public ChatCategoryButtonAction _MemberShipGiftButton;  // メンバーシップギフトボタン


    //private bool isClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        // ボタンキャプション　初期は空文字
        _TButton._gTmp.text = "";
        _LButton._gTmp.text = "";
        _RButton._gTmp.text = "";
        _BButton._gTmp.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        // ユーザー名ボタンが押された場合
        if (GameManager._currentPeriod.Equals(GameManager.Period.USER)) {
            int userId = -1;
            if (Input.GetKeyDown(KeyCode.A)){
                userId  = _LButton.Click();
            }else if (Input.GetKeyDown(KeyCode.D)){
                userId = _RButton.Click();
            }else if (Input.GetKeyDown(KeyCode.W)){
                userId = _TButton.Click();
            }else if (Input.GetKeyDown(KeyCode.S)){
                userId = _BButton.Click();
            }
        } else if (GameManager._currentPeriod.Equals(GameManager.Period.COMMENT)) {
            if (Input.GetKeyDown(KeyCode.I)){
                _SuperChatRedButton.Click();
            }else if (Input.GetKeyDown(KeyCode.J)){
                _SuperChatButton.Click();
            }else if (Input.GetKeyDown(KeyCode.K)){
                _MemberShipButton.Click();
            }else if (Input.GetKeyDown(KeyCode.L)){
                _MemberShipGiftButton.Click();
            }
        }
    }
}
