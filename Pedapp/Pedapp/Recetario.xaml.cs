using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Pedapp.DataModel;
using Pedapp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pedapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Recetario : ContentPage
    {

        public Recetario(ObservableCollection<Bebida> bebidas)
        {
            InitializeComponent();

            lsvReceta.ItemsSource = bebidas;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void lsvReceta_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var bebida = (Bebida)e.SelectedItem;

            Navigation.PushAsync(new BebidaPage(bebida));
        }

    }
}
