using System.Threading.Tasks;
using Mvb.Core.Base;

namespace HelloMvb.ModelBinders
{
    public class HelloWorldModelBinder : MvbBase
    {
        public HelloWorldModelBinder()
        {
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
            this.OutPut = "MVB wants to greet..";
            await Task.Delay(1000);
            this.OutPut = $"{name.ToUpper()}!!";
            await Task.Delay(1000);
            this.OutPut = "See you soon!";
        }
    }
}
