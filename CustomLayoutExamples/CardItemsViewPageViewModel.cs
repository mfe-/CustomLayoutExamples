using CustomLayoutExamples.Model;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomLayoutExamples;

public class CardItemsViewPageViewModel
{
    public CardItemsViewPageViewModel()
    {
        RemoveCommand = new Command<object>(RemoveItem);
        AddCommand = new Command<object>(AddItem);
    }
    public ObservableCollection<Card> Cards { get; set; } = new ObservableCollection<Card>()
    {
        new Card(1),
        new Card(2),
        new Card(3),
        new Card(4),
        new Card(4),
        new Card(4),
        new Card(4),
        new Card(4),
        new Card(4),
        new Card(4),
        new Card(4),
        new Card(4),
        new Card(4)
    };

    public ICommand RemoveCommand { get; }
    private void RemoveItem(object obj)
    {
        if (Cards.Count > 1)
        {
            Cards.RemoveAt(1);
        }
    }
    public ICommand AddCommand { get; }
    private void AddItem(object obj)
    {
        Card card = new Card(9);
        Cards.Add(card);
    }
}
