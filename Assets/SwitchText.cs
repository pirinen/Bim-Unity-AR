using UnityEngine;

public class SwitchText : MonoBehaviour {

    string teksti;

    public string GetType(string nimi)
    {
        switch (nimi)
        {
            case "Jääkaappi":
                //teksti = GetText.ThingText;
                teksti = "Jääkaappi";
                break;

            case "Hella":
                
                teksti = " - ";
                break;

            case "Pöytataso":
                
                teksti = " b ";
                break;

            case "Liesituuletin":

                teksti = "Liesituuletin";
                break;

            case "Lattia":

                teksti = "Lattia";
                break;

            default:
                
                teksti = "";
                break;
        }

        return teksti;
    }
    
}
