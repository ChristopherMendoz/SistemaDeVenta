using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viernes17022023
{
    internal class Metodos
    {
        int Codigo;
        string cliente;
        string Producto;
        double  pago, total,precio,cantiDispo;

        public Metodos()
        {
        }

        public Metodos(string cliente,string producto)
        {
            this.Cliente = cliente;
            Producto1 = producto;

        }

        public Metodos(double pago, double total, double precio, double cantiDispo)
        {
            this.pago = pago;
            this.total = total;
            this.Precio1 = precio;
            this.CantiDispo = cantiDispo;
        }

        public Metodos(int codigo)
        {
            Codigo1 = codigo;
            
          
        }

        public int Codigo1 { get => Codigo; set => Codigo = value; }
        public double CantiDispo { get => cantiDispo; set => cantiDispo = value; }
        public string Producto1 { get => Producto; set => Producto = value; }
        public string Cliente { get => cliente; set => cliente = value; }
        public double Pago { get => pago; set => pago = value; }
        public double Total { get => total; set => total = value; }
        public double Precio1 { get => precio; set => precio = value; }

        public double TotalPrecio(double precio, double cantDispo)
        {
      
            return precio * cantDispo;
        }
        public double Paago(double pago)
        {
            return pago;
        }
        public double Cambio(double total, double pago)
        {
            return pago - total;
        }
        public double CantidadNueva(double CantidadAnti, double CantidadNuev)
        {
            return CantidadAnti - CantidadNuev;
        }




    }

}
