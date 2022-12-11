using SQLite;

namespace GuardianProject.SQL_Account
{
    
    public class Account
    {
        #region Properties

        [PrimaryKey, AutoIncrement]
        public int CountNumber { get; set; }
        public int ID { get; set; }
        public string Password { get; set; }
        
        #endregion

        #region Constructor

        #endregion

        #region Method

        #endregion
    }

}
