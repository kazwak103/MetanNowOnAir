using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[SerializeField]
public class ChatCategoryList : ScriptableObject
{
    public List<ChatCategoryInfo> ChatCategoryInfos;

    public ChatCategoryInfo GetChatCategoryInfo(ChatCategory category){
        foreach (ChatCategoryInfo chatCategoryValue in ChatCategoryInfos){
            if (chatCategoryValue.Category.Equals(category)){
                return chatCategoryValue;
            }
        }
        return GetChatCategoryInfo(ChatCategory.NORMAL);
    }
}
