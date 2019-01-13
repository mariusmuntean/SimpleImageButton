// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409


namespace SimpleImageButton.Sample.UWP
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class MainPage
    {
        public MainPage()
        {
            //this.InitializeComponent();

            // Make this call to load the effect
            SimpleImageButtonLib.Initializator.Initializator.Init();

            this.InitializeComponent();
            this.LoadApplication(new SimpleImageButton.Sample.App());
        }
    }
}