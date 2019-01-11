using AppKit;
using SimpleImageButton.Contracts;
using SimpleImageButton.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

[assembly: ResolutionGroupName(TouchAndPressEffect.EffectIdPrefix)]
[assembly: ExportEffect(typeof(SimpleImageButton.macOS.TouchAndPressEffect), nameof(SimpleImageButton.macOS.TouchAndPressEffect))]

namespace SimpleImageButton.macOS
{
    public class TouchAndPressEffect : PlatformEffect
    {
        private NSView _view;
        private TouchAndPressGestureRecognizer _touchAndPressGestureRecognizer;

        protected override void OnAttached()
        {
            _view = Control ?? Container;

            if (Element is ITouchAndPressEffectConsumer touchAndPressEffectConsumer)
            {
                _touchAndPressGestureRecognizer = new TouchAndPressGestureRecognizer(touchAndPressEffectConsumer);
                _view.AddGestureRecognizer(_touchAndPressGestureRecognizer);
            }

            // Ensure the button scales with respect to its center - there seems to be a bug on macOS so this is necessary
            if (Element is VisualElement visualElement)
            {
                visualElement.AnchorX = 1.0;
                visualElement.AnchorY = 1.0;
            }
        }

        protected override void OnDetached()
        {
            if (_view != null && _touchAndPressGestureRecognizer != null)
            {
                _view.RemoveGestureRecognizer(_touchAndPressGestureRecognizer);
            }
        }

        private class TouchAndPressGestureRecognizer : NSGestureRecognizer
        {
            private readonly ITouchAndPressEffectConsumer _touchAndPressEffectConsumer;

            public TouchAndPressGestureRecognizer(ITouchAndPressEffectConsumer touchAndPressEffectConsumer)
            {
                _touchAndPressEffectConsumer = touchAndPressEffectConsumer;
            }

            public override void MouseDown(NSEvent mouseEvent)
            {
                base.MouseDown(mouseEvent);
                _touchAndPressEffectConsumer.ConsumeEvent(EventType.Pressing);
            }

            public override void MouseUp(NSEvent mouseEvent)
            {
                base.MouseUp(mouseEvent);
                _touchAndPressEffectConsumer.ConsumeEvent(EventType.Released);
            }

            public override void TouchesBegan(NSEvent touchEvent)
            {
                base.TouchesBegan(touchEvent);
                _touchAndPressEffectConsumer.ConsumeEvent(EventType.Pressing);
            }

            public override void TouchesEnded(NSEvent touchEvent)
            {
                base.TouchesEnded(touchEvent);
                _touchAndPressEffectConsumer.ConsumeEvent(EventType.Released);
            }

            public override void TouchesCancelled(NSEvent touchEvent)
            {
                base.TouchesCancelled(touchEvent);
                _touchAndPressEffectConsumer.ConsumeEvent(EventType.Cancelled);
            }
        }
    }
}