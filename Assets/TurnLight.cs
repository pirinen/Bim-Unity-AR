using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


public class DataTeksti
{
    public bool LED;
}

public class DataRows
{
    public string rows;
}

public class TurnLight : MonoBehaviour
{
    private static bool led;// = false;
    public static bool LED
    {
        get
        {
            return led;
        }
        set
        {
            led = value;
        }
    }
    string authenticate(string username, string password)
    {
        string auth = username + ":" + password;
        auth = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
        auth = "Basic " + auth;
        return auth;
    }

    void Start()
    {
        StartCoroutine(WaitForRequest());
    }

    // Use this for initialization
    IEnumerator WaitForRequest()
    {
        string urli = "https://aca-karelia01.elisaiot.com/Thingworx/Things/LTTNS15_G3_ToinenThing/Properties/LED";
        WWWForm form = new WWWForm();

        DataTeksti datateksti = new DataTeksti();
        DataRows datarows = new DataRows();

        datateksti.LED = LED;

        string k = JsonUtility.ToJson(datateksti);
        Debug.Log("string : " + k);
        datarows.rows = "[" + k + "]";  //<--
        string l = JsonUtility.ToJson(datarows);
        Debug.Log("string l : " + l);

        UnityWebRequest www = UnityWebRequest.Put(urli, k);

        string authorization = authenticate("name", "pw");
        www.SetRequestHeader("Authorization", authorization);

        www.SetRequestHeader("postman-token", "07c850ec-0eb6-08c8-900c-246ed5cfbf6a");
        www.SetRequestHeader("Cache-control", "no-cache");
        www.SetRequestHeader("Content-Type", "application/json");
        www.SetRequestHeader("Accept", "application/json");

        yield return www.Send();

        
        if (www.error == null && www != null)
        {
            Debug.Log("TurnLight Complete!");
            Debug.Log("Complete Responsecode: " + www.responseCode);
        }
        else
        {
            Debug.Log("WWW Error: " + www.downloadHandler.text);
            Debug.Log("Error Responsecode: " + www.responseCode);
        }
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
