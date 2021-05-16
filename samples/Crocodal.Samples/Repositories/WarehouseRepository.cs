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
            IQuery<string> query = _database.Products.Query().Join(e => e.Owner).Where(e => e.IsAvailable).OrderBy(e => e.Name).Skip(10).Take(20).Select(e => e.Name);
            IDelete batchDelete = _database.Products.Delete().Where(e => e.IsAvailable);
            IInsert batchInsert = _database.Products.Insert(new Product(), new Product());
            IUpdate batchUpdate = _database.Products.Update().Where(e => e.IsAvailable).Set(e => new Product { IsAvailable = false });

            IUpdate singleUpdate = _database.Products.Update().Set(e => e.NetPrice, e => e.NetPrice * 1.1m).Set(e => e.DateAdded, DateTime.UtcNow);

            var (queryResult, deleteAffected, updateAffected, insertAffected) = _database.Execute(query, batchDelete, batchUpdate, batchInsert);
            (queryResult, deleteAffected, updateAffected, insertAffected) = await _database.ExecuteAsync(query, batchDelete, batchUpdate, batchInsert);

            string querySql = query.ToSqlString();
            string deleteSql = batchDelete.ToSqlString();
            string updateSql = batchUpdate.ToSqlString();
            string insertSql = batchInsert.ToSqlString();

            var product1 = await _database.Products.Query().Where(e => e.Id == 1).Single().ExecuteAsync();
            var product2 = await _database.Products.Query().Where(e => e.Id == 2).Single().ExecuteAsync();
            var updatedExplicitly = await _database.Products.Update(product1, product2).ExecuteAsync();

            var product3 = await _database.Products.Query().Where(e => e.Id == 3).Single().ExecuteAsync();
            var product4 = await _database.Products.Query().Where(e => e.Id == 4).Single().ExecuteAsync();
            var deletedExplicitly = await _database.Products.Delete(product3, product4).ExecuteAsync();

            var copyInsert = _database.ArchivedProducts.InsertFrom(_database.Products.Query().Where(p => !p.IsAvailable && p.DateAdded < DateTime.UtcNow.AddYears(-1)).Select(e => new ArchivedProduct { /* ... */ }));
            var copiedRows = await copyInsert.ExecuteAsync();

            queryResult = _database.ExecuteSql<List<string>>(querySql, new { x = 1 });
            queryResult = await _database.ExecuteSqlAsync<List<string>>(querySql, new { x = 1 });

            IStoredProcedure<List<ProductDto>> searchedProductsProcedure = _database.SearchProducts("name");
            var searchedProducts = searchedProductsProcedure.Execute();
            searchedProducts = await searchedProductsProcedure.ExecuteAsync();
            searchedProducts = _database.Execute(searchedProductsProcedure);
            searchedProducts = await _database.ExecuteAsync(searchedProductsProcedure);

            IFunction<decimal> priceFunction = _database.CalculatePrice(123);
            var price = priceFunction.Execute();
            price = await priceFunction.ExecuteAsync();
            price = _database.Execute(priceFunction);
            price = await _database.ExecuteAsync(priceFunction);

            _database.Insert(new Product()).Execute();
            var product5 = _database.Query<Product>().Where(e => e.Id == 5).Execute();
            _database.Update(product5).Execute();
            _database.Delete(product5).Execute();

            var q1 = _database.Products.Query().Where(e => e.OwnerId == 5);
            var q2 = _database.Products.Query().Where(e => e.OwnerId == 6);
            var q3 = _database.Products.Query().Where(e => e.OwnerId == 7);

            List<Product> unionList123 = q1.Union(q2).UnionAll(q3).Execute();
            List<Product> unionList = _database.Products
                .Query().Where(e => e.OwnerId == 5)
                .UnionAll()
                .Query().Where(e => e.OwnerId == 6)
                .Execute();

            var product7 = _database.Query<Product>(options => options.AsEditable().WithComment("my query tag").WithHint("NOLOCK"))
                .Where(e => e.Id == 7).Execute();


            // WITH CTE explicit
            var cte1 = _database.Query<Product>();
            var cte2 = _database.Query(cte1).Where(e => e.IsAvailable);
            var withQuery = _database.Query(cte2).Where(e => e.NetPrice > 0);

            // Recursive CTE
            var managerQuery = _database.Query<Employee>().Where(e => e.ManagerId == null).Select(e => new EmployeeDto { Id = e.Id, Name = e.Name, ManagerId = e.ManagerId, Level = 1 });
            var employeeQuery = _database.Query<Employee>().Join(managerQuery, (l, r) => l.ManagerId == r.Id).Select((e, r) => new EmployeeDto { Id = e.Id, Name = e.Name, ManagerId = e.ManagerId, Level = r.Level + 1 });
            var hierarchyUnion = managerQuery.UnionAll(employeeQuery);

            var employeeHierarchy = _database.Query(hierarchyUnion)
                .OrderBy(e => e.Level).OrderBy(e => e.ManagerId)
                .Select(e => new EmployeeHierarchy
                {
                    Employee = e.Name,
                    Level = e.Level,
                    Manager = _database.Query<Employee>().Where(m => m.Id == e.ManagerId).Select(m => m.Name).First().Execute()
                })
                .Execute();

            // Subquery
            _database.Products.Query().Select(e => new ProductDto()).OrderBy(e => e.Price).Execute();
        }
    }
}
