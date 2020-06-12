using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hält inhaltliche Daten des Objekts bereit.
/// </summary>
[RequireComponent(typeof(BoxCollider))] // -> Dieses Script braucht auch einen BoxCollider -> fehlenden Collider automatisch erzeugen, wenn das Script im Inspector hinzugefügt wird.
public class ObjektMitTitel : MonoBehaviour
{
    /// <summary>
    /// Ein beliebiger Text oder Name, der erscheinen soll, 
    /// wenn die Maus auf dieses Objekt zeigt.
    /// </summary>
    public string titel = "";

    public void OnMouseEnter() // Unity-Nachricht: Unity weiß schon automatisch, wann es diese Funktion aufrufen muss
    {
        EventBus.bus.beiObjektMitTitelAenderung_aufrufen(this); // Zeigt die Maus auf mich, dann mich selbst an im Eventbus eingetragene Darstellungsfunktionen weiterleiten.
    }

    public void OnMouseExit()
    {
        EventBus.bus.beiObjektMitTitelAenderung_aufrufen(null); // Wird die Maus vom Objekt runter bewegt, dann Null (Leere) an im Eventbus eingetragene Darstellungsfunktionen weiterleiten.
    }
}
