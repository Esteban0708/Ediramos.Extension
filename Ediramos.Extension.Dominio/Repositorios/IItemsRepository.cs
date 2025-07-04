using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Dominio.Repositorios
{
    public interface IItemsRepository
    {

        Task<List<ItemEstandar>> ObtenerItemsEstandarAsync();

        Task AsignarItemConvocatoriaAsync(
               string titulo,
               string pregunta,
               bool esEstandar,
               bool estado,
               int idConvocatoria,
               float puntajeMax,
               float puntajeMin
           );
    }
}
