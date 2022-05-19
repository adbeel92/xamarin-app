using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pedapp.DataModel;
using Pedapp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pedapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Agregar : ContentPage {

        public string name;
        public int alcohol_type_id;
        public string how_to_prepare;

        public Agregar(ObservableCollection<Alcohol> alcohols) {
            InitializeComponent();

            pkrAlcohol.ItemsSource = alcohols;
        }

        private void btnAgregar_Clicked(object sender, EventArgs e) {

            this.name = txtNombre.Text;
            this.how_to_prepare = txtDescripcion.Text;

            BebidaService services = new BebidaService();

            bool created = services.createDrink(name, alcohol_type_id, how_to_prepare);

            if (created) {
                Navigation.PopAsync();
                //DisplayAlert("Creado!", "A", "B");
            }
        }

        private void pkrAlcohol_SelectedIndexChanged(object sender, EventArgs e) {
            Alcohol a = (Alcohol)pkrAlcohol.SelectedItem;
            this.alcohol_type_id = a.Id;
        }

        private void sldnivelAlcohol_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblSlider.Text = e.NewValue.ToString();
        }
    }
}