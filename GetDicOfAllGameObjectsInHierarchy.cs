using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDicOfAllGameObjectsInHierarchy : MonoBehaviour {

    public static Dictionary<string, GameObject> allGOs; //accès avec GetDicOfAllGameObjectsInHierarchy.allGOs

    public bool allGOs_Update = false;
    public bool print_allGOs = false;
	public bool SomeGOSHaveTheSameName;	

    void Start()
    {
		allGOs_Set();
    }

	void allGOs_Set(){
        allGOs = new Dictionary<string, GameObject>();
		SomeGOSHaveTheSameName = false;
        GameObject[] rootGOs = gameObject.scene.GetRootGameObjects();
        
        for (int i = 0; i < rootGOs.Length; i++)
            GetAllChildren(rootGOs[i].transform, 
                            allGOs,
                            "");
		
	}
	
    void GetAllChildren(Transform current, 
                        Dictionary<string, GameObject> dicToFill,
                        string rootname)
    {
        string chemin = "";
        if (rootname == "")
            chemin = current.gameObject.name;
        else
            chemin = rootname + "/" + current.gameObject.name;
		
		//if (dicToFill.KeysContains(chemin))
		//  SomeGOSHaveTheSameName = true;
        dicToFill.Add(chemin, 
                        current.gameObject);

        for (int i = 0; i < current.childCount; i++)
            GetAllChildren(current.GetChild(i), 
                            dicToFill,
                            chemin);
    }

    private void Update()
    {
		if (allGOs_Update)
		{
			allGOs_Set();
			allGOs_Update = false;
		}
		
        if (print_allGOs)
		{			
			allGOs_debug();
			print_allGOs = false;        
		}
	}

    void allGOs_debug()
    {
        foreach (string clef in allGOs.Keys)        
            Debug.Log(clef);
        
        Debug.Log("allGOs contains : " + allGOs.Keys.Count);
    }
}