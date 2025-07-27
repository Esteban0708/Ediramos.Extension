using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Evaluador;
using Ediramos.Extension.Dominio.Entidades;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Evaluador
{
    public class AsignarEvaluadorHandler : IRequestHandler<AsignarEvaluadorCommand, bool>
    {
        private readonly IEvaluadorRespository _repository;

        public AsignarEvaluadorHandler(IEvaluadorRespository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(AsignarEvaluadorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var evaluador = new AsignarEvaluador
                {
                    IdProyecto = request.Evaluador.IdProyecto,
                    PEGE_ID = request.Evaluador.PEGE_ID,
                    Documento = request.Evaluador.Documento,
                    NombreCompleto = request.Evaluador.NombreCompleto,
                    IdTipoJurado = request.Evaluador.IdTipoJurado
                };

                var result = await _repository.AsignarEvaluadorAsync(evaluador);

                if (!result)
                {
                    Console.WriteLine("⚠️ Error: El procedimiento SQL no insertó ningún registro.");
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al asignar evaluador: {ex.Message}");
                return false;
            }
        }

    }

}
