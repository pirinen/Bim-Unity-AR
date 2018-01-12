using UnityEngine;

public class furnitures : MonoBehaviour {
    
    string type;

    public string GetType(string nimi)
    {
        switch (nimi)
        {
            case "Jääkaappi":
                //type = WWWFormScore.ThingValue;
                type = GetText.ThingText;   //LTTNS15_Group3_Thing/Properties/teksti
                TurnLight.LED = false;
                break;

            case "Hella":
                type = "2";
                TurnLight.LED = true;
                break;

            case "Pöytataso":
                type = "3";
                TurnLight.LED = false;
                break;

            case "Liesituuletin":
                type = "Temp: " + GetTemperature.Temperature + " / Hum: " + GetTemperature.Humidity;
                TurnLight.LED = false;
                break;

            default:
                type = "50";
                TurnLight.LED = false;
                break;
        }

        return type;
    }

}
