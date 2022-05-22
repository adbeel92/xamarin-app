using System;
using System.Collections.Generic;
using Pedapp.DataModel;

using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System.Threading.Tasks;

namespace Pedapp
{
    public partial class IngredientsPopUpPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        private TaskCompletionSource<bool> taskCompletionSource;
        private int ingredientId;
        public Task<bool> PopupClosedTask { get { return taskCompletionSource.Task; } }

        public IngredientsPopUpPage(int _ingredientId)
        {
            this.ingredientId = _ingredientId;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            taskCompletionSource = new TaskCompletionSource<bool>();
        }

        private async void btnAgregarIngrediente_Clicked(object sender, EventArgs e)
        {
            string name = txtIngredientName.Text;
            double quantity = Convert.ToDouble(txtIngredientQty.Text);
            string units = txtIngredientUnit.Text;

            if (string.IsNullOrEmpty(name) || quantity <= 0)
            {
                DependencyService.Get<IMessage>().LongAlert("Se necesita Ingrediente y Cantidad");
            } else
            {
                Ingredient ing = new Ingredient(ingredientId, name, quantity, units);

                MessagingCenter.Send<IngredientsPopUpPage, Ingredient>(this, "IngredientPopUpData", ing);

                taskCompletionSource.SetResult(true);
                await Navigation.RemovePopupPageAsync(this);
            }
                
        }
    }
}
