// See https://aka.ms/new-console-template for more information
using System.CodeDom.Compiler;
using System.ComponentModel;

Console.WriteLine("Hello, Memento (undo, redo)!");

var textEditor = new TextEditor();
var careTaker = new CareTaker(textEditor);
while (true)
{
    Console.Clear();
    Console.WriteLine("Taper une phrase et terminer par entrée");
    Console.WriteLine("Taper 'u' pour annuler la dernière saisie");
    Console.WriteLine("Taper 'r' pour restaurer la dernière saisie");
    Console.WriteLine("---------------------------------------------");
    Console.WriteLine(textEditor.Text);
    Console.WriteLine("---------------------------------------------");

    var saisie = Console.ReadLine();
    switch (saisie)
    {
        case "u":
            careTaker.Undo();
            break;
        case "r":
            careTaker.Redo();
            break;
        default:
            textEditor.Text += saisie + Environment.NewLine;
            careTaker.Backup();
            break;
    }
}

public class Memento
{
    public string Text { get;}
    public Memento(string text)
    {
        Text = text;
    }
}

public class TextEditor
{
    public string Text { get; set; }

    public Memento Save()
    {
        return new Memento(Text);
    }
    public void Restore(Memento memento)
    {
        Text = memento.Text;
    }
}

public class CareTaker
{
    private List<Memento> mementos = new List<Memento>();
    private readonly TextEditor _textEditor;
    private int _index = -1;
    public CareTaker(TextEditor textEditor)
    {
        _textEditor = textEditor;
    }

    public void Backup()
    {
        mementos.Add(_textEditor.Save());
        _index++;
    }

    public void Undo()
    {
        if(_index <= 0) return;        
        _index--;
        _textEditor.Restore(mementos[_index]);
    }
    public void Redo()
    {
        if(_index + 1 >= mementos.Count) return;
        _index++;
        _textEditor.Restore(mementos[_index]);
    }
}