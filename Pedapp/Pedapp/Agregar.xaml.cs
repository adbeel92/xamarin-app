using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pedapp.DataModel;
using Pedapp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;

namespace Pedapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Agregar : ContentPage {

        public string name;
        public int alcohol_type_id = 0;
        public string how_to_prepare;
        public double percentage;
        public List<Ingredient> ingredients = new List<Ingredient>() { };
        public string filePath = "";
        public int newIngredientId = 0;
        
        ObservableCollection<Ingredient> ingredientsList;

        public Agregar(ObservableCollection<AlcoholType> alcohols) {
            InitializeComponent();

            pkrAlcohol.ItemsSource = alcohols;

            refreshIngredientsCollection();

            MessagingCenter.Subscribe<IngredientsPopUpPage, Ingredient>(this, "IngredientPopUpData", (sender, ingredient) =>
            {
                newIngredientId = newIngredientId + 1;
                this.ingredients.Add(ingredient);

                refreshIngredientsCollection();
            }
            );
        }

        private async void btnAgregar_ClickedAsync(object sender, EventArgs e) {
            this.name = txtNombre.Text;
            this.how_to_prepare = txtDescripcion.Text;

            BebidaService services = new BebidaService();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(how_to_prepare) || alcohol_type_id <= 0 || string.IsNullOrEmpty(filePath))
            {
                DependencyService.Get<IMessage>().LongAlert("Debe llenar todos los campos");
            } else {
                bool created = await services.createDrink(name, alcohol_type_id, how_to_prepare, filePath, percentage, ingredients);

                if (created)
                {
                    DependencyService.Get<IMessage>().LongAlert("Bebida creada!");
                    _ = Navigation.PopAsync();
                }
                else
                {
                    DependencyService.Get<IMessage>().LongAlert("Hubo un error al agregar la bebida");
                }
            }
        }

        private void pkrAlcohol_SelectedIndexChanged(object sender, EventArgs e) {
            AlcoholType a = (AlcoholType)pkrAlcohol.SelectedItem;
            this.alcohol_type_id = a.Id;
        }

        private void sldnivelAlcohol_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            this.percentage = e.NewValue;
            lblSlider.Text = e.NewValue.ToString();
        }

        private async Task TakePhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                await LoadPhotoAsync(photo);
                Console.WriteLine($"CapturePhotoAsync COMPLETED: {this.filePath}");
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature is not supported on the device
            }
            catch (PermissionException pEx)
            {
                // Permissions not granted
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }

        private async Task LoadPhotoAsync(FileResult photo)
        {
            // canceled
            if (photo == null)
            {
                this.filePath = null;
                return;
            }

            // save the file into local storage
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);

            this.filePath = newFile;

            imgDrink.Source = ImageSource.FromFile(newFile);
            imgDrink.Opacity = 1;
        }

        private async void btnAgregarFoto_ClickedAsync(Object sender, EventArgs e)
        {
            await TakePhotoAsync();
        }

        private void RemoveIngredientButton_OnClicked(object sender, EventArgs args)
        {
            var button = (Button)sender;
            var ingId = Convert.ToInt16(button.ClassId);

            var item = this.ingredients.SingleOrDefault(x => x.Id == ingId);

            if (item != null)
            {
                this.ingredients.Remove(item);
                refreshIngredientsCollection();
            }
        }

        private async void openIngredientsPopUp(object sender, EventArgs args)
        {
            IngredientsPopUpPage page = new IngredientsPopUpPage(newIngredientId);

            await PopupNavigation.Instance.PushAsync(page);
        }

        private void refreshIngredientsCollection()
        {
            ingredientsList = new ObservableCollection<Ingredient>(ingredients);
            lsvIngredients.ItemsSource = ingredientsList;
            lsvIngredients.HeightRequest = 50 * ingredientsList.Count;
        }
    }
}
