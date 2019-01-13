using System;
using SimpleImageButton.SimpleImageButton.Contracts;
using Xamarin.Forms;

namespace SimpleImageButton.SimpleImageButton
{
    public partial class SimpleImageButton : ContentView, ITouchAndPressEffectConsumer
    {
        // Style names - constants to be used easier by the library consumers
        public const string FrameStyleName = "SimpleImageButtonFrameStyle";
        public const string LabelStyleName = "SimpleImageButtonLabelStyle";
        public const string ImageStyleName = "SimpleImageButtonImageStyle";

        // Visual states - constants to be used easier by the library consumer
        public static readonly string VisualStateGroupName = "CommonButtonStates";

        public static readonly string NormalState = "normal";
        public static readonly string PressedState = "pressed";
        public static readonly string DisabledState = "disabled";

        public SimpleImageButton()
        {
            InitializeComponent();

            // Set default values
            SimpleImageButtonFrameStyle = (Style) Resources[FrameStyleName];
            SimpleImageButtonLabelStyle = (Style) Resources[LabelStyleName];
            SimpleImageButtonImageStyle = (Style) Resources[ImageStyleName];
        }

        public void ConsumeEvent(EventType gestureType)
        {
            switch (gestureType)
            {
                case EventType.Pressing:
                    VisualStateManager.GoToState(ME, PressedState);
                    break;
                case EventType.Cancelled:
                case EventType.Released:

                    // Execute any command
                    // ToDo: decide if the length of the press shall be considered
                    Command?.Execute(null);

                    // Update the VSM state
                    VisualStateManager.GoToState(ME, NormalState);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gestureType), gestureType, null);
            }
        }
    }
}