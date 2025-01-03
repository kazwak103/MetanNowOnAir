using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[SerializeField]
public class CommentCategoryList : ScriptableObject
{
    public List<CommnetCategoryValue> commnetCategories;

    public CommnetCategoryValue GetCommnetCategoryValue(CommnetCategory category){
        foreach (CommnetCategoryValue commnetCategoryValue in commnetCategories){
            if (commnetCategoryValue.Category.Equals(category)){
                return commnetCategoryValue;
            }
        }
        return GetCommnetCategoryValue(CommnetCategory.NORMAL);
    }
}
