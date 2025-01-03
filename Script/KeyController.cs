using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyController : MonoBehaviour
{

    [SerializeField]public UserButtonAction _TButton;
    [SerializeField]public UserButtonAction _LButton;
    [SerializeField]public UserButtonAction _RButton;
    [SerializeField]public UserButtonAction _BButton;
    [SerializeField]private UserList _uList;

    private bool isClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        this.SetUserButtonCaption();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)){
            this._LButton.click();
            this.isClicked = true;
        }else if (Input.GetKeyDown(KeyCode.D)){
            this._RButton.click();
            this.isClicked = true;
        }else if (Input.GetKeyDown(KeyCode.W)){
            this._TButton.click();
            this.isClicked = true;
        }else if (Input.GetKeyDown(KeyCode.S)){
            this._BButton.click();
            this.isClicked = true;
        }
        // クリックされた場合はユーザーボタンのキャプションを更新
        if (this.isClicked){
            this.SetUserButtonCaption();
        }
    }

    private void SetUserButtonCaption(){
        UserButtonAction[] ubList = {this._TButton, this._LButton, this._RButton, this._BButton};
        foreach(UserButtonAction act in ubList){
            act.SetUserInfo(this._uList.userList[Random.Range(0,_uList.userList.Count)]);
        }
        this.isClicked = false;
    }
    

}
