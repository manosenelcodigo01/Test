using System;

namespace Demo.domain.Entities
{
    public class Alumno
    {
        public int IdAlumno               { get; set; }
        public string Nombre              { get; set; }
        public string Apellido            { get; set; }
        public string Dni                 { get; set; }
        public int Edad                   { get; set; }
        public DateTime FechaRegistro     { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int IdCurso                { get; set; }
        public string NombreCurso         { get; set; }
        public decimal Promedio           { get; set; }
    }
}
