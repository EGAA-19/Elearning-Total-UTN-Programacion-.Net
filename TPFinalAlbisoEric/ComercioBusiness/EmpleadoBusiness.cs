using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComercioEntities;
using ComercioDAL;

namespace ComercioBusiness
{
    public class EmpleadoBusiness
    {
        public static List<Empleado> ListarEmpleados(string NombreCompleto)
        {
            return EmpleadoDAL.ListarEmpleados(NombreCompleto);
        }

        public static Empleado ObtenerEmpleado(int Id)
        {
            return EmpleadoDAL.ObtenerEmpleado(Id);
        }

        public static Empleado AltaModEmpleado(Empleado empleado)
        {
            return EmpleadoDAL.AltaModEmpleado(empleado);
        }

        public static void EliminarEmpleado(int Id)
        {
            EmpleadoDAL.EliminarEmpleado(Id);
        }

    }
}
