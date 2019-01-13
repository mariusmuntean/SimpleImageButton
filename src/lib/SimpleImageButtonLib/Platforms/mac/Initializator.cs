using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using Xamarin.Forms.Platform.MacOS;

namespace SimpleImageButtonLib.Platforms.mac
{
    [Preserve(AllMembers = true)]
    public static class Initializator
    {
        private static List<PlatformEffect> _allEffects = new List<PlatformEffect>();

        /// <summary>
        /// This is needed to ensure macOS loads the assembly with the effects in it
        /// </summary>
        public static void Init()
        {
            _allEffects = new List<PlatformEffect>(typeof(Initializator).Assembly.GetTypes()
                .Where(t => typeof(PlatformEffect).IsAssignableFrom(t))
                .Select(t => (PlatformEffect) Activator.CreateInstance(t)));
        }
    }
}