using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDAService.DAL
{
    // Cách gọi
    //SQLHelper.ConnectString(new SMTConfig());
    public abstract class ConfigDatabase
    {
        public string SERVER_NAME = "";
        public string USERNAME_DB = "";
        public string PASSWORD_DB = "";
        public string DATABASE = "";
        public int TIME_OUT = 3;
        public abstract string ConnectString();
    }



    public class PdaConfig : ConfigDatabase
    {
        public override string ConnectString()
        {
            SERVER_NAME = @"172.28.10.28";
            USERNAME_DB = "sa";
            PASSWORD_DB = "umc@123";
            DATABASE = "Android_CheckPartExist";
            return string.Format("Server={0};Database={1};User Id={2};Password = {3}; ;Connection Timeout={4}", SERVER_NAME, DATABASE, USERNAME_DB, PASSWORD_DB, TIME_OUT);
        }
    }
}
