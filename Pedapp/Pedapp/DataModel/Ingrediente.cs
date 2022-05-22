using System;

namespace Pedapp.DataModel
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; }
        public string _destroy { get; set; }

        //public Ingrediente(int _id, string _nombre, float _cantidad, string _unidad)
        //{
        //    this.Id = _id;
        //    this.Nombre = _nombre;
        //    this.Cantidad = _cantidad;
        //    this.Unidad = _unidad;
        //}

        //public Ingrediente(string _nombre, float _cantidad, string _unidad)
        //{
        //    this.Nombre = _nombre;
        //    this.Cantidad = _cantidad;
        //    this.Unidad = _unidad;
        //}
    }
}
