using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using HelloMvb.ModelBinders;
using Mvb.Platform.Droid;

namespace HellpMvb.App.Droid
{
    [Activity(Label = "HellpMvb.App.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private HelloWorldModelBinder _binder;
        private EditText _inputText;
        private TextView _outPutText;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            MvbPlatform.Init();

            this._binder = new HelloWorldModelBinder();

            this.SetContentView(Resource.Layout.Main);

            Button button = this.FindViewById<Button>(Resource.Id.MyButton);
            this._inputText = this.FindViewById<EditText>(Resource.Id.InputText);
            this._outPutText = this.FindViewById<TextView>(Resource.Id.OutPutText);

            button.Click += delegate { this._binder.SayHelloto(this._inputText.Text); };

            this.InitBinderActions();
        }

        private void InitBinderActions()
        {
            this._binder.Binder.AddAction<HelloWorldModelBinder>(b => b.OutPut, () =>
            {
                this._outPutText.Text = this._binder.OutPut;
            });

            this._binder.SayHelloDone.AddAction(() =>
            {
                Toast.MakeText(this.ApplicationContext, "The SayHello method is done!", ToastLength.Long).Show();
            });

            this._binder.OnValidationError.AddAction(exception =>
            {
                this._outPutText.Text = exception.Message;
            });
        }
    }
}

