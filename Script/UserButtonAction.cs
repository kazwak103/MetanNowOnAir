using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class UserButtonAction : MonoBehaviour
{

    [SerializeField]public TextMeshProUGUI _gTmp;
    private UserInfo _userInfo;
    private AudioSource _source;

    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ボタンクリック
    public void click()
    {
        var userName = this._gTmp.text;
        Debug.Log(userName + "　が押されました。");
        PlayVoice();
    }

    public void SetUserInfo(UserInfo userInfo)
    {
        _userInfo = userInfo;
        setUserName(userInfo.userName);
    }

    public void PlayVoice(){
        Debug.Log(_userInfo.audio.name);
        _source.clip = _userInfo.audio;
        _source.Play();
    }

    public void setUserName(String userName)
    {
        _gTmp.SetText(userName);
    }
}
