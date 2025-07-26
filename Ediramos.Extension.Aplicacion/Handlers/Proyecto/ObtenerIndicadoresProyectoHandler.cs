using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Indicadores_Proyecto;
using Ediramos.Extension.Aplicacion.Queries;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Proyecto
{
public class ObtenerIndicadoresProyectoHandler : IRequestHandler<ObtenerIndicadoresProyectoQuery, IndicadoresProyectoDTo>
{
            private readonly IProyectoRepository _repo;

            public ObtenerIndicadoresProyectoHandler(IProyectoRepository repo)
            {
                _repo = repo;
            }

            public async Task<IndicadoresProyectoDTo> Handle(ObtenerIndicadoresProyectoQuery request, CancellationToken cancellationToken)
            {
                var resultado = await _repo.ObtenerIndicadoresAsync(request.IdProyecto);

                return new IndicadoresProyectoDTo
                {
                    ObjetivosEspecificos = resultado.ObjetivosEspecificos.Select(o => new ObjetivoEspecificoDTo
                    {
                        IdObjetivoEspecifico = o.IdObjetivoEspecifico,
                        Descripcion = o.Descripcion,
                        Estado = o.Estado,
                        FK_IdProyecto = o.FK_IdProyecto
                    }).ToList(),

                    AreasTrabajo = resultado.AreasTrabajo.Select(a => new AreaTrabajoDTo
                    {
                        IdAreaTrabajo = a.IdAreaTrabajo,
                        Descripcion = a.Nombre,
                        Estado = a.Estado
                    }).ToList(),

                    CiclosVida = resultado.CiclosVida.Select(c => new CicloVitalDTo
                    {
                        IdCicloVital = c.IdCicloVida,
                        Descripcion = c.Nombre,
                        Estado = c.Estado
                    }).ToList(),

                    PoblacionesCondicion = resultado.PoblacionesCondicion.Select(p => new PoblacionCondicionDTo
                    {
                        IdPoblacion = p.IdPoblacion,
                        Descripcion = p.Nombre,
                        Estado = p.Estado
                    }).ToList(),

                    GruposProyecto = resultado.GruposProyecto.Select(g => new GrupoProyectoDTo
                    {
                        IdGrupo = g.IdGrupo,
                        Descripcion = g.Descripcion,
                        Estado = g.Estado
                    }).ToList()
                };
            }
        }
    }

