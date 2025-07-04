using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Dominio.Repositorios
{
    public interface IConvocatoriaRepository
    {
        Task<int> CrearConvocatoriaAsync(
            string titulo,
            string descripcion,
            string resolucion,
            string nResolucion,
            int? idModalidad,
            DateTime fechaInicio,
            DateTime fechaFin,
            int duracion,
            string objetivos,
            string lineas
        );
        Task<List<Convocatoria>> ObtenerConvocatoriasBasicasAsync();


    }


}
