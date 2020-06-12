using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    /*
     * - UI soll sich hier eintragen können, benachrichtigt werden, wenn ein Mausereignis statt findet.
     * - ObjektMitTitel hier eine Benachrichtung absetzen können, dann Weiterleitung an UI
     */



/// <summary>
/// Zentrale Anlaufstelle, um Daten auszutauschen, ohne sich dabei auf konkrete Objekte
/// festlegen zu müssen. 
/// 
/// Da der EventBus ein zentrales Element ist, verwenden wir eine statische Instanz namens bus,
/// auf die alle anderen Scripte unkompliziert zugreifen können.
/// 
/// Ablauf und Nutzung: 
/// 
/// Objekte wie der EigenschaftenZeichner, die bei Eintritt eines Ereignisse (z.B. Änderung des aktiven ObjektMitTitel) benachrichtigt
/// werden wollen, tragen sich in der "Ereignisliste" ein. 
/// 
/// Objekte wie das ObjektMitTitel, die eine Änderung bekannt geben wollen, rufen die
/// Zuhörer in der Liste auf, in dem sie das Ereignis auslösen.
/// 
/// </summary>
public class EventBus
{
    /// <summary>
    /// Ein konkretes Objekt, das als Registrierungsstelle für alle
    /// anderen Objekte bereit steht. 
    /// </summary>
    public static EventBus bus = new EventBus();

    //------------------------------------------

    /// <summary>
    /// Beschreibt die Form, die Funktionen haben müssen, damit sie sich in 
    /// die Benachrichtigungsliste eintragen können.
    /// 
    /// Die Form ist hier: 
    /// - void - kein Rückgabewert
    /// - ObjektMitTitel omt - ein Parameter vom Typ omt
    /// </summary>
    public delegate void FunktionFuerObjektMitTitel(ObjektMitTitel omt);


    /// <summary>
    /// Eine Liste in die Funktionen eingetragen werden können, 
    /// wenn sie der im Delegate oben beschriebenen Form entsprechen.
    /// </summary>
    public event FunktionFuerObjektMitTitel beiObjektMitTitelAenderung;

    /// <summary>
    /// Ruft alle Funktionen auf, die in der Liste beiObjektMitTitelAenderung
    /// eingetragen wurden. 
    /// 
    /// Ein event kann nur von der Klasse aufgerufen werden,
    /// die das Event/Liste selbst enthält. Damit auch andere Objekte wie
    /// das ObjektMitTitel den Aufruf auslösen können, bieten wir
    /// diese Helferfunktion an.
    /// </summary>
    /// <param name="dasObjekt">Das Objekt mit Titel, das an die Funktionen in der Ereignisliste weitergereicht werden soll. </param>
    public void beiObjektMitTitelAenderung_aufrufen(ObjektMitTitel dasObjekt)
    {
        beiObjektMitTitelAenderung(dasObjekt);
    }
}
