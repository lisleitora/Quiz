using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace quiz.Views
{
    public partial class ItemResultView : ContentView
    {
        public ItemResultView(string _title, string _value)
        {
            InitializeComponent();
            title.Text = _title;
            value.Text = _value;
        }
    }
}
