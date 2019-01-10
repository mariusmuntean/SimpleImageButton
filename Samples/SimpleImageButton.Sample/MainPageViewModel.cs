using System.ComponentModel;
using System.Runtime.CompilerServices;
using SimpleImageButton.Sample.Annotations;
using Xamarin.Forms;

namespace SimpleImageButton.Sample
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private int _count;
        private bool _canExecute = false;

        public MainPageViewModel()
        {
            Command = new Command(() => { Count++; }, () => _canExecute);
        }

        public Command Command { get; set; }

        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}