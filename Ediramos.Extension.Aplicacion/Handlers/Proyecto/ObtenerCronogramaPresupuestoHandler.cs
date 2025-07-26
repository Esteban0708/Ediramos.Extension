using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Cronograma_Proyecto;
using Ediramos.Extension.Aplicacion.DTOs.Proyecto;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Entidades;
using MediatR;
using FuenteFinanciacionDTo = Ediramos.Extension.Aplicacion.DTOs.Cronograma_Proyecto.FuenteFinanciacionDTo;
using DTOsCrono = Ediramos.Extension.Aplicacion.DTOs.Cronograma_Proyecto;

namespace Ediramos.Extension.Aplicacion.Handlers.Proyecto
{
    public class ObtenerCronogramaPresupuestoHandler
        : IRequestHandler<CronogramaPresupuestoQuery, CronogramaPresupuestoDTo>
    {
        private readonly IProyectoRepository _repository;

        public ObtenerCronogramaPresupuestoHandler(IProyectoRepository repository)
        {
            _repository = repository;
        }

        public async Task<CronogramaPresupuestoDTo> Handle(CronogramaPresupuestoQuery request, CancellationToken cancellationToken)
        {
            var entidad = await _repository.ObtenerCronogramaPresupuestoAsync(request.IdProyecto);

            return new CronogramaPresupuestoDTo
            {
                Cronograma = entidad.Cronograma.Select(c => new CronogramaDTo
                {
                    IdMeta = c.IdMeta,
                    MetaDescripcion = c.MetaDescripcion,
                    FK_IdObjetivo = c.FK_IdObjetivo,
                    IdActividad = c.IdActividad,
                    ActividadDescripcion = c.ActividadDescripcion,
                    FK_IdMeta = c.FK_IdMeta,
                    IdPeriodo = c.IdPeriodo,
                    NombreSemana = c.NombreSemana
                }).ToList(),

                PresupuestoProductos = entidad.PresupuestoProductos.Select(p => new PresupuestoProductoDTo
                {
                    IdPresupuesto = p.IdPresupuesto,
                    IdProducto = p.IdProducto,
                    Codigo = p.Codigo,
                    Nombre = p.Nombre,
                    Total = p.Total,
                    Cantidad = p.Cantidad,
                    NombreUnidad = p.NombreUnidad,
                    DescripcionUnidad = p.DescripcionUnidad,
                    ValorUnitario = p.ValorUnitario
                }).ToList(),

                FuentesFinanciacion = entidad.FuentesFinanciacion.Select(f => new FuenteFinanciacionDTo
                {
                    IdFuenteFinanciacion = f.IdFuenteFinanciacion,
                    Entidad = f.Entidad,
                    Valor = f.Valor
                }).ToList()
            };
        }

    }

}
