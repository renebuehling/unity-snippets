using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Stellt Objekteigenschaften im UI dar. 
/// 
/// Dieses Script wird an einen Canvas gehängt, der die
/// konkreten Darstellungskomponenten (Text, Button, etc.) 
/// enthält.
/// 
/// </summary>
public class EigenschaftenZeichner : MonoBehaviour
{
    /// <summary>
    /// Zeiger auf die Textkomponente, die den Text auf dem
    /// Bildschirm zeichnet.
    /// </summary>
    public Text textName;



    /// <summary>
    /// Löst die Darstellung auf, d.h. der Titel des Objekts
    /// aus dem Ereignis wird nun konkret in der Textkomponente
    /// auf dem Bildschirm gezeichnet.
    /// </summary>
    /// <param name="dasObjekt">Objekt dessen Titel gezeichnet werden soll. Kann null sein, um den Text zu leeren.</param>
    public void zeichneObjekt(ObjektMitTitel dasObjekt)
    {
        if (dasObjekt==null) // Kein Objekt -> leerer Text
            textName.text = "";
        else // Konkretes Objekt -> dessen Titel zeichnen
            textName.text = dasObjekt.titel;
    }


    /// <summary>
    /// Wenn der Eigenschaftenzeichner erzeugt wurde und bereit ist...
    /// </summary>
    public void Awake()
    {
        EventBus.bus.beiObjektMitTitelAenderung += zeichneObjekt; // Im Eventbus registrieren, dass die oben definierte Funktion zeichneObjekt aufgerufen wird.
    }

    public void OnDestroy()
    {
        EventBus.bus.beiObjektMitTitelAenderung -= zeichneObjekt; // Wenn dieser EigenschaftenZeichner gelöscht wird, auch die Benachrichtung wieder auflösen. (Sonst NullPointerException, wenn versucht wird, die Nachricht an das nicht mehr vorhandene Objekt zu schicken.)
    }



}
