using System;
using Xamarin.Forms;
using SimpleImageButton.Models;

namespace SimpleImageButton
{
    public partial class SimpleImageButton
    {
        public static readonly BindableProperty LabelTextProperty = BindableProperty.Create(
            "LabelText",
            typeof(string),
            typeof(SimpleImageButton),
            null,
            BindingMode.OneWay,
            propertyChanged: OnLabelTextPropertyChanged
        );

        private static void OnLabelTextPropertyChanged(object bindable, object oldValue, object newValue)
        {
            Console.WriteLine($"Label text changed to {newValue}");
        }

        public string LabelText
        {
            get => (string) GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }


        public static readonly BindableProperty LabelLocationProperty = BindableProperty.Create(
            "LabelLocation",
            typeof(LabelLocation),
            typeof(SimpleImageButton),
            LabelLocation.Bottom,
            BindingMode.OneWay,
            propertyChanged: OnLabelLocationPropertyChange
        );

        static void OnLabelLocationPropertyChange(BindableObject bindable, object oldValue, object newValue)
        {
            Console.WriteLine($"Label location changed to: {newValue}");
        }

        public LabelLocation LabelLocation
        {
            get => (LabelLocation) GetValue(LabelLocationProperty);
            set => SetValue(LabelLocationProperty, value);
        }

        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(
            "ImageSource",
            typeof(ImageSource),
            typeof(SimpleImageButton),
            null,
            BindingMode.OneWay,
            propertyChanged: OnImageSourceChanged
        );

        private static void OnImageSourceChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            Console.WriteLine($"Image source changed to: {newvalue}");
        }

        public ImageSource ImageSource
        {
            get => (ImageSource) GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }


        public static readonly BindableProperty LabelStyleProperty = BindableProperty.Create(
            "LabelStyle"
            , typeof(Style),
            typeof(SimpleImageButton),
            null,
            BindingMode.OneWay,
            propertyChanged: OnLabelStyleChanged
        );

        private static void OnLabelStyleChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is SimpleImageButton simpleImageButton)
            {
                simpleImageButton.ButtonLabel.Style = (Style) newvalue;
            }
        }

        public Style LabelStyle
        {
            get => (Style) GetValue(LabelStyleProperty);
            set => SetValue(LabelStyleProperty, value);
        }
    }
}