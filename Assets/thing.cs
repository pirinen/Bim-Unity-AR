using UnityEngine;
using System.Collections;
using SimpleJSON;
//Jukka Pirinen 3.11.2017
public class parseJSON
 {
     public string title;
 }

public class WWWFormScore : MonoBehaviour {

    private static string thingvalue;

    public static string ThingValue
    {
        get
        {
            return thingvalue;
        }
        set
        {
            thingvalue = value;
        }
    }

    void Start () {

        string url = "https://un:pw@aca-karelia01.elisaiot.com/Thingworx/Things/LTTNS15_Group3_Thing/Properties/test?method=get&Accept=Application/json";

        WWW www = new WWW(url);    

        StartCoroutine(WaitForRequest(www));
    }
    // Use this for initialization
    IEnumerator WaitForRequest(WWW www) {
           
        yield return www;
        if (www.error == null)
        {
            //Debug.Log("WWW Ok!: " + www.text);
            JSONNode node = JSON.Parse(www.text);
            ThingValue = node["rows"][0]["test"];
            //Debug.Log("Value = " + ThingValue);
        }
        else
        {
            Debug.Log("WWW Error: " + www.text);
        }
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
        }
    
    }

}

