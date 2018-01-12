using UnityEngine;


public class clicker : MonoBehaviour
{

    private string nimi;
    string value;
    string teksti = " - ";
    public string teksti2;
    public string teksti3 = "Tekstikentän tekstiä";

    furnitures huonekalut = new furnitures();
    SwitchText vaihda = new SwitchText();

    bool ShowThisGUI = false;
    
    private void OnGUI()
    {

        value = huonekalut.GetType(Nimi);
        teksti = vaihda.GetType(Nimi);

        GUIStyle style = new GUIStyle();
        GUIStyle otsikkostyle = new GUIStyle();
        GUIStyle btnstyle = new GUIStyle();
        
        style.fontSize = 50;
        style.normal.textColor = Color.white;
        style.alignment = TextAnchor.UpperCenter;

        otsikkostyle.fontSize = 25;
        otsikkostyle.alignment = TextAnchor.UpperCenter;
        otsikkostyle.normal.textColor = Color.white;

        btnstyle.fontSize = 17;
        btnstyle.alignment = TextAnchor.MiddleCenter;
        btnstyle.normal.textColor = Color.white;
        
        if (ShowThisGUI)
        {
            

            if (teksti == "Liesituuletin" || teksti == "Jääkaappi")
            {
                GUI.Box(new Rect(80, 50, Screen.width / 100 * 90, Screen.height / 100 * 50), "");
                GUI.Box(new Rect(80, 50, Screen.width / 100 * 90, Screen.height / 100 * 50), Nimi, otsikkostyle);
                GUI.Box(new Rect(80, 50, Screen.width / 100 * 90, Screen.height / 100 * 50), "\n" + value, style);

                if (GUI.Button(new Rect(80, 50, Screen.width / 10, Screen.height / 10), "Close", btnstyle))
                {
                    ShowThisGUI = false;

                }
            }

            if (teksti == "Lattia")
            {
                ShowThisGUI = false;
            }

            else
            {
                GUI.Box(new Rect(80, 50, Screen.width / 100 * 90, Screen.height / 100 * 12), "");
                GUI.Box(new Rect(80, 50, Screen.width / 100 * 90, Screen.height / 100 * 12), Nimi, otsikkostyle);

                if (GUI.Button(new Rect(80, 50, Screen.width / 10, Screen.height / 10), "Close", btnstyle))
                {
                    ShowThisGUI = false;

                }
            }
            

        }
    }
    
    public string Nimi
    {
        get
        {
            return nimi;
        }
        set
        {
            nimi = value;
        }
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            WWWFormScore thingconnection = (WWWFormScore)gameObject.AddComponent(typeof(WWWFormScore));
            GetText haeteksti = (GetText)gameObject.AddComponent(typeof(GetText));
            GetTemperature temperature = (GetTemperature)gameObject.AddComponent(typeof(GetTemperature));
            TurnLight valo = (TurnLight)gameObject.AddComponent(typeof(TurnLight));

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                this.Nimi = hit.transform.name;
                ShowThisGUI = true;

                Debug.Log("Pisteessa " + hit.point + " on " + hit.transform.name + " ja arvo on : " + value);
                
            }
        }

    }
    
}

//80, 50, Screen.width / 100 * 90, Screen.height / 100 * 50
//80, 50, Screen.width / 100 * 90, Screen.height / 100 * 50
//80,115, Screen.width / 100 * 90, Screen.height / 100 * 40