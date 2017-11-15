﻿using Biblioteca.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Classes_Basicas;
using System.Data.SqlClient;
using System.Data;

namespace Biblioteca.DAO
{
    public class FormulaDados : GerenciadorConexaoSqlServer, InterfaceFormula
    {
        public void CadastrarFormula(Produto p)
        {
            try
            {
                foreach (MateriaPrima ma in p.MateriaPrima)
                {
                this.Conectar();
                string sql = "insert into Compoe (ID_Produto, ID_MateriaPrima) ";
                sql += " values(@IdProduto, @IdMateriaPrima)";

                SqlCommand cmd = new SqlCommand(sql, this.sqlcon);

                cmd.Parameters.Add("@IdProduto", SqlDbType.Int);
                cmd.Parameters["@IdProduto"].Value = p.Id;

                cmd.Parameters.Add("@IdMateriaPrima", SqlDbType.Int);
                cmd.Parameters["@IdMateriaPrima"].Value = ma.Id;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Desconectar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e inserir " + ex.Message);
            }
        }

        public List<MateriaPrima> SelectFormula(Produto filtro)
        {
            List<MateriaPrima> retorno = new List<MateriaPrima>();
            try
            {
                this.Conectar();
                string sql = "SELECT MateriaPrima.Id AS IdMateriaPrima, MateriaPrima.Nome AS NomeMateriaPrima FROM Compoe ";
                sql += " INNER JOIN MateriaPrima ON Compoe.Id_MateriaPrima = MateriaPrima.Id ";
                sql += " where compoe.Id_Produto = compoe.Id_Produto";

                if (filtro.Id > 0)
                {
                    sql += " and compoe.Id_Produto = @Id_Produto ";
                }

                SqlCommand cmd = new SqlCommand(sql, sqlcon);

                if (filtro.Id > 0)
                {
                    cmd.Parameters.Add("@Id_Produto", SqlDbType.Int);
                    cmd.Parameters["@Id_Produto"].Value = filtro.Id;
                }

                SqlDataReader DbReader = cmd.ExecuteReader();
                
                while (DbReader.Read())
                {
                    MateriaPrima materiaPrima = new MateriaPrima();
                    materiaPrima.Id = DbReader.GetInt32(DbReader.GetOrdinal("IdMateriaPrima"));
                    materiaPrima.Nome = DbReader.GetString(DbReader.GetOrdinal("NomeMateriaPrima"));
                    retorno.Add(materiaPrima);
                }

                DbReader.Close();
                cmd.Dispose();
                this.Desconectar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e selecionar " + ex.Message);
            }
            return retorno;
        }
    }
}
