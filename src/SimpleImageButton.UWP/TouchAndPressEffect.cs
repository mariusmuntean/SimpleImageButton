using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using SimpleImageButton.Contracts;
using SimpleImageButton.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ResolutionGroupName(TouchAndPressEffect.EffectIdPrefix)]
[assembly: ExportEffect(typeof(SimpleImageButton.UWP.TouchAndPressEffect), nameof(SimpleImageButton.UWP.TouchAndPressEffect))]

namespace SimpleImageButton.UWP
{
    public class TouchAndPressEffect : PlatformEffect
    {
        private ITouchAndPressEffectConsumer _effectConsumer;
        private FrameworkElement _view;

        protected override void OnAttached()
        {
            _view = Control ?? Container;

            if (Element is ITouchAndPressEffectConsumer touchAndPressEffectConsumer)
            {
                _effectConsumer = touchAndPressEffectConsumer;

                _view.PointerPressed += ViewOnPointerPressed;
                _view.PointerReleased += ViewOnPointerReleased;
                _view.PointerCanceled += ViewOnPointerCanceled;
            }
        }

        private void ViewOnPointerCanceled(object sender, PointerRoutedEventArgs e)
        {
            _effectConsumer.ConsumeEvent(EventType.Cancelled);
        }

        private void ViewOnPointerReleased(object sender, PointerRoutedEventArgs e)
        {
            _effectConsumer.ConsumeEvent(EventType.Released);
        }

        private void ViewOnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            _effectConsumer.ConsumeEvent(EventType.Pressing);
        }

        protected override void OnDetached()
        {
            if (_view != null)
            {
                _view.PointerPressed -= ViewOnPointerPressed;
                _view.PointerReleased -= ViewOnPointerReleased;
                _view.PointerCanceled -= ViewOnPointerCanceled;
            }
        }
    }
}