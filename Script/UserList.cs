using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[SerializeField]
public class UserList : ScriptableObject
{
    public List<UserInfo> userList = new List<UserInfo>();
}
