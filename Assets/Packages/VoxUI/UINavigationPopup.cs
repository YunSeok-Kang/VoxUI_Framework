using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VoxUIObjectBlackBorad))]
public class UINavigationPopup : MonoBehaviour
{
    private VoxUIObjectBlackBorad _uiObjBB = null;

    Stack<GameObject> _uiNavigationStack = null;

    // ----------------------------------------------------------------------- Unity Evenets ----------------------------------------------------------------------- //

    private void Awake()
    {
        _uiNavigationStack = new Stack<GameObject>();

        if (_uiObjBB == null)
        {
            _uiObjBB = GetComponent<VoxUIObjectBlackBorad>();
        }
    }

    // -------------------------------------------------------------------------- Methods -------------------------------------------------------------------------- //

    public void PushUI(string key)
    {
        VoxUIObjectInfo selectedUIObjInfo = _uiObjBB.GetUIObjectInfoByKey(key);
        GameObject selectedUIObject = selectedUIObjInfo.uiObject;

        _uiNavigationStack.Push(selectedUIObjInfo.uiObject);
        selectedUIObject.SetActive(true);
    }

    public void PopUI()
    {
        GameObject poppingUIObj = _uiNavigationStack.Pop();
        poppingUIObj.SetActive(false);
    }
}
