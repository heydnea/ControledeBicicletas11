using System;
using System.Collections.Generic;
using Entidade;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ControleBanco
{
    public class FabricanteDB
    {
        private DB db;

        public bool insert(Fabricante Fabricante)
        {
            try
            {
                string sql = "INSERT INTO Fabricante (DESCRICAO, cargo)" +
                         " VALUES ('" + Fabricante.Descricao + "', "+ "" + Fabricante.cargo + ")";
                using (db = new DB())
                {
                    db.ExecutaComando(sql);
                }
            }
            catch (Exception e )
            {
                return false;
            }
            return true;
        }

        public List<Fabricante> ListarFabricante()
        {
            using (db = new DB())
            {
                var sql = "SELECT id, descricao, cargo FROM Fabricante";
                var retorno = db.ExecutaComandoRetorno(sql);
                return TransformaSQLReaderEmList(retorno);
            }
        }

        private List<Fabricante> TransformaSQLReaderEmList
            (SqlDataReader retorno)
        {
            var listFabricante = new List<Fabricante>();

            while (retorno.Read())
            {
                var item = new Fabricante()
                {
                    Id = Convert.ToInt32(retorno["id"]),
                    Descricao = retorno["descricao"].ToString(),
                    cargo = Convert.ToInt32(retorno["cargo"]),
                };

                listFabricante.Add(item);
            }
            return listFabricante;
        }

    }
}
