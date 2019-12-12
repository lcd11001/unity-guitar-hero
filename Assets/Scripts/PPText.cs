using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Player Press Text
public class PPText : MonoBehaviour
{
    public string name;
    public string cultureName = "fr-FR";

    private System.Globalization.CultureInfo culture;

    private void Awake()
    {
        // https://docs.microsoft.com/en-us/dotnet/api/system.string.format?view=netframework-4.8#System_String_Format_System_IFormatProvider_System_String_System_Object_
        culture = new System.Globalization.CultureInfo(cultureName);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = string.Format(culture, "{0:#,0}", PlayerPrefs.GetInt(name));
    }
}
