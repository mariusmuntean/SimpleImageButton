using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.UWP;

namespace SimpleImageButton.UWP
{
    [Preserve(AllMembers = true)]
    public static class Initializator
    {
        private static List<PlatformEffect> _allEffects = new List<PlatformEffect>();

        /// <summary>
        ///     This is needed to ensure macOS loads the assembly with the effects in it
        /// </summary>
        public static void Init()
        {
            _allEffects = new List<PlatformEffect>(typeof(Initializator).GetTypeInfo().Assembly.GetTypes()
                .Where(t => ReflectionExtensions.IsAssignableFrom(typeof(PlatformEffect), t))
                .Select(t => (PlatformEffect) Activator.CreateInstance(t)));
        }
    }
}