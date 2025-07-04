using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Ediramos.Extension.Dominio.Entidades;
using Ediramos.Extension.Dominio.Repositorios;
using Ediramos.Extension.Infraestructura.Persistencia;

namespace Ediramos.Extension.Infraestructura.Repositorios
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly DbConnectionFactory _connectionString;
        public ProductoRepository(DbConnectionFactory configuration)
        {
            _connectionString = configuration;
        }
        public async Task<int> CrearProductoAsync(string nombre, string codigo, int fk_clase)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", nombre);
            parameters.Add("@Codigo", codigo);
            parameters.Add("@fk_clase", fk_clase);
            await connection.ExecuteAsync("CREARPRODUCTO", parameters, commandType: System.Data.CommandType.StoredProcedure);
            return 1;
        }
        public async Task<List<Producto>> ObtenerProductoAsync()
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var productos = await connection.QueryAsync<Producto>("OBTENERPRODUCTO");
            return productos.ToList();
        }
        public async Task EliminarProductoAsync(int id)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@IdProducto", id);
            await connection.ExecuteAsync("ELIMINARPRODUCTO", parameters, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
