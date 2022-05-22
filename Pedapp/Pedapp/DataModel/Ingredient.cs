using System;

namespace Pedapp.DataModel
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public string _destroy { get; set; }

        public Ingredient() { }

        public Ingredient(int _id, string _nombre, double _cantidad, string _unidad)
        {
            this.Id = _id;
            this.Name = _nombre;
            this.Quantity = _cantidad;
            this.Unit = _unidad;
        }

        public Ingredient(string _nombre, double _cantidad, string _unidad)
        {
            this.Name = _nombre;
            this.Quantity = _cantidad;
            this.Unit = _unidad;
        }

        public static implicit operator Ingredient(Agregar v)
        {
            throw new NotImplementedException();
        }
    }
}
