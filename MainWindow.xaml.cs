using zadanie0.Models;
using zadanie0.Presenters;
using zadanie0.Views;
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace zadanie0
{
    public partial class MainWindow : Window, IView<Lesson>
    {
        private LessonPresenter presenter;

        public MainWindow()
        {
            InitializeComponent();
            presenter = new LessonPresenter(this);

        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            presenter.AddNewItem();
        }

        public string GetSubject()
        {
            return subjectTb.Text;
        }

        public string GetNumber()
        {
            return numberTb.Text;
        }

        public void DisplayErrorMessage(string message)
        {
            errorMsg.Text = message;
        }

        public void AddItemToList(Lesson lesson)
        {
            lessonsList.Items.Add(lesson);
            ResetTextFields();
        }

        public void UpdateItemList(ArrayList items)
        {
            lessonsList.Items.Clear();
            foreach(Lesson item in items)
            {
                AddItemToList(item);
            }
        }

        public void DeleteItem()
        {
            lessonsList.Items.Remove(lessonsList.SelectedItem);
        }

        private void lessonsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lessonsList.SelectedIndex != -1)
            {
                deleteBtn.IsEnabled = true;
                editBtn.IsEnabled = true;
                browseBtn.IsEnabled = true;
            }
            else
            {
                deleteBtn.IsEnabled = false;
                editBtn.IsEnabled = false;
                browseBtn.IsEnabled = false;
            }
        }

        public int GetSelectedItemIndex()
        {
            return ((Lesson)lessonsList.SelectedItem).Index;
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            presenter.DeleteItem();
        }

        private void browseBtn_Click(object sender, RoutedEventArgs e)
        {
            int index = GetSelectedItemIndex();
            contentFrame.Visibility = Visibility.Visible;
            contentFrame.Content = new WordsView(index);
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            updateBtn.IsEnabled = true;
            addBtn.IsEnabled = false;
            deleteBtn.IsEnabled = false;
            editBtn.IsEnabled = false;
            browseBtn.IsEnabled = false;
            lessonsList.IsEnabled = false;
            string subject = ((Lesson)lessonsList.SelectedItem).Subject;
            string number = ((Lesson)lessonsList.SelectedItem).Number;

            subjectTb.Text = subject;
            numberTb.Text = number;
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            updateBtn.IsEnabled = false;
            addBtn.IsEnabled = true;
            deleteBtn.IsEnabled = true;
            editBtn.IsEnabled = true;
            browseBtn.IsEnabled = true;
            lessonsList.IsEnabled = true;
            presenter.EditItem();
        }

        public void ResetTextFields()
        {
            subjectTb.Text = "New Subject";
            numberTb.Text = "Lesson's number";
        }
    }
}
