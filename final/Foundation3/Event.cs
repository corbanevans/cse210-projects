using System;

class Event
{
    private string _title;
    private string _description;
    private DateTime _dateTime;
    private Address _address;

    public Event(string title, string description, DateTime dateTime, Address address)
    {
        _title = title;
        _description = description;
        _dateTime = dateTime;
        _address = address;
    }

    public virtual string GetStandardDetails()
    {
        return $"Title: {_title}\nDescription: {_description}\nDate and Time: {_dateTime}\nAddress: {_address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return $"Standard Details:\n{GetStandardDetails()}";
    }

    public virtual string GetShortDescription()
    {
        return $"Event Type: {GetType().Name}, Title: {_title}, Date: {_dateTime.Date.ToShortDateString()}";
    }
}