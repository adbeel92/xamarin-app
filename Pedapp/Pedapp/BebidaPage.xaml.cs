using System;
using System.Collections.Generic;
using Pedapp.DataModel;
using Xamarin.Forms;

namespace Pedapp
{
    public partial class BebidaPage : ContentPage
    {
        public BebidaPage(Bebida _bebida)
        {
            InitializeComponent();

            this.BindingContext = _bebida;
        }
    }
}
