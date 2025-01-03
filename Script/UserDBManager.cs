using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UseDBManager : MonoBehaviour
{
    [SerializeField]private UserList _userList;
    public void AddUserInfo(UserInfo userInfo)
    {
        this._userList.userList.Add(userInfo);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
