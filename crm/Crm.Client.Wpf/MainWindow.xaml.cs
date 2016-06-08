using System.Windows;
using Shared.ViewModels;

namespace Crm.Client.Wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var name = this.TbProductName.Text;
            var price = this.TbProductPrice.Text;

            if (string.IsNullOrWhiteSpace(name.Trim()))
            {
                MessageBox.Show("Please give the product a name.");
                return;
            }

            if (string.IsNullOrWhiteSpace(price.Trim()))
            {
                MessageBox.Show("Please give the product a price.");
                return;
            }

            int priceInt;
            if (int.TryParse(price, out priceInt))
            {
                if (priceInt <= 0)
                {
                    MessageBox.Show("Price mussst be > 0");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Price mussst be an integer");
                return;
            }

            new ApplicationServices.CommandService().CreateNewProduct(
                new ProductViewModel
                {
                    Name = name,
                    Price = priceInt
                });

            this.TbProductName.Text = string.Empty;
            this.TbProductPrice.Text = string.Empty;

            MessageBox.Show("Product created successfully.");
        }
    }
}
