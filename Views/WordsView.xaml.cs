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
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            presenter.DeleteItem();
        }

        private void wordsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            deleteBtn.IsEnabled = true;
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

        public void DeleteItem(int index)
        {
            wordsList.Items.Remove(wordsList.Items.GetItemAt(index));
        }

        public int GetSelectedItemIndex()
        {
            return wordsList.SelectedIndex;
        }
    }
}
