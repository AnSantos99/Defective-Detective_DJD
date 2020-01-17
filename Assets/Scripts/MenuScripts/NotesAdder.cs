using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NotesAdder
{
    // call this class in others to add notes to our class
    public static string NoteToAdd;
    public static List<string> NotesInNotes;    

    public static void SetNotes(string note)
    {
        NotesInNotes = new List<string>();
        NotesInNotes.Add(note);
    }
}
