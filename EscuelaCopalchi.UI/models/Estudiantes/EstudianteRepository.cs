using System;
using System;
using System.Data;
using System.Data.SqlClient;
using EscuelaCopalchi.UI.Models.Estudiantes;


namespace EscuelaCopalchi.UI.Models
{
    public class EstudianteRepository
    {
        private readonly ConexionBD db;

        public EstudianteRepository()
        {
            db = new ConexionBD();
        }

        public string Guardar(Estudiante estudiante)
        {
            string[] parametros =
            {
                "@identificacion",
                "@nombre",
                "@apellido1",
                "@apellido2",
                "@fecha_nacimiento",
                "@direccion",
                "@nombre_encargado",
                "@telefono_encargado",
                "@estado"
            };

            string[] valores =
            {
                estudiante.Identificacion,
                estudiante.Nombre,
                estudiante.Apellido1,
                estudiante.Apellido2,
                estudiante.FechaNacimiento.ToString("yyyy-MM-dd"),
                estudiante.Direccion,
                estudiante.NombreEncargado,
                estudiante.TelefonoEncargado,
                estudiante.Estado ? "1" : "0"
            };

            return db.ejecutarProcedimiento_Save(
                "SP_InsertarEstudiante",
                parametros,
                valores);
        }
    }
}