using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using Xamarin.Forms.Platform.iOS;

namespace SimpleImageButtonLib.Platforms.ios
{
    [Preserve(AllMembers = true)]
    public static class Initializator
    {
        static List<PlatformEffect> _allEffects = new List<PlatformEffect>();

        /// <summary>
        /// This is needed to ensure iOS loads the assembly with the effects in it
        /// </summary>
        public static void Init()
        {
            _allEffects = new List<PlatformEffect>(typeof(Initializator).Assembly.GetTypes()
                .Where(t => typeof(PlatformEffect).IsAssignableFrom(t))
                .Select(t => (PlatformEffect) Activator.CreateInstance(t)));
        }
    }
}