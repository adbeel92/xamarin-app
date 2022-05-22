using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Pedapp.DataModel;
using Pedapp.Services;
using Xamarin.Forms;

namespace Pedapp {
    public partial class MainPage : ContentPage {

        public MainPage() {
            InitializeComponent();
        }

        private async void btnBuscar_Clicked(object sender, EventArgs e) {

            BebidaService services = new BebidaService();
            List<Bebida> bebidas = await services.retrieveBebidas();

            ObservableCollection<Bebida> _bebidas = new ObservableCollection<Bebida>(bebidas);

            await Navigation.PushAsync(new Recetario(_bebidas));
        }

        private async void btnAgregar_Clicked(object sender, EventArgs e) {

            AlcoholService services = new AlcoholService();
            List<AlcoholType> alcohols = await services.retrieveAlcohols();

            ObservableCollection<AlcoholType> _alcohols = new ObservableCollection<AlcoholType>(alcohols);

            await Navigation.PushAsync(new Agregar(_alcohols));
        }
    }
}
