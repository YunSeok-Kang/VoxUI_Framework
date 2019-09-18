using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VoxUIObjectBlackBorad))]
public class UIPopupControl : MonoBehaviour
{
    private VoxUIObjectBlackBorad _uiObjBB = null;

    /// <summary>
    /// 현재 선택된 오브젝트의 uiObjects 리스트 기준의 인덱스
    /// </summary>
    public int SelectedIndex
    {
        internal set; get;
    }

    /// <summary>
    /// 현재 선택된 오브젝트의 uiObjects 리스트 기준의 오브젝트 참조 값
    /// </summary>
    public VoxUIObjectInfo SelectedUIObj
    {
        internal set; get;
    }

    // ----------------------------------------------------------------------- Unity Evenets ----------------------------------------------------------------------- //

    private void Awake()
    {
        if (_uiObjBB == null)
        {
            _uiObjBB = GetComponent<VoxUIObjectBlackBorad>();
        }
    }

    // -------------------------------------------------------------------------- Methods -------------------------------------------------------------------------- //

    public void SelectPopupUI(string key)
    {
        VoxUIObjectInfo[] objectInfos = _uiObjBB.GetUIObjectInfosToArray();

        foreach (VoxUIObjectInfo currentUIObject in objectInfos)
        {
            if (currentUIObject.uiObjectKey.Equals(key))
            {
                currentUIObject.uiObject.SetActive(true);
                SelectedUIObj = currentUIObject;
            }
            else
            {
                currentUIObject.uiObject.SetActive(false);
            }
        }
    }

    public void ClearPopup()
    {
        SelectedUIObj.uiObject.SetActive(false);
        SelectedUIObj = null;
    }
}