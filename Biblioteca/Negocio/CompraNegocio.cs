﻿using Biblioteca.DAO;
using Biblioteca.Classes_Basicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Negocio
{
    public class CompraNegocio : InterfaceCompra
    {
        public void Delete(Compra compra)
        {
            if (compra == null)
            {
                throw new Exception("Informar os dados da compra");
            }
            if (compra.Fornecedor == null)
            {
                throw new Exception("Informar os dados do fornecedor");
            }
            if (compra.MateriaPrima == null)
            {
                throw new Exception("Informar os dados da matéria prima");
            }
            if (compra.Fornecedor.Id <= 0)
            {
                throw new Exception("O Id do fornecedor não poderá ser menor ou igual a zero");
            }
            if (compra.MateriaPrima.Id <= 0)
            {
                throw new Exception("O Id da matéria prima não poderá ser menor ou igual a zero");
            }

            CompraDados dados = new CompraDados();

            if (this.VerificarDuplicidade(compra) == false)
            {
                throw new Exception("A compra não esta cadastrado");
            }

            dados.Delete(compra);
        }
        public Boolean ValidarPreco(Compra compra)
        {
            return compra.Preco != 0;
        }

        public Boolean ValidarQuantidade(Compra compra)
        {
            return compra.Quantidade != 0;
        }

        public Boolean ValidarTamanhoPreçoMinimo(Compra compra)
        {
            return Convert.ToString(compra.Preco).Length <= 3;
        }

        public Boolean ValidarTamanhoPreçoMaximo(Compra compra)
        {
            return Convert.ToString(compra.Preco).Length <= 14;
        }



        public void Insert(Compra compra)
        {
            if (compra == null)
            {
                throw new Exception("Informar os dados da compra");
            }

            if (Convert.ToString(compra.Preco) == null)
            {
                throw new Exception("Informar o preço do produto");
            }

            if (ValidarPreco(compra))
            {
                throw new Exception("Informar o preço do produto");
            }

            if(ValidarTamanhoPreçoMaximo(compra))
            {
                throw new Exception("O preço do produto não pode ter mais de 14 caracteres");
            }
            if (ValidarTamanhoPreçoMinimo(compra))
            {
                throw new Exception("Informar a preço do produto");
            }
            if (Convert.ToString(compra.Preco).Trim().Equals("") == true)
            {
                throw new Exception("Informar o preço do produto");
            }

            if (Convert.ToString(compra.Quantidade) == null)
            {
                throw new Exception("Informar a quantiade do produto");
            }

            if (ValidarQuantidade(compra))
            {
                throw new Exception("Informar a quantiade do produto");
            }

            if (Convert.ToString(compra.Quantidade).Length > 8)
            {
                throw new Exception("a quantidade do produto não pode ter mais de 8 caracteres");
            }
                       
            if (Convert.ToString(compra.Quantidade).Trim().Equals("") == true)
            {
                throw new Exception("Informar a quantidade do produto");
            }

            CompraDados dados = new CompraDados();

            dados.Insert(compra);
        }

        public List<Compra> Select(Compra compra)
        {
            return new CompraDados().Select(compra);
        }

        public void Update(Compra compra)
        {
            CompraDados dados = new CompraDados();

            dados.Update(compra);
        }

        public bool VerificarDuplicidade(Compra compra)
        {
            return new CompraDados().VerificarDuplicidade(compra);
        }
    }



}
