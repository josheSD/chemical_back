
using chemical.back.Common;
using chemical.back.Domain.Entities;
using chemical.back.Interface.Persistence;
using Dapper;
using System.Data;

namespace chemical.back.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly IApplicationDbContext _connectionFactory;

        public UserRepository(IApplicationDbContext connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UserListar";

                var users = await connection.QueryAsync<User>(query, commandType: CommandType.StoredProcedure);
                return users;
            }
        }

        public async Task<bool> AddSync(User user)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UserAdd";
                var parameters = new DynamicParameters();
                parameters.Add("@useName", user.UseName);
                parameters.Add("@usePassword", user.UsePassword);
                parameters.Add("@useState", user.UseState);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(User user)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UserUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("@useId", user.UseId);
                parameters.Add("@useName", user.UseName);
                parameters.Add("@usePassword", user.UsePassword);
                parameters.Add("@useState", user.UseState);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> RemoveAsync(User user)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UserDelete";
                var parameters = new DynamicParameters();
                parameters.Add("@useId", user.UseId);
                parameters.Add("@useState", user.UseState);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
    }
}
