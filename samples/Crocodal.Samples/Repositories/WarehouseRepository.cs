using Crocodal.Samples.Dtos;
using Crocodal.Samples.Project;
using Crocodal.Samples.Project.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            IDeleteStatement batchDelete = _database.Products.Where(e => e.IsAvailable).Where(e => e.IsAvailable).Delete();
            IInsertStatement batchInsert = _database.Products.Insert(new Product(), new Product());
            IUpdateStatement batchUpdate = _database.Products.Where(e => e.IsAvailable).Update(e => new Product { IsAvailable = false });

            var (queryResult, deleteAffected, updateAffected, insertAffected) = _database.Execute(query, batchDelete, batchUpdate, batchInsert);
            (queryResult, deleteAffected, updateAffected, insertAffected) = await _database.ExecuteAsync(query, batchDelete, batchUpdate, batchInsert);

            string querySql = query.ToSqlString();
            string deleteSql = batchDelete.ToSqlString();
            string updateSql = batchUpdate.ToSqlString();
            string insertSql = batchInsert.ToSqlString();

            var product1 = await _database.Products.Where(e => e.Id == 1).ExecuteQuerySingleAsync();
            var product2 = await _database.Products.Where(e => e.Id == 2).ExecuteQuerySingleAsync();
            var updatedExplicitly = await _database.Products.ExecuteUpdateAsync(product1, product2);

            var product3 = await _database.Products.Where(e => e.Id == 3).ExecuteQuerySingleAsync();
            var product4 = await _database.Products.Where(e => e.Id == 4).ExecuteQuerySingleAsync();
            var deletedExplicitly = await _database.Products.ExecuteDeleteAsync(product3, product4);

            var copyInsert = _database.Products.Insert(_database.Products.Where(p => !p.IsAvailable && p.DateAdded < DateTime.UtcNow.AddYears(-1)).Query());
            var copiedRows = await copyInsert.ExecuteAsync();

            queryResult = _database.ExecuteSql<List<string>>(querySql, new { x = 1 });
            queryResult = await _database.ExecuteSqlAsync<List<string>>(querySql, new { x = 1 });

            StoredProcedure<List<ProductDto>> searchedProductsProcedure = _database.SearchProducts("name");
            var searchedProducts = searchedProductsProcedure.Execute();
            searchedProducts = await searchedProductsProcedure.ExecuteAsync();
            searchedProducts = _database.Execute(searchedProductsProcedure);
            searchedProducts = await _database.ExecuteAsync(searchedProductsProcedure);

            Function<decimal> priceFunction = _database.CalculatePrice(123);
            var price = priceFunction.Execute();
            price = await priceFunction.ExecuteAsync();
            price = _database.Execute(priceFunction);
            price = await _database.ExecuteAsync(priceFunction);
        }
    }
}
