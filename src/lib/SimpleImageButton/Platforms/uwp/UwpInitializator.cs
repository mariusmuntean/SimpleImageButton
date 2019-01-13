using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.UWP;

namespace SimpleImageButton.Platforms.uwp
{
    [Preserve(AllMembers = true)]
    public static class UwpInitializator
    {
        private static List<PlatformEffect> _allEffects = new List<PlatformEffect>();

        /// <summary>
        ///     This is needed to ensure Windows loads the assembly with the effects in it
        /// </summary>
        public static void Init()
        {
            _allEffects = new List<PlatformEffect>(typeof(UwpInitializator).GetTypeInfo().Assembly.GetTypes()
                .Where(t => ReflectionExtensions.IsAssignableFrom(typeof(PlatformEffect), t))
                .Select(t => (PlatformEffect)Activator.CreateInstance(t)));
        }
    }
}