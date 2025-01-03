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
    [SerializeField]private UserInfo _userInfo;
    [SerializeField]private AudioSource _source;

    // Start is called before the first frame update
    void Start()
    {
        this._source = GetComponent<AudioSource>();
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
        this.PlayVoice();
    }

    public void SetUserInfo(UserInfo userInfo)
    {
        this._userInfo = userInfo;
        this.setUserName(userInfo.userName);
    }

    public void PlayVoice(){
        Debug.Log(this._userInfo.audio.name);
        this._source.clip = this._userInfo.audio;
        this._source.Play();
    }

    public void setUserName(String userName)
    {
        this._gTmp.SetText(userName);
    }
}
