using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading.Tasks;

namespace Profile.Data
{
    public class DataAccess
    {
        private string connectionString = string.Empty;
        public DataAccess()
        {
            connectionString = @"Data Source=LAGASH\SQLEXPRESS;Initial Catalog=profile;Integrated Security=True";
        }
        public async Task<IEnumerable<TEntity>> Get<TEntity>(string name)
        {
            var result = new List<TEntity>();
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(name, connection);

                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var item = Activator.CreateInstance<TEntity>();
                        foreach (var prop in item.GetType().GetTypeInfo().DeclaredProperties)
                        {
                            prop.SetValue(item, reader[prop.Name]);
                        }

                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public void Insert(string name, object parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(name, connection);

                var props = parameters.GetType().GetTypeInfo().DeclaredProperties;
                foreach (var item in props)
                {
                    var value = item.GetValue(parameters);
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = item.Name,
                        SqlValue = value
                    });
                }

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
