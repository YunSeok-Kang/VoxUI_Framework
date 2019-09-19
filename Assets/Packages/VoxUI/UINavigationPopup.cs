using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VoxUIObjectBlackBorad))]
public class UINavigationPopup : MonoBehaviour
{
    private VoxUIObjectBlackBorad _uiObjBB = null;

    Stack<GameObject> _uiNavigationStack = null;

    // ------------------------------------------------------------------------- Singleton ------------------------------------------------------------------------- //

    private static UINavigationPopup _instance;

    public static UINavigationPopup Instance
    {
        internal set
        {
            _instance = value;
        }

        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UINavigationPopup>();
                if (_instance == null)
                {
                    Debug.LogError("활성화된 UINavigationPopup 스크립트가 씬에 존재하지 않습니다.");
                }
            }

            return _instance;
        }
    }

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
