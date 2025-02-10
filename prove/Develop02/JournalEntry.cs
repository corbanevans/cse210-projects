using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


class JournalEntry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public int MoodRating { get; set; }
}