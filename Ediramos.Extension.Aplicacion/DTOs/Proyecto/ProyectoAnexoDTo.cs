using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Ediramos.Extension.Aplicacion.DTOs.Proyecto
{
    public class ProyectoAnexoDTo
    {
        public string IdProyecto { get; set; } 
        public string Referencias { get; set; }
        public List<IFormFile> Archivos { get; set; } 
        public string AnexosTexto { get; set; }
    }
}
