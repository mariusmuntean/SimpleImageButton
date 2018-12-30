using System;
using SimpleImageButton.Contracts;
using Xamarin.Forms;

namespace SimpleImageButton
{
    public partial class SimpleImageButton : Frame, ITouchAndPressEffectConsumer
    {
        public static readonly string NormalState = "normal";
        public static readonly string PressedState = "pressed";
        public static readonly string DisabledState = "disabled";

        public SimpleImageButton()
        {
            InitializeComponent();
        }

        public void ConsumeEvent(EventType gestureType)
        {
            switch (gestureType)
            {
                case EventType.Pressing:
                    VisualStateManager.GoToState(ME, PressedState);
                    break;
                case EventType.Cancelled:
                    VisualStateManager.GoToState(ME, DisabledState);
                    break;
                case EventType.Released:
                    VisualStateManager.GoToState(ME, NormalState);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gestureType), gestureType, null);
            }
        }
    }
}