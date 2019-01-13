namespace SimpleImageButton.SimpleImageButton.Initializator
{
    public static partial class Initializator
    {
        public static void Init()
        {
#if NETSTANDARD2_0 || NETSTANDARD
            // ReSharper disable once RedundantNameQualifier
            System.Console.WriteLine($"{nameof(SimpleImageButton)}- No need to call init");
#endif

#if __ANDROID__
            Platforms.android.AndroidInitializator.Init();
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