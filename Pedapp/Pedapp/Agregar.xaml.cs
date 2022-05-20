﻿using System;
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

namespace Pedapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Agregar : ContentPage {

        public string name;
        public int alcohol_type_id;
        public string how_to_prepare;
        public string filePath;

        public Agregar(ObservableCollection<Alcohol> alcohols) {
            InitializeComponent();

            pkrAlcohol.ItemsSource = alcohols;
        }

        private void btnAgregar_Clicked(object sender, EventArgs e) {

            this.name = txtNombre.Text;
            this.how_to_prepare = txtDescripcion.Text;

            BebidaService services = new BebidaService();

            bool created = services.createDrink(name, alcohol_type_id, how_to_prepare, filePath);

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


        async Task TakePhotoAsync()
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

        async Task LoadPhotoAsync(FileResult photo)
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

        private async void btnAgregarFoto_ClickedAsync(System.Object sender, System.EventArgs e)
        {
            await TakePhotoAsync();
        }
    }
}