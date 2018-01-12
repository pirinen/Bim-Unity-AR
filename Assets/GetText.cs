using System.Collections;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;
//Jukka Pirinen 3.11.2017
public class GetText : MonoBehaviour {

    private static string thingtext = "Empty";

    public static string ThingText
    {
        get
        {
            return thingtext;
        }
        set
        {
            thingtext = value;
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

        string urli = "https://aca-karelia01.elisaiot.com/Thingworx/Things/LTTNS15_Group3_Thing/Properties/teksti?method=get&Accept=Application/json";
        UnityWebRequest www = UnityWebRequest.Get(urli);

        string authorization = authenticate("name", "pw");
        www.SetRequestHeader("Authorization", authorization);

        yield return www.Send();

        if (www.error == null && www != null)
        {
            JSONNode node = JSON.Parse(www.downloadHandler.text);
            ThingText = node["rows"][0]["teksti"];
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

