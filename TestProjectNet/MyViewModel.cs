using System.ComponentModel;
using System.Runtime.CompilerServices;
using TestProjectNet.Annotations;

namespace TestProjectNet
{
    public class MyViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Message
        {
            get;
            set;
        }
    }
}