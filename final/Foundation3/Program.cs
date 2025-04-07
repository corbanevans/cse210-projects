using System;

class Program
{
    static void Main()
    {
        Address address1 = new Address("123 Elm St", "Springfield", "IL", "USA");
        Event lecture = new Lecture("Tech Innovations", "A lecture on the latest in technology.", new DateTime(2025, 5, 20, 10, 0, 0), address1, "Dr. Alice Smith", 100);

        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Event reception = new Reception("Networking Night", "An evening of professional networking.", new DateTime(2025, 6, 15, 18, 0, 0), address2, "rsvp@events.com");

        Address address3 = new Address("789 Pine St", "Denver", "CO", "USA");
        Event outdoorGathering = new OutdoorGathering("Summer Festival", "A fun outdoor festival for all ages.", new DateTime(2025, 7, 4, 15, 0, 0), address3, "Sunny and clear skies");

        Event[] events = { lecture, reception, outdoorGathering };

        foreach (var evt in events)
        {
            Console.WriteLine(evt.GetStandardDetails());
            Console.WriteLine(evt.GetFullDetails());
            Console.WriteLine(evt.GetShortDescription());
            Console.WriteLine();
        }
    }
}