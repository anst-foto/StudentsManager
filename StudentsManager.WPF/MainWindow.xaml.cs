using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StudentsManager.WPF;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void CommandClear(object sender, RoutedEventArgs e)
    {
        /*MessageBox.Show(
            owner:this,
            messageBoxText:(sender as Button)?.Name,
            caption:"1");
        MessageBox.Show(this, (e.Source as Button)?.Name, "2");
        MessageBox.Show(this, e.RoutedEvent.Name , "3");*/
        InputLastName.Text = "";
        InputFirstName.Clear();
        InputDateOfBirth.SelectedDate = null;
    }

    private void CommandClose(object sender, ExecutedRoutedEventArgs e)
    {
        this.Close();
    }

    private void CommandClear_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(InputLastName.Text) ||
            !string.IsNullOrWhiteSpace(InputFirstName.Text) ||
            InputDateOfBirth.SelectedDate is not null)
        {
            e.CanExecute = true;
        }
        else
        {
            e.CanExecute = false;
        }
    }
}