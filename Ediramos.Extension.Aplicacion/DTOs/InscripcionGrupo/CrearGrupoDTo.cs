using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.InscripcionGrupo
{
    public class CrearGrupoDTo
    {
        public int IdGrupo { get; set; }
        public string Titulo { get; set; }
        public int? IdAreaTrabajo { get; set; }
        public List<IntegranteDTo> Integrantes { get; set; }
        public List<string> Objetivos { get; set; }
        public string Estado { get; set; } = "Editado";

    }
}
