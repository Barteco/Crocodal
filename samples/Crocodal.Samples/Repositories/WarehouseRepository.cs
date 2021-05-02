using Crocodal.Samples.Project;
using Crocodal.Samples.Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crocodal.Samples.Dtos;

namespace Crocodal.Samples.Repositories
{
    class WarehouseRepository
    {
        private readonly WarehouseDatabase _database;

        public WarehouseRepository(WarehouseDatabase database)
        {
            _database = database;
        }

        public async Task Query()
        {
            IQueryStatement<List<string>> query = _database.Products.Join(e => e.Owner).Where(e => e.IsAvailable).OrderBy(e => e.Name).Skip(10).Take(20).Select(e => e.Name).Query();
            IDeleteStatement delete = _database.Products.Where(e => e.IsAvailable).Where(e => e.IsAvailable).Delete();
            IInsertStatement insert = _database.Products.Insert(new Product(), new Product());
            IUpdateStatement update = _database.Products.Where(e => e.IsAvailable).Update(e => new Product { IsAvailable = false });

            List<ProductDto> searchedProducts = await _database.SearchProducts("name").ExecuteAsync();

            var (queryResult, deleteAffected, updateAffected, insertAffected) = _database.Execute(query, delete, update, insert);

            (queryResult, deleteAffected, updateAffected, insertAffected) = await _database.ExecuteAsync(query, delete, update, insert);

            string querySql = query.ToSqlString();
            string deleteSql = delete.ToSqlString();
            string updateSql = update.ToSqlString();
            string insertSql = insert.ToSqlString();

            queryResult = _database.ExecuteSql<List<string>>(querySql, new { x = 1 });
            queryResult = await _database.ExecuteSqlAsync<List<string>>(querySql, new { x = 1 });
        }
    }
}
