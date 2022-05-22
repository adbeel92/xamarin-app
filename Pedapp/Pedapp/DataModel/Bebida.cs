using System;
namespace Pedapp.DataModel
{
    public class Bebida
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Alcohol Alcohol { get; set; }
        public Ingrediente[] Ingredientes { get; set; }
        public string how_to_prepare { get; set; }
        public string photo_url { get; set; }
        public string percetange { get; set; }
        public string FullPhotoUrl => $"https://pedapp-api.herokuapp.com{photo_url}";


    //public Bebida(int _id, string _nombre, Alcohol _alcohol, Ingrediente[] _ingredientes, string _instrucciones)
    //{
    //    this.Id = _id;
    //    this.Nombre = _nombre;
    //    this.Alcohol = _alcohol;
    //    this.Ingredientes = _ingredientes;
    //    this.Instrucciones = _instrucciones;
    //}

    //public Bebida(string _nombre, Alcohol _alcohol, Ingrediente[] _ingredientes, string _instrucciones)
    //{
    //    this.Nombre = _nombre;
    //    this.Alcohol = _alcohol;
    //    this.Ingredientes = _ingredientes;
    //    this.Instrucciones = _instrucciones;
    //}


}
}
