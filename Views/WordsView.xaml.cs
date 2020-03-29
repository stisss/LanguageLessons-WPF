using zadanie0.Models;
using zadanie0.Presenters;
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace zadanie0.Views
{
    public partial class WordsView : Page, IView<Word>
    {
        private int index;
        private WordPresenter presenter;
        public WordsView(int index)
        {
            this.index = index;
            InitializeComponent();
            presenter = new WordPresenter(this, index);
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            presenter.AddNewItem();
            ResetTextFields();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            presenter.DeleteItem();
        }

        private void wordsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(wordsList.SelectedIndex!= -1)
            {
                deleteBtn.IsEnabled = true;
                editBtn.IsEnabled = true;
            }
            else
            {
                deleteBtn.IsEnabled = false;
                editBtn.IsEnabled = false;
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        public string GetForeign()
        {
            return foreignWordTb.Text;
        }

        public string GetMeaning()
        {
            return meaningTb.Text;
        }

        public void DisplayErrorMessage(string message)
        {
            // display error msg
        }

        public void AddItemToList(Word item)
        {
            wordsList.Items.Add(item);
        }

        public void UpdateItemList(ArrayList items)
        {
            wordsList.Items.Clear();
            foreach (Word item in items)
            {
                AddItemToList(item);
            }
        }

        public void DeleteItem()
        {
            wordsList.Items.Remove(wordsList.SelectedItem);
        }

        public int GetSelectedItemIndex()
        {
            return ((Word)wordsList.SelectedItem).Index;
        }

        public void ResetTextFields()
        {
            foreignWordTb.Text = "New word";
            meaningTb.Text = "New translation";
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            updateBtn.IsEnabled = true;
            addBtn.IsEnabled = false;
            deleteBtn.IsEnabled = false;
            editBtn.IsEnabled = false;
            wordsList.IsEnabled = false;
            string foreign = ((Word)wordsList.SelectedItem).ForeignWord;
            string meaning = ((Word)wordsList.SelectedItem).Meaning;

            foreignWordTb.Text = foreign;
            meaningTb.Text = meaning;
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            updateBtn.IsEnabled = false;
            addBtn.IsEnabled = true;
            deleteBtn.IsEnabled = true;
            editBtn.IsEnabled = true;
            wordsList.IsEnabled = true;
            presenter.EditItem();
        }
    }
}
