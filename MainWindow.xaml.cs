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
        }

        public void UpdateItemList(ArrayList items)
        {
            lessonsList.Items.Clear();
            foreach(Lesson item in items)
            {
                AddItemToList(item);
            }
        }

        public void DeleteItem(int index)
        {
            lessonsList.Items.Remove(lessonsList.Items.GetItemAt(index));
        }

        private void lessonsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            deleteBtn.IsEnabled = true;
            browseBtn.IsEnabled = true;
        }

        public int GetSelectedItemIndex()
        {
            return lessonsList.SelectedIndex;
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
    }
}
