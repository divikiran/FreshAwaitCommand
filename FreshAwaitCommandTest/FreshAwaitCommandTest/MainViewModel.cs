using System;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using Xamarin.Forms;
using System.ComponentModel;

namespace FreshAwaitCommandTest
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class MainViewModel : FreshBasePageModel
    {
        //Commands
        public ICommand StepCommand { get; set; }
        public FreshAwaitCommand StepFreshCommand { get; set; }


        public string NumberText { get; set; }
        private int _incrementor = 0;
        public string Title { get; set; }


        public MainViewModel()
        {
            Title = "FreshAwaitCommand";
            NumberText = "0";
            StepCommand = new Command(async (obj) =>
            {
                await IncrementNumber();
            });

            StepFreshCommand = new FreshAwaitCommand(async (obj) =>
            {
                await IncrementNumber();
                obj.SetResult(true);
            });
        }

        private async Task IncrementNumber()
        {
            await Task.Delay(3000);
            NumberText = _incrementor++.ToString();
        }
    }
}
