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
            ListarMateriaCombo();
            ListarFornecedorCombo();
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
                Compra filtro = new Compra();
                
                int indexFornecedor = comboBoxFornecedor.SelectedIndex;
                if (indexFornecedor > 0)
                {
                    filtro.fornecedor = listaFornecedor.ElementAt(indexFornecedor);
                }

                int indexMateriaPrima = comboBoxMateriaPrima.SelectedIndex;
                if (indexMateriaPrima > 0)
                {
                    filtro.materiaPrima = listaMateriaPrima.ElementAt(indexMateriaPrima);
                }

                Service1 dados = new Service1();
                listaCompra = dados.SelectCompra(filtro).ToList();

                comboBoxMateriaPrima.Items.Clear();

                foreach (Compra c in listaCompra)
                {
                    ListViewItem linha = listViewCompra.Items.Add(c.fornecedor.razaoSocial);
                    linha.SubItems.Add(c.materiaPrima.nome);
                    linha.SubItems.Add(Convert.ToString(c.preco));
                    linha.SubItems.Add(Convert.ToString(c.quantidade));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
    }
}
