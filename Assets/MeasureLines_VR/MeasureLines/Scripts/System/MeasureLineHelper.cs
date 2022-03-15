using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeasureLineHelper : MonoBehaviour {

	static public void DestroyObjects(List<GameObject> targetObjects)
	{
		for(int i=0;i<targetObjects.Count;i++)
		{
			Destroy(targetObjects[i]);
		}
		targetObjects.Clear();
	}

	static public bool IsEmpty(Transform[] targetObjects)
	{
		bool isEmpty = true;
		if (targetObjects.Length==0)
		{
			isEmpty = true;
		}
		else
		{
			for (int i=0;i<targetObjects.Length;i++)
			{
				if (targetObjects[i]!=null)
				{
					isEmpty = false;
					break;
				}
			}
		}
		return isEmpty;
	}

	static public bool CheckIntInList(List<int> list, int serial)
	{
		bool result = false;
		for (int i=0;i<list.Count;i++)
		{
			if (list[i] == serial)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	static public bool CheckStringInList(string[] list, string str)
	{
		bool result = false;
		for (int i=0;i<list.Length;i++)
		{
			if (list[i] == str)
			{
				result = true;
				break;
			}
		}
		return result;
	}

    //检查一个元素是否在Array中
    static public bool ExistInArray(Transform item, Transform[] itemList)
    {
        bool result = false;
        for (int i = 0; i < itemList.Length; i++)
        {
            if (item == itemList[i])
            {
                result = true;
                break;
            }
        }
        return result;
    }

    static public void FindAllChilds (Transform target, ArrayList resultList)
	{
		if (target.childCount>0)
		{
			int i;
			for (i=0;i<target.childCount;i++)
			{
				FindAllChilds (target.GetChild(i), resultList);
			}
		}
		resultList.Add(target.gameObject);
	}

	static public void DelChildsWithName(Transform target, string[] names)
	{
		ArrayList resultList = new ArrayList();
		FindAllChilds(target, resultList);
		for (int i=0;i<resultList.Count;i++)
		{
			Transform tran = (resultList[i] as GameObject).transform;
			if (CheckStringInList(names, tran.name))
			{
				Destroy(tran.gameObject);
			}
		}
	}

	static public void CreateThreeAxisObj(Transform obj0, Transform obj1, out GameObject axisXZObj0, out GameObject axisXYObj0, out GameObject axisXZObj1, out GameObject axisXYObj1, out GameObject lowerObj, out GameObject higherObj)
	{
		axisXZObj0 = null;
		axisXYObj0 = null;
		axisXZObj1 = null;
		axisXYObj1 = null;
		lowerObj = null;
		higherObj = null;
		Transform lower = obj0.position.y<=obj1.position.y? obj0:obj1;
		Transform higher = obj0.position.y>obj1.position.y? obj0:obj1;

		//axisXZObj0
		Plane planeXZ = new Plane(lower.up, lower.position);
		Vector3 downPosFromHigher = higher.position + Vector3.down * planeXZ.GetDistanceToPoint(higher.position);
		axisXZObj0 = new GameObject("axisSubObj");
		axisXZObj0.transform.position = downPosFromHigher;
		SubAxis0 subAxis_A = axisXZObj0.AddComponent<SubAxis0>();
		subAxis_A.Init(lower, higher);
		axisXZObj0.transform.SetParent(higher.parent);

		//axisXYObj0
		Plane planeXY = new Plane(lower.forward, lower.position);
		Vector3 ZFromDownPos = downPosFromHigher - Vector3.forward * planeXY.GetDistanceToPoint(downPosFromHigher);
		axisXYObj0 = new GameObject("axisSubObj");
		axisXYObj0.transform.position = ZFromDownPos;
		axisXYObj0.AddComponent<SubAxis1>().Init(lower, higher, subAxis_A);
		axisXYObj0.transform.SetParent(lower.parent);

		//axisXZObj1
		axisXZObj1 = new GameObject("axisSubObj");
		axisXZObj1.transform.position = downPosFromHigher;
		axisXZObj1.transform.SetParent(higher.parent);
		SubAxis0 subAxis_B = axisXZObj1.AddComponent<SubAxis0>();
		subAxis_B.Init(lower, higher);

		//axisXYObj1
		axisXYObj1 = new GameObject("axisSubObj");
		axisXYObj1.transform.position = ZFromDownPos;
		axisXYObj1.transform.SetParent(lower.parent);
		axisXYObj1.AddComponent<SubAxis1>().Init(lower, higher, subAxis_B);


		lowerObj = new GameObject("lowerObj");
		lowerObj.transform.position = lower.position;
		lowerObj.transform.SetParent(lower.parent);
		lowerObj.AddComponent<ChildFollow>().Init(lower, lower, higher);

		higherObj = new GameObject("higherObj");
		higherObj.transform.position = higher.position;
		higherObj.transform.SetParent(higher.parent);
		higherObj.AddComponent<ChildFollow>().Init(higher, lower, higher);
	}


}
