using SimpleImageButton;
using System;

#if TIZEN || TIZEN50 || TIZEN40
using Tizen;
#endif

namespace SimpleImageButton.SimpleImageButton.Initializator
{
    public static class Initializator
    {
        public static void Init()
        {
            Console.WriteLine("Initializing SimpleImageButton Platform Effects");
#if NETSTANDARD2_0 || NETSTANDARD
            // ReSharper disable once RedundantNameQualifier
            Console.WriteLine($"{nameof(SimpleImageButton)}- No need to call init");
#endif

#if __ANDROID__
            Platforms.android.AndroidInitializator.Init();
#endif

#if TIZEN || TIZEN50 || TIZEN40
            Console.WriteLine("Initializing TIZEn Platform Effect");
            Log.Info("MM", "Initializing TIZEn Platform Effect");
            Platforms.tizen.TizenInitializator.Init();
#endif

#if UAP10_0_16299 || UAP10_0_16299_0 || WINDOWS_UWP
            Platforms.uwp.UwpInitializator.Init();
#endif

#if __IOS__
            Platforms.ios.iOSInitializator.Init();
#endif

#if __MACOS__
            Platforms.mac.MacInitializator.Init();
#endif
        }
    }
}