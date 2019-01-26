using System;
using SimpleImageButton.Sample;
using SimpleImageButton.SimpleImageButton.Initializator;

namespace de.marius.SimpleImageButton.Tizen
{
    class Program : global::Xamarin.Forms.Platform.Tizen.FormsApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();

            Console.WriteLine("About to initialize SimpleImageButton");
            Initializator.Init();

            LoadApplication(new App());
        }

        static void Main(string[] args)
        {
            var app = new Program();
            global::Xamarin.Forms.Platform.Tizen.Forms.Init(app);
            app.Run(args);
        }
    }
}
