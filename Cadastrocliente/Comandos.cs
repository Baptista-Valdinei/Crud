using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastrocliente
{
    public static class Comandos
    {
        public static string Insert(string Nome, string sobrenome, string cidade, string estado)
        {
            return "INSERT INTO dbo.Clientes(Name, LastName, City, Estado) values('" + Nome + "', '" + sobrenome + "', '" + cidade + "', '" + estado + "')";
        }
        public static string Select()
        {
            return "Select * from Clientes";
        }

        public static string Delete(int id)
        {
            return "Delete from Clientes where id="+id;
        }

        public static string getbyId(int id)
        {
            return "Select from Clientes where id ="+id;
        }

        public static string Update(Cliente cli)
        {
            string sql = "update clientes set name = '" + cli.name + "' , lastname = '" + cli.lastname + "', city = '" + cli.city + "', estado = '" + cli.estado + "' where id =" + cli.id;
            return sql;
        }
    }
}
