using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script, um bei Klick auf einen Button einen Text aus dem Wörterbuch zu lesen 
/// und einem Textfeld zuzuweisen.
/// </summary>
public class WortLesen : MonoBehaviour
{
    /// <summary>
    /// Textfeld das den gelesenen Text anzeigt.
    /// </summary>
    public Text textfeld;

    /// <summary>
    /// Wörterbuch aus dessen Wortschatz der Text geladen wird.
    /// </summary>
    public Woerterbuch buch;

    /// <summary>
    /// Funktion, die an das Klick-Ereignis des Buttons gebunden wird.
    /// </summary>
    /// <param name="schluessel">Schlüssel-Begriff der die zu ladende Textzeile identifiziert.</param>
    public void ButtonKlick(string schluessel)
    {
        textfeld.text = buch.lies(schluessel);
    }

}
