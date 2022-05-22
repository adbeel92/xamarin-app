using System;
namespace Pedapp.DataModel
{
    public class Bebida
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AlcoholType alcohol_type { get; set; }
        public Ingredient[] Ingredients { get; set; }
        public string how_to_prepare { get; set; }
        public string photo_url { get; set; }
        public string FullPhotoUrl => $"https://pedapp-api.herokuapp.com{photo_url}";
        public double percentage { get; set; }


        //public Bebida(int _id, string _nombre, AlcoholType _alcohol, Ingredient[] _ingredients, string _instrucciones)
        //{
        //    this.Id = _id;
        //    this.Nombre = _nombre;
        //    this.Alcohol = _alcohol;
        //    this.Ingredients = _ingredients;
        //    this.Instrucciones = _instrucciones;
        //}

        //public Bebida(string _nombre, AlcoholType _alcohol, Ingredient[] _ingredients, string _instrucciones)
        //{
        //    this.Nombre = _nombre;
        //    this.Alcohol = _alcohol;
        //    this.Ingredients = _ingredients;
        //    this.Instrucciones = _instrucciones;
        //}


    }
}
