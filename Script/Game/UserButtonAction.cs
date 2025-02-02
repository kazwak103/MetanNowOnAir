using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class UserButtonAction : MonoBehaviour
{

    [SerializeField]public TextMeshProUGUI _gTmp;
    private UserInfo _userInfo;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ボタンクリック
    // クリックされたボタンに設定されているユーザーIDを返す
    public int Click()
    {
        if (!GameManager._currentPeriod.Equals(GameManager.Period.USER)){
            return -1;
        }
        var userName = _gTmp.text;
        Debug.Log("UserButtonAction.Click: "+ userName + "　が押されました。");
        Debug.Log("UserButtonAction.Click: ターゲットユーザー　：　"+ GameManager._targetUser.UserName);
        // PlayVoice();
        GameManager.AddVoiceClip(_userInfo.Voice);

        if (_userInfo.id == GameManager._targetUser.id){
            GameManager.AddScore();
        }
        else {
            GameManager.LostScore();
        }
        GameManager._currentPeriod = GameManager.Period.COMMENT;
        return _userInfo.id;
    }

    public void SetUserInfo(UserInfo userInfo)
    {
        _userInfo = userInfo;
        setUserName(userInfo.UserName);
    }
    public void setUserName(String userName)
    {
        _gTmp.SetText(userName);
    }
}
