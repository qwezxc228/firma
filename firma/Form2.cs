using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firma
{
    public partial class Form2 : Form
    {
        private Product productToEdit;
        public Form2(Product product = null)
        {
            InitializeComponent();
            if (product != null)
            {
                productToEdit = product;
                LoadProductData();
            }
        }
        public static class ProductService
        {
            public static List<Product> GetAllProducts()
            {
                // Здесь вы можете загрузить данные из базы данных или другого источника
                return new List<Product>
        {
            new Product { Name = "Товар 1", Price = 100 },
            new Product { Name = "Товар 2", Price = 200 },
            // Добавьте больше товаров по необходимости
        };
            }
        }
        public class Product
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Specifications { get; set; }
            public decimal Price { get; set; }
        }
        private void LoadProductData()
        {
            textBox1.Text = productToEdit.Name;
            textBox2.Text = productToEdit.Description;
            textBox3.Text = productToEdit.Specifications;
            textBox4.Text = productToEdit.Price.ToString();
        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (productToEdit != null)
            {
                productToEdit.Name = textBox1.Text;
                productToEdit.Description = textBox2.Text;
                productToEdit.Specifications = textBox3.Text;
                productToEdit.Price = decimal.Parse(textBox4.Text);

                
            }
            else
            {
                var newProduct = new Product
                {
                    Name = textBox1.Text,
                    Description = textBox2.Text,
                    Specifications = textBox3.Text,
                    Price = decimal.Parse(textBox4.Text)
                };
               
            }

            this.Close();
        }
    }
    }

