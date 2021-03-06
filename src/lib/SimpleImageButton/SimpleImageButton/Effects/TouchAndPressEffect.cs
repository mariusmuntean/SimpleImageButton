using Xamarin.Forms;

namespace SimpleImageButton.SimpleImageButton.Effects
{
    public class TouchAndPressEffect : RoutingEffect
    {
        public const string EffectIdPrefix = "de.marius";

        public TouchAndPressEffect() : base($"{EffectIdPrefix}.{nameof(TouchAndPressEffect)}")
        {
        }
    }
}