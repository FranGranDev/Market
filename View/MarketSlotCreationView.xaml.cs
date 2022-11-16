using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;


namespace Market.View
{
    /// <summary>
    /// Логика взаимодействия для MarketSlotCreationView.xaml
    /// </summary>
    public partial class MarketSlotCreationView : UserControl
    {
        public MarketSlotCreationView()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
