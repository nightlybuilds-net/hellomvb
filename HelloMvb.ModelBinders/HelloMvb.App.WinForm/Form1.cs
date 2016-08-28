using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HelloMvb.ModelBinders;
using Mvb.Platform.Win.WinForms;

namespace HelloMvb.App.WinForm
{
    public partial class Form1 : Form
    {
        private HelloWorldModelBinder _binder;

        public Form1()
        {
            this.InitializeComponent();
            this._binder = new HelloWorldModelBinder();
            this.InitBindersActions();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            this._binder.SayHelloto(this.TextBox.Text);
        }

        private void InitBindersActions()
        {
            this._binder.Binder.AddAction<HelloWorldModelBinder>(b=>b.OutPut, () =>
            {
                this.OutPut.MvbInvoke(box =>
                {
                    box.Text = this._binder.OutPut;
                });
            });
        }
    }
}
