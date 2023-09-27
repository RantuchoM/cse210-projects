using System.Net.NetworkInformation;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private List<int> _orderOfHidden = new(); //I added this property that can grab the order of how the words are hidden, so they can be shown in revers order

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
        List<Word> _shownWords = _words.Where(w => w.IsHidden() == false).ToList(); //this filters the words that aren't still hidden, so it hides the exact amount the user input
        Random randomGenerator = new Random();
        int amount = Math.Min(numberToHide,_shownWords.Count()); //it counts how many words are left, and hides it the minimum between the amount input by the user, and that count
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
        //This function shows the words in the reverse order as they were hidden
        int amount = Math.Min(numberToShow,_orderOfHidden.Count()); //it counts how many words are left, and hides it the minimum between the amount input by the user, and that count
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
                return false; //the loop returns false when the first shown word is found, so it's more efficient
            }
        }
        return true;
    }
}