using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu]
[SerializeField]
public class UserList : ScriptableObject
{
    public List<UserInfo> userList = new List<UserInfo>();
}
