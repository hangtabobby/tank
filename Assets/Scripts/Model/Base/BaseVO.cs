using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;

public class BaseVO
{
    protected JSONNode data; //luu json

    public void LoadData(string dataName)
    {
        TextAsset text = Resources.Load<TextAsset>("Data/"+ dataName);
        JSONNode json = JSON.Parse(text.text);
        data = json["data"];
    }
}
