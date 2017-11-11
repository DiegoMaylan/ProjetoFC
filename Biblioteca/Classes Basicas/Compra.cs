﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Classes_Basicas
{
    [Serializable]
    public class Compra
    {
        //Declaração dos atributos
        private double preco;
        private int quantidade;
        private Fornecedor fornecedor;
        private MateriaPrima materiaPrima;

        public Compra()
        {
            Fornecedor fornecedor = new Fornecedor();
            MateriaPrima materiaPrima = new MateriaPrima();
        }

        //Métodos Gets e Sets
        [DataMember]
        public double Preco
        {
            get
            {
                return preco;
            }

            set
            {
                preco = value;
            }
        }

        [DataMember]
        public int Quantidade
        {
            get
            {
                return quantidade;
            }

            set
            {
                quantidade = value;
            }
        }

        [DataMember]
        public Fornecedor Fornecedor
        {
            get
            {
                return fornecedor;
            }

            set
            {
                fornecedor = value;
            }
        }

        [DataMember]
        public MateriaPrima MateriaPrima
        {
            get
            {
                return materiaPrima;
            }

            set
            {
                materiaPrima = value;
            }
        }

        [DataMember]
        public Fornecedor Fornecedor1
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        [DataMember]
        public MateriaPrima MateriaPrima1
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        [DataMember]
        public Fornecedor Fornecedor2
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        [DataMember]
        public MateriaPrima MateriaPrima2
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}
