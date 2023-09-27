using System.Net.NetworkInformation;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private List<int> _orderOfHidden = new();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        List<string> wordsStrings = text.Split(' ').ToList();
        List<Word> words = new();
        foreach (string word in wordsStrings)
        {
            Word newWord = new(word);
            words.Add(newWord);
        }
        _words = words;
        
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> _shownWords = _words.Where(w => w.IsHidden() == false).ToList();
        Random randomGenerator = new Random();
        int amount = Math.Min(numberToHide,_shownWords.Count());
        for(int i = 0; i<amount;i++)
        {
            _shownWords = _words.Where(w => w.IsHidden() == false).ToList();
            int index = randomGenerator.Next(0,_shownWords.Count());
            _shownWords[index].Hide();
            _orderOfHidden.Add(_words.IndexOf(_shownWords[index]));
        }
    }
    public void ShowLastWords(int numberToShow)
    {
        //Console.WriteLine($"Min: {Math.Min(numberToShow,_orderOfHidden.Count())}");
        int amount = Math.Min(numberToShow,_orderOfHidden.Count());
        for(int i=1;i<=amount;i++)
        {
            int index = _orderOfHidden[_orderOfHidden.Count()-1];
            _words[index].Show();
            _orderOfHidden.RemoveAt(_orderOfHidden.Count()-1);
        }
    }
    public string GetDisplayText()
    {
        
        List<string> _finalWords;
        _finalWords = _words.Select(w => w.GetDisplayText()).ToList();
        string displayText = string.Join(' ',_finalWords);
        return displayText;
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if(word.IsHidden())
            {
                continue;
            }
            else
            {
                return false;
            }
        }
        return true;
    }
}