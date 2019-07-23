using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Button-Script, um bei Klick auf den Button ein anderes Wörterbuch zu laden.
/// </summary>
public class SpracheWechseln : MonoBehaviour
{
    /// <summary>
    /// Wörterbuch das die neue Textdatei laden soll.
    /// </summary>
    public Woerterbuch buch;

    /// <summary>
    /// Zeiger auf die Textdatei, die geladen werden soll.
    /// </summary>
    public TextAsset textdatei;

    /// <summary>
    /// Script, das an das Klick-Ereignis des Buttons gebunden wird.
    /// </summary>
    public void ButtonKlick()
    {
        buch.setzeTextfile(textdatei);
    }
}
