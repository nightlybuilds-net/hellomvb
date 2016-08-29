using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HelloMvb.ModelBinders;

namespace HelloMvb.App.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HelloWorldModelBinder _binder;

        public MainWindow()
        {
            this.InitializeComponent();
            this._binder = new HelloWorldModelBinder();
            this.InitBinderActions();
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            this._binder.SayHelloto(this.TextBox.Text);
        }

        private void InitBinderActions()
        {
            this._binder.Binder.AddAction<HelloWorldModelBinder>(b=> b.OutPut, () =>
            {
                this.OutPut.Text = this._binder.OutPut;
            });

            this._binder.SayHelloDone.AddAction(() =>
            {
                MessageBox.Show("The SayHello method is done!");
            });

            this._binder.OnValidationError.AddAction(exception =>
            {
                this.OutPut.Text = exception.Message;
            });
        }
    }
}
