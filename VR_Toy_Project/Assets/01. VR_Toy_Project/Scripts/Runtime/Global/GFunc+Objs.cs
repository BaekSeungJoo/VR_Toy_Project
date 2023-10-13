using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static partial class GFunc
{
    // ! 씬에 있는 루트 오브젝트를 이름으로 찾아 리턴하는 함수
    public static GameObject GetRootObj(string objName_)
    {
        GameObject targetObj_ = default;
        Scene activeScene = GetActiveScene();        
        GameObject[] rootObjs = activeScene.GetRootGameObjects();
        foreach(GameObject rootObject in rootObjs)
        {
            if(rootObject.name == objName_)
            {
                targetObj_ = rootObject;
                return targetObj_;
            }       // if : name_과 같은 이름의 오브젝트가 존재하면 리턴
            else {  /* Do Nothing */ }
        }       // loop

        Debug.LogWarning("동일한 이름의 루트 오브젝트가 없습니다.");
        return targetObj_;
    }       // FindRootObj()

    // ! 특정 오브젝트의 자식 오브젝트를 모두 List<> 형으로 리턴하는 함수
    public static List<GameObject> GetChildrenObjs(this GameObject targetObj_)
    {
        List<GameObject> objs = new List<GameObject>();
        GameObject childObj = default;

        for(int i = 0; i < targetObj_.transform.childCount; i++)
        {
            childObj = targetObj_.transform.GetChild(i).gameObject;
            objs.Add(childObj);
        }       // loop 
        if (objs.IsValid()) { return objs; }
        else { return default(List<GameObject>); }         
    }       // GetChildObjs()

    // ! 특정 오브젝트의 자식 오브젝트를 이름으로 찾아 리턴하는 함수
    public static GameObject GetChildObj(this GameObject targetObj_, string objName_)
    {
        GameObject searchResult = default;
        GameObject searchTarget = default;
        for (int i = 0; i < targetObj_.transform.childCount; i++)
        {
            searchTarget = targetObj_.transform.GetChild(i).gameObject;
            if (searchTarget.name.Equals(objName_))
            {
                searchResult = searchTarget;
                return searchResult;
            }
            else
            {
                searchResult = GetChildObj(searchTarget, objName_);

                // 방어로직
                if (searchResult == null || searchResult == default) { /* Pass */ }
                else { return searchResult; }
            }
        }       // loop

        return searchResult;
    }       // GetChildObj()



    public static T CreateObj<T>(string objName_) where T : Component
    {
        GameObject createdObj = new GameObject(objName_);
        return createdObj.AddComponent<T>();
    }       // CreateObj()

    public static Scene GetActiveScene()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        return activeScene;
    }       // GetActiveScene()

}
