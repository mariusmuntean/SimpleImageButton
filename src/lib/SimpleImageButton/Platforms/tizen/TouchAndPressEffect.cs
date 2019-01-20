using System;
using System.Diagnostics;
using ElmSharp;
using SimpleImageButton.Platforms.tizen;
using SimpleImageButton.SimpleImageButton.Contracts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;

[assembly: ResolutionGroupName(SimpleImageButton.SimpleImageButton.Effects.TouchAndPressEffect.EffectIdPrefix)]
[assembly: ExportEffect(typeof(TouchAndPressEffect), nameof(TouchAndPressEffect))]

namespace SimpleImageButton.Platforms.tizen
{
    public class TouchAndPressEffect : PlatformEffect
    {
        private EvasObject _view;

        protected override void OnAttached()
        {
            Console.WriteLine("Tizen OnAttached()");
            _view = Control ?? Container;

            if (_view == null)
            {
                Debug.WriteLine("_view is null. leaving");
                return;
            }

            Debug.WriteLine($"_view is {_view}");

            if (_view is ITouchAndPressEffectConsumer touchAndPressEffectConsumer)
            {
                var gestureRecognizer = new ElmSharp.GestureLayer(_view);
                gestureRecognizer.Attach(_view);

                Debug.WriteLine("Attaching gesture recognizer to _view");

                gestureRecognizer.SetTapCallback(ElmSharp.GestureLayer.GestureType.Tap,
                    ElmSharp.GestureLayer.GestureState.Start,
                    arg =>
                    {
                        touchAndPressEffectConsumer.ConsumeEvent(EventType.Pressing);
                        Debug.WriteLine("Tizen: Tap Start");
                    });

                gestureRecognizer.SetTapCallback(ElmSharp.GestureLayer.GestureType.Tap,
                    ElmSharp.GestureLayer.GestureState.End,
                    arg =>
                    {
                        touchAndPressEffectConsumer.ConsumeEvent(EventType.Released);
                        Debug.WriteLine("Tizen: Tap End");
                    });

                gestureRecognizer.SetTapCallback(ElmSharp.GestureLayer.GestureType.Tap,
                    ElmSharp.GestureLayer.GestureState.Abort,
                    arg =>
                    {
                        touchAndPressEffectConsumer.ConsumeEvent(EventType.Cancelled);
                        Debug.WriteLine("Tizen: Tap Abort");
                    });
            }
        }

        protected override void OnDetached()
        {
            throw new System.NotImplementedException();
        }
    }
}