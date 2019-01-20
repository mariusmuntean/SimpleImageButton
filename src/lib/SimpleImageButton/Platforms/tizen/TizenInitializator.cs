using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.Tizen;

namespace SimpleImageButton.Platforms.tizen
{
    [Preserve(AllMembers = true)]
    public static class TizenInitializator
    {
        private static List<PlatformEffect> _allEffects = new List<PlatformEffect>();

        /// <summary>
        ///     This is needed to ensure Windows loads the assembly with the effects in it
        /// </summary>
        public static void Init()
        {
            _allEffects = new List<PlatformEffect>(typeof(TizenInitializator).GetTypeInfo().Assembly.GetTypes()
                .Where(t => ReflectionExtensions.IsAssignableFrom(typeof(PlatformEffect), t))
                .Select(t => (PlatformEffect)Activator.CreateInstance(t)));
        }
    }
}