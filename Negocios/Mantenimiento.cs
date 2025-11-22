using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using Entidades;
using Datos;


namespace Negocios
{
    public class Mantenimiento
    {
        ClassDatos datos = new ClassDatos();

        public void AgregarContacto(Contacto contacto)
        {
            datos.Create(contacto);
        }
        public DataTable ObtenerContactos()
        {
            return datos.Read();
        }
        public void ActualizarContacto(Contacto contacto)
        {
            datos.Update(contacto);
        }
        public void EliminarContacto(int id)
        {
            datos.Delete(id);
        }
        public DataTable BuscarContacto(string criterio)
        {
            return datos.Search(criterio);
        }
    }
}
