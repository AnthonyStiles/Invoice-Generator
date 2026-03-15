using System.Text.RegularExpressions;

namespace Invoice_Generator.Behaviours;

public class SortCodeMaskBehaviour : Behavior<Entry>
{
    protected override void OnAttachedTo(Entry entry)
    {
        entry.TextChanged += OnEntryTextChanged;
        base.OnAttachedTo(entry);
    }

    protected override void OnDetachingFrom(Entry entry)
    {
        entry.TextChanged -= OnEntryTextChanged;
        base.OnDetachingFrom(entry);
    }
    
    private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = (Entry)sender;
        var sortCode = e.NewTextValue;
        
        if (string.IsNullOrEmpty(sortCode))
        {
            return;
        }
        
        sortCode = Regex.Replace(e.NewTextValue, @"[^\d]", "");

        if (sortCode.Length > 6)
        {
            sortCode = sortCode.Substring(0, 6);
        }

        if (sortCode.Length > 2)
        {
            var firstHalf = sortCode.Substring(0, 2);
            var secondHalf = sortCode.Substring(2, sortCode.Length - 2);
            sortCode = $"{firstHalf}-{secondHalf}";
        }

        if (sortCode.Length > 5)
        {
            var firstHalf = sortCode.Substring(0, 5);
            var secondHalf = sortCode.Substring(5, sortCode.Length - 5);
            sortCode = $"{firstHalf}-{secondHalf}";
        }

        if (entry.Text != sortCode)
        {
            entry.Text = sortCode;
        }
    }
}