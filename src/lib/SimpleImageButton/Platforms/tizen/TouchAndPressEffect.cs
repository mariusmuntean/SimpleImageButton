using ElmSharp;
using SimpleImageButton.SimpleImageButton.Contracts;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;

[assembly: ResolutionGroupName(SimpleImageButton.SimpleImageButton.Effects.TouchAndPressEffect.EffectIdPrefix)]
[assembly: ExportEffect(typeof(SimpleImageButton.Platforms.tizen.TouchAndPressEffect), nameof(SimpleImageButton.Platforms.tizen.TouchAndPressEffect))]
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
                Console.WriteLine("_view is null. leaving");
                return;
            }

            Console.WriteLine($"_view is {_view}");

            if (Element is ITouchAndPressEffectConsumer touchAndPressEffectConsumer)
            {
                var gestureRecognizer = new GestureLayer(_view);
                gestureRecognizer.Attach(_view);

                Console.WriteLine("Attaching gesture recognizer to _view");

                gestureRecognizer.SetTapCallback(GestureLayer.GestureType.Tap,
                    GestureLayer.GestureState.Start,
                    arg =>
                    {
                        touchAndPressEffectConsumer.ConsumeEvent(EventType.Pressing);
                        Console.WriteLine("Tizen: Tap Start");
                    });

                gestureRecognizer.SetTapCallback(GestureLayer.GestureType.Tap,
                    GestureLayer.GestureState.End,
                    arg =>
                    {
                        touchAndPressEffectConsumer.ConsumeEvent(EventType.Released);
                        Console.WriteLine("Tizen: Tap End");
                    });

                gestureRecognizer.SetTapCallback(GestureLayer.GestureType.Tap,
                    GestureLayer.GestureState.Abort,
                    arg =>
                    {
                        touchAndPressEffectConsumer.ConsumeEvent(EventType.Cancelled);
                        Console.WriteLine("Tizen: Tap Abort");
                    });
            }
            else
            {
                Console.WriteLine("Element is NOT ITouchAndPressEffectConsumer");
            }
        }

        protected override void OnDetached()
        {
            Console.WriteLine("TIZEN TouchAndPressEffect OnDetach()");
        }
    }
}