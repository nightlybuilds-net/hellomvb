using System;
using System.Threading.Tasks;
using Mvb.Core.Base;
using Mvb.Core.Components.BinderActions;

namespace HelloMvb.ModelBinders
{
    public class HelloWorldModelBinder : MvbBase
    {
        public MvbActions SayHelloDone;
        public MvbActions<Exception> OnValidationError;

        public HelloWorldModelBinder()
        {
            this.SayHelloDone = new MvbActions();
            this.OnValidationError = new MvbActions<Exception>();
            this.InitBinder();
        }

        private string _outPut;

        public string OutPut
        {
            get { return this._outPut; }
            set { this.SetProperty(ref this._outPut, value); }
        }

        public void SayHelloto(string name)
        {
            Task.Run(() => { this.HelloWorker(name).ConfigureAwait(false); }).ConfigureAwait(false); 
        }

        private async Task HelloWorker(string name)
        {
            //Validation
            if (string.IsNullOrEmpty(name))
            {
                this.OnValidationError.Invoke(new Exception("Name cannot be null or empty!"));
                return;
            }

            this.OutPut = "MVB wants to greet..";
            await Task.Delay(1000);
            this.OutPut = $"{name.ToUpper()}!!";
            await Task.Delay(1000);
            this.OutPut = "See you soon!";
            this.SayHelloDone.Invoke();
        }
    }
}
