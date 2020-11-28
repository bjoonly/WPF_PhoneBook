using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhoneBook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Contact> phoneBook = new ObservableCollection<Contact>();
        public MainWindow()
        {
            InitializeComponent();
            listBox.Items.Clear();
            listBox.ItemsSource = phoneBook;
            listBox.DisplayMemberPath = nameof(Contact.FullInfo);
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(firstNameTextBox.Text) && !String.IsNullOrEmpty(lastNameTextBox.Text) && !String.IsNullOrEmpty(phoneTextBox.Text) && !String.IsNullOrEmpty(operatorTextBox.Text))
            {
                phoneBook.Add(new Contact(firstNameTextBox.Text, lastNameTextBox.Text, phoneTextBox.Text, operatorTextBox.Text));

                Clear();
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                phoneBook.Remove(listBox.SelectedItem as Contact);
                Clear();
            }

        }
        private void Clear()
        {
            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            phoneTextBox.Clear();
            operatorTextBox.Clear();
            listBox.SelectedIndex = -1;
        }
        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null && !String.IsNullOrEmpty(firstNameTextBox.Text) && !String.IsNullOrEmpty(lastNameTextBox.Text) && !String.IsNullOrEmpty(phoneTextBox.Text) && !String.IsNullOrEmpty(operatorTextBox.Text))
            {
                var contact = listBox.SelectedItem as Contact;
                contact.FirstName = firstNameTextBox.Text;
                contact.LastName = lastNameTextBox.Text;
                contact.PhoneNumber = phoneTextBox.Text;
                contact.OperatorType = operatorTextBox.Text;
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                var contact = listBox.SelectedItem as Contact;
                firstNameTextBox.Text = contact.FirstName;
                lastNameTextBox.Text = contact.LastName;
                phoneTextBox.Text = contact.PhoneNumber;
                operatorTextBox.Text = contact.OperatorType;
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
    }
}
