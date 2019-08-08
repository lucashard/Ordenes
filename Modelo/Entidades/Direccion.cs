namespace Modelo.Entidades
{
    public class Direccion
    {
        public string Calle { get; set; }
        public int? Piso { get;set; }
        public string CodigoPostal { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public int Numero { get; set; }

        public Direccion(string calle, int? piso, string codigoPostal, string localidad, string provincia,int numero)
        {
            Calle = calle;
            Piso = piso;
            CodigoPostal = codigoPostal;
            Localidad = localidad;
            Provincia = provincia;
            Numero = numero;
        }
    }
}