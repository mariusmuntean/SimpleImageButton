using AppKit;
using SimpleImageButton.Contracts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

[assembly: ResolutionGroupName("marius")]
[assembly: ExportEffect(typeof(SimpleImageButton.macOS.TouchAndPressEffect), "TouchAndPressEffect")]

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