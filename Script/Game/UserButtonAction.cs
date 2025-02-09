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

    // ボタンクリック
    // クリックされたボタンに設定されているユーザーIDを返す
    public int Click()
    {
        if (!GameManager._current._currentPeriod.Equals(GameManager.CurrentStatus.Period.USER)){
            return -1;
        }
        var userName = _gTmp.text;
        Debug.Log("UserButtonAction.Click: "+ userName + "　が押されました。");
        Debug.Log("UserButtonAction.Click: ターゲットユーザー　：　"+ GameManager._current._targetUser.UserName);
        GameManager.AddVoiceClip(_userInfo.Voice);

        GameManager._current._selectedUser = _userInfo.id;
        GameManager._current._currentPeriod = GameManager.CurrentStatus.Period.COMMENT;
        
        return _userInfo.id;
    }

    public void SetUserInfo(UserInfo userInfo)
    {
        _userInfo = userInfo;
        _gTmp.SetText(userInfo.UserName);
    }
}
