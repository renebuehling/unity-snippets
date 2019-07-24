# W�rterbuch

Zugeh�riger Artikel: https://www.gamedev-profi.de/ui-text-aus-text-datei-befuellen/

Youtube-Video: https://www.youtube.com/watch?v=zcAZ5C-IcNM

## Textfile-Format

- Zeilen, die mit `;` beginnen, sind Kommentare und werden ignoriert.
- Wenn eine Zeile aus Wort+Leerzeichen+Text besteht, wird Wort als Schl�ssel und der Text als Wert gespeichert.
- Leere Zeilen und Zeilen ohne Leerzeichen werden ignoriert.
- Zeilenumbr�che k�nnen mit `\n` oder `<br>` erzeugt werden.
- Einfache Formatierungen sind mit Unitys [Text-Markup](https://docs.unity3d.com/Manual/StyledText.html) m�glich, sofern das Ziel-Textfeld die Eigenschaft `richText` gesetzt hat.
