using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxUIObjectBlackBorad : MonoBehaviour
{
    [SerializeField]
    private List<VoxUIObjectInfo> uiObjects = new List<VoxUIObjectInfo>();

    /// <summary>
    /// key를 이용하여 uiObjects에 등록된 UI 오브젝트 검색
    /// </summary>
    /// <param name="key"></param>
    /// <returns> 
    ///     성공: 찾은 오브젝트의 uiObjects 리스트 기준 index 반환
    ///     실패: -1 반환
    /// </returns>
    public int FindtUIObjectIndex(string key)
    {
        int iterationIndex = 0;

        foreach (VoxUIObjectInfo objectInfo in uiObjects)
        {
            if (objectInfo.uiObjectKey.Equals(key))
            {
                return iterationIndex;
            }

            ++iterationIndex;
        }

        return -1;
    }

    /// <summary>
    /// index를 이용하여 uiObjects에 등록된 UIObjectInfo 객체 반환
    /// </summary>
    /// <param name="index"></param>
    /// <returns> 검색된 VoxUIObjectInfo </returns>
    public VoxUIObjectInfo GetUIObjectInfoByIndex(int index)
    {
        // uiObjects가 가지고 있는 오브젝트 갯수보다 더 큰 index가 들어오면 검색 중지
        if (index >= uiObjects.Count)
        {
            return null;
        }

        return uiObjects[index];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public VoxUIObjectInfo GetUIObjectInfoByKey(string key)
    {
        foreach (VoxUIObjectInfo objectInfo in uiObjects)
        {
            if (objectInfo.uiObjectKey.Equals(key))
            {
                return objectInfo;
            }
        }

        return null;
    }

    /// <summary>
    /// 리스트 내에 있는 VoxUIObjectInfo 데이터를 배열로 변환하여 반환 
    /// </summary>
    /// <returns></returns>
    public VoxUIObjectInfo[] GetUIObjectInfosToArray()
    {
        return uiObjects.ToArray();
    }
}
