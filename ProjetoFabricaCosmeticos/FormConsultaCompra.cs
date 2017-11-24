﻿using ProjetoFabricaCosmeticos.localhost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFabricaCosmeticos
{
    public partial class FormConsultaCompra : Form
    {
        List<Fornecedor> listaFornecedor = new List<Fornecedor>();
        List<MateriaPrima> listaMateriaPrima = new List<MateriaPrima>();
        List<Compra> listaCompra = new List<Compra>();

        public FormConsultaCompra()
        {
            InitializeComponent();
            ListarFornecedorCombo();
            ListarMateriaCombo();
        }
        private void ListarFornecedorCombo()
        {
            try
            {
                Service1 dados = new Service1();
                Fornecedor filtro = new Fornecedor();
                listaFornecedor = dados.SelectFornecedor(filtro).ToList();
                comboBoxFornecedor.Items.Clear();
                foreach (Fornecedor f in listaFornecedor)
                {
                    comboBoxFornecedor.Items.Add(f.razaoSocial);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListarMateriaCombo()
        {
            try
            {
                Service1 dados = new Service1();
                MateriaPrima filtro = new MateriaPrima();
                listaMateriaPrima = dados.SelectMateriaPrima(filtro).ToList();
                comboBoxMateriaPrima.Items.Clear();
                foreach (MateriaPrima m in listaMateriaPrima)
                {
                    comboBoxMateriaPrima.Items.Add(m.nome);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {

        }

        private void buttonConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                Service1 dados = new Service1();
                Compra filtro = new Compra();
                if (comboBoxMateriaPrima.Text.Trim().Equals("") == false)
                {
                    filtro.materiaPrima.nome = comboBoxMateriaPrima.Text;
                }
                else
                {
                    if (comboBoxFornecedor.Text.Trim().Equals("") == false)
                    {
                        filtro.fornecedor.razaoSocial = comboBoxFornecedor.Text;
                    }

                }
                listaCompra = dados.SelectCompra(filtro).ToList();
                comboBoxMateriaPrima.Items.Clear();
                foreach (Compra c in listaCompra)
                {
                    ListViewItem linha = listViewCompra.Items.Add(c.fornecedor.razaoSocial);
                    listViewCompra.Items.Add(c.materiaPrima.nome);
                    listViewCompra.Items.Add(Convert.ToString(c.preco));
                    listViewCompra.Items.Add(Convert.ToString(c.quantidade));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}