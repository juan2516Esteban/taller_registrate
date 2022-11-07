using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using taller_registrate.Model;
using taller_registrate.ViewModel;

namespace taller_registrate.DataBase
{
    public class DataBaseQuery
    {
        readonly SQLiteAsyncConnection _database;

        public DataBaseQuery(string dbPaht)
        {
            _database = new SQLiteAsyncConnection(dbPaht);
            _database.CreateTableAsync <UserModel>().Wait();
        }

        #region CRUD
        public Task<int> SaveUserModelAsync(UserModel user)
        {
            return _database.InsertAsync(user);
        }

        public Task<int> DeleteUserModelAsync(UserModel user)
        {
            return _database.DeleteAsync(user);
        }


        public Task<List<UserModel>> GetUserModel()
        {
            return _database.Table<UserModel>().ToListAsync();
        }

        public Task<List<UserModel>> QueryUserModel(string query)
        {
            return _database.QueryAsync<UserModel>(query);
        }

        #endregion
    }
}
