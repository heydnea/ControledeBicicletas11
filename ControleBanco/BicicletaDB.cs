using Entidade;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBanco
{
    public class BicicletaDB
    {

        private DB db;

        public bool insert(Bicicleta bicicleta)
        {
            try
            {
                string sql = "INSERT INTO Bicicleta (modelo, fabricante, dtFabricacao)" +
                         " VALUES ('" + bicicleta.Modelo + "', " + "" + bicicleta.fabricante + "" + ", " + "'" + bicicleta.dtFabricacao + "'" + " )";
                using (db = new DB())
                {
                    db.ExecutaComando(sql);
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public List<Bicicleta> ListarBicicleta()
        {
            using (db = new DB())
            {
                var sql = "SELECT id, modelo, fabricante , dtFabricacao FROM Bicicleta";
                var retorno = db.ExecutaComandoRetorno(sql);
                return TransformaSQLReaderEmList(retorno);
            }
        }

        private List<Bicicleta> TransformaSQLReaderEmList
            (SqlDataReader retorno)
        {
            var listFabricante = new List<Bicicleta>();

            while (retorno.Read())
            {
                var item = new Bicicleta()
                {
                    Id = Convert.ToInt32(retorno["id"]),
                    Modelo = retorno["modelo"].ToString(),
                    fabricante= Convert.ToInt32(retorno["fabricante"]),
                    dtFabricacao = Convert.ToDateTime(retorno["dtFabricacao"]),
                };

                listFabricante.Add(item);
            }
            return listFabricante;
        }
    }
}
