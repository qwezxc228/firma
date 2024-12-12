namespace firma
{
    
    public partial class Form1 : Form
    {
        private List<Product> products; // Список всех товаров
        private decimal totalCost = 0;
        public Form1()
        {
            InitializeComponent();
            LoadProducts(); // Загрузка продуктов
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
        private void LoadProducts()
        {
            // Загрузка данных о товарах в ComboBox
            products = ProductService.GetAllProducts();
            foreach (var product in products)
            {
                comboBox1.Items.Add(product.Name);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedProduct = products[comboBox1.SelectedIndex];
            textBox1.Text = selectedProduct.Price.ToString("C");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedProduct = products[comboBox1.SelectedIndex];
            listBox1.Items.Add(selectedProduct.Name);
            totalCost += selectedProduct.Price;
            textBox2.Text = totalCost.ToString("C");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
