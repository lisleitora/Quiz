using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace quiz.Views
{
    public partial class ButtonView : ContentView
    {
        bool isBusy;
        public Command CallBack;

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            nameof(FontSize),
            typeof(int),
            typeof(ButtonView),
            defaultValue: 25,
            defaultBindingMode: BindingMode.OneTime,
            propertyChanged: FontSizePropertyChanged);

        private static void FontSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (ButtonView)bindable;
            control.Value.FontSize = (int)newValue;
        }

        public int FontSize
        {
            get { return (int)base.GetValue(FontSizeProperty); }
            set { base.SetValue(FontSizeProperty, value); }
        }


        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(String),
            typeof(ButtonView),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.OneTime,
            propertyChanged: TextPropertyChanged);

        private static void TextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (ButtonView)bindable;
            control.Value.Text = newValue?.ToString();
        }

        public String Text
        {
            get { return base.GetValue(TextProperty)?.ToString(); }
            set { base.SetValue(TextProperty, value); }
        }

       
        public ButtonView()
        {
            InitializeComponent();
        }

       async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            if (isBusy)
            {
                return;
            }
            isBusy = true;
            await this.ScaleTo(1.2, 100);

            await this.ScaleTo(0.7, 100);
           await this.ScaleTo(1, 100);

            if (CallBack!=null) CallBack.Execute(null);
            isBusy = false;
        }

        public event EventHandler Clicked
        {
            add
            {
                lock (Gesture)
                {
                    Gesture.Tapped += value;
                }
            }
            remove
            {
                lock (Gesture)
                {
                    Gesture.Tapped -= value;
                }
            }
        }
    }
}
