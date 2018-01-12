using System.Collections;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;

public class GetTemperature : MonoBehaviour {

    private static string temperature = "0";
    private static string humidity = "0";

    private string user = "name";
    private string pw = "pw";
    private string host = "aca-karelia01.elisaiot.com";
    private string address = "/Thingworx/Things/LTTNS15_G3_ToinenThing/Properties/";
    private string accept = "Application/json";
    private string method = "get";

    public static string Temperature
    {
        get
        {
            return temperature;
        }
        set
        {
            temperature = value;
        }
    }

    public static string Humidity
    {
        get
        {
            return humidity;
        }
        set
        {
            humidity = value;
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
        string urlToTemperature = "https://" + host + address + "numero?method=" + method + "&Accept=" + accept;
        string urlToHumidity = "https://" + host + address + "Log?method=" + method + "&Accept=" + accept;
        UnityWebRequest www = UnityWebRequest.Get(urlToTemperature);
        UnityWebRequest www1 = UnityWebRequest.Get(urlToHumidity);
        
        string authorization = authenticate("name", "pw");
        www.SetRequestHeader("Authorization", authorization);
        www1.SetRequestHeader("Authorization", authorization);
        
        yield return www.Send();
        yield return www1.Send();
        
        if (www.error == null && www != null)
        {
            JSONNode node = JSON.Parse(www.downloadHandler.text);
            Temperature = node["rows"][0]["numero"] + "C";
        }
        if (www1.error == null && www1 != null)
        {
            JSONNode node1 = JSON.Parse(www1.downloadHandler.text);
            Humidity = node1["rows"][0]["Log"] + "%";
        }
        else
        {
            Debug.Log("WWW Error: " + www.downloadHandler.text);
        }
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
        }

    }

}


