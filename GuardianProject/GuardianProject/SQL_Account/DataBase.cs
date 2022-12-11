using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuardianProject.SQL_Account
{
    public class Database
    {
        #region Members

        readonly SQLiteAsyncConnection _database;

        #endregion

        #region Constructor
        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Account>().Wait();
        }
        #endregion

        #region Methods
        /// <summary>
        /// A mathod to read the full table from the Database
        /// </summary>
        /// <returns>An awaitable task containing the list of each database entry</returns>
        public Task<List<Account>> GetAccountAsync()
        {
            return _database.Table<Account>().ToListAsync();
        }
        /// <summary>
        /// A methode to read a single entry of the table from the Database
        /// </summary>
        /// <param name="accountKey"> The number of the entry to retrun</param>
        /// <returns>An awaitable task containing the entry specify</returns>
        public Task<Account> GetAccountAsync(int accountKey)
        {
            return _database.Table<Account>().ElementAtAsync(accountKey);
        }

        /// <summary>
        /// A method to store a new entry into the Database
        /// </summary>
        /// <param name="account"> The new entry as an account</param>
        /// <returns></returns>
        public Task<int> SaveAccountAsync(Account account)
        {
            return _database.InsertAsync(account);
        }

        #endregion
    }
}
