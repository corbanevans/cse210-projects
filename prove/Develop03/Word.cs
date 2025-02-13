using System;

class Word
{
    public string _text { get; }
    public bool _isHidden { get; private set; }

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide() => _isHidden = true;

    public override string ToString() => _isHidden ? "_____" : _text;
}