using System;
using System.Linq;
using Xamarin.Forms;
using SimpleImageButton.Models;
using Xamarin.Forms.Internals;

namespace SimpleImageButton
{
    public partial class SimpleImageButton
    {
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case var isEnabledPropertyName when (propertyName == VisualElement.IsEnabledProperty.PropertyName):
                {
                    HandleIsEnabledChanged();
                    break;
                }
            }
        }

        private void HandleIsEnabledChanged()
        {
            if (IsEnabled)
            {
                VisualStateManager.GoToState(this, NormalState);
            }
            else
            {
                VisualStateManager.GoToState(this, DisabledState);
            }
        }

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

        public Style SimpleImageButtonLabelStyle
        {
            get => (Style) GetValue(LabelStyleProperty);
            set => SetValue(LabelStyleProperty, value);
        }

        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(
            nameof(CornerRadius),
            typeof(float),
            typeof(SimpleImageButton),
            0.0f,
            BindingMode.OneWay,
            propertyChanged: OnCornerRadiusChanged
        );

        public static void OnCornerRadiusChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
//            if (((SimpleImageButton) bindable).ButtonFrame != null)
//            {
//                ((SimpleImageButton) bindable).ButtonFrame.CornerRadius = (float) newvalue;
//            }
        }

        public float CornerRadius
        {
            get => (float) GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly BindableProperty ButtonBackgroundColorProperty = BindableProperty.Create(
            nameof(ButtonBackgroundColor),
            typeof(Color),
            typeof(SimpleImageButton),
            Color.Khaki,
            BindingMode.OneWay,
            propertyChanged: OnBackgroundColorChanged
        );

        public static void OnBackgroundColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
//            ((SimpleImageButton) bindable).ButtonFrame.BackgroundColor = (Color) newValue;
        }

        public Color ButtonBackgroundColor
        {
            get => (Color) GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }

        public static readonly BindableProperty SimpleImageButtonImageStyleProperty = BindableProperty.Create(
            nameof(SimpleImageButtonImageStyle),
            typeof(Style),
            typeof(SimpleImageButton),
            null,
            BindingMode.OneWay,
            propertyChanged: OnSimpleImageButtonImageStyleChanged
        );

        private static void OnSimpleImageButtonImageStyleChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            Console.WriteLine($"{nameof(SimpleImageButtonImageStyle)} new val: {newvalue}");
        }

        public Style SimpleImageButtonImageStyle
        {
            get => (Style) GetValue(SimpleImageButtonImageStyleProperty);
            set => SetValue(SimpleImageButtonImageStyleProperty, value);
        }


        public static readonly BindableProperty SimpleImageButtonFrameStyleProperty = BindableProperty.Create(
            nameof(SimpleImageButtonFrameStyle),
            typeof(Style),
            typeof(SimpleImageButton),
            null,
            BindingMode.OneWay,
            propertyChanged: OnSimpleImageButtonFrameStyleChanged
        );

        private static void OnSimpleImageButtonFrameStyleChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            Console.WriteLine($"{nameof(SimpleImageButtonFrameStyle)} new val: {newvalue}");
        }

        public Style SimpleImageButtonFrameStyle
        {
            get => (Style) GetValue(SimpleImageButtonFrameStyleProperty);
            set => SetValue(SimpleImageButtonFrameStyleProperty, value);
        }
    }
}