using CustomLayoutExamples.Model;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomLayoutExamples;

public class CardItemsViewPageViewModel : INotifyPropertyChanged
{
    SynchronizationContext synchronizationContext = SynchronizationContext.Current;
    public CardItemsViewPageViewModel()
    {
        RemoveCommand = new Command<object>(RemoveItem);
        AddCommand = new Command<object>(AddItem);


    }
    private void InitCards()
    {
        Task.Run(async () =>
        {
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
                Page.Dispatcher.Dispatch(Init);
                //synchronizationContext.Post((o) => Init(), null);
                //Init();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }

        });
        //Init();
    }

    private Page _Page;
    public Page Page
    {
        get { return _Page; }
        set
        {
            SetProperty(ref _Page, value, nameof(Page));
            InitCards();
        }
    }

    private void Init()
    {
        Cards = new ObservableCollection<Card>()
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
    }
    public ObservableCollection<Card> Cards { get; set; }

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
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        var handler = PropertyChanged;
        if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    }
    protected bool SetProperty<T>(ref T field, T value, string propertyName)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
