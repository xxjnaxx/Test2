﻿using System.Collections.ObjectModel;

namespace CollectionViewError;

public partial class MainPage : ContentPage
{
	private readonly string[] sourceItems = new[] { "PDF1", "PDF2", "PDF3", "Hello", "Ordner" };

	public ObservableCollection<string> MyItems { get; set; }

	public MainPage()
	{
		InitializeComponent();

		MyItems = new ObservableCollection<string>(sourceItems);
		BindingContext = this;
	}

    void SearchBar_TextChanged(Object sender, TextChangedEventArgs e)
    {
        var searchTerm = e.NewTextValue;

        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            searchTerm = string.Empty;
        }

        searchTerm = searchTerm.ToLowerInvariant();

        var filteredItems = sourceItems.Where(value => value.ToLowerInvariant().Contains(searchTerm)).ToList();


        foreach (var value in sourceItems)
        {
            if (!filteredItems.Contains(value))
            {
                MyItems.Remove(value);
            }
            else if (!MyItems.Contains(value))
            {
                MyItems.Add(value);
            }
        }

    }
}

