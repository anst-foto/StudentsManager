using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StudentsManager.WPF;

public partial class MainWindow : Window
{
    private List<Student> _students;
    private Student _selectedStudent;
    
    public MainWindow()
    {
        _students = new List<Student>()
        {
            new()
            {
                Id = 1,
                LastName = "Starinin",
                FirstName = "Andrey",
                DateOfBirth = new DateTime(1986, 2, 18)
            },
            new()
            {
                Id = 2,
                LastName = "Starinin",
                FirstName = "Viktor",
                DateOfBirth = new DateTime(1984, 12, 18)
            }
        };
        
        InitializeComponent();
        
        ListOfStudents.ItemsSource = _students.Select(s => s.FullName);
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
    private void CommandClear(object sender, RoutedEventArgs e)
    {
        /*MessageBox.Show(
            owner:this,
            messageBoxText:(sender as Button)?.Name,
            caption:"1");
        MessageBox.Show(this, (e.Source as Button)?.Name, "2");
        MessageBox.Show(this, e.RoutedEvent.Name , "3");*/
        ClearInputs();
    }

    private void CommandClose(object sender, ExecutedRoutedEventArgs e)
    {
        this.Close();
    }

    
    private void CommandDelete_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = !string.IsNullOrWhiteSpace(InputId.Text);
    }
    private void CommandDelete(object sender, ExecutedRoutedEventArgs e)
    {
        ListOfStudents.UnselectAll();
        ClearInputs();
        
        _students.Remove(_selectedStudent);
        
        //ListOfStudents.ItemsSource.Cast<string>().ToList().Remove(_selectedStudent.FullName);
        ListOfStudents.ItemsSource = _students.Select(s => s.FullName);
    }

    private void ListOfStudents_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ListOfStudents.SelectedItem is not string selectedStudent) return;
        _selectedStudent = _students.First(s => s.FullName == selectedStudent);

        SetInputs(_selectedStudent);
    }

    private void SetInputs(Student student)
    {
        InputId.Text = student.Id.ToString();
        InputLastName.Text = student.LastName;
        InputFirstName.Text = student.FirstName;
        InputDateOfBirth.SelectedDate = student.DateOfBirth;
        InputAge.Text = student.Age.ToString();
        InputFaculty.Text = student.Faculty;
    }

    private void ClearInputs()
    {
        InputLastName.Text = "";
        InputFirstName.Clear();
        InputDateOfBirth.SelectedDate = null;
        InputFaculty.Clear();
        InputAge.Clear();
        InputId.Clear();
    }
}