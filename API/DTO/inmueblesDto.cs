using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.DTO
{
    public class inmueblesDto
    {
        public inmueblesDto(int iD, string nombre, string direccion, string telefono, int capacidadAforo)
        {
            ID = iD;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            CapacidadAforo = capacidadAforo;
        }

        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int CapacidadAforo { get; set; }
    }
}