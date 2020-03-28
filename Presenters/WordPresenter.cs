using zadanie0.Models;
using zadanie0.Views;

namespace zadanie0.Presenters
{
    class WordPresenter : IPresenter<Word>
    {
        private WordsView view;
        private Model model;
        private WordDAO wordDAO;

        public WordPresenter(WordsView view, int index)
        {
            this.view = view;
            this.wordDAO = new WordDAO(index);
            this.model = new Model();
            Update();
        }
        public void AddNewItem()
        {
            try
            {
                string foreign = view.GetForeign();
                string meaning = view.GetMeaning();
                Word word = new Word(foreign, meaning);

                wordDAO.AddItem(word);
                view.AddItemToList(word);
            }
            catch
            {
                view.DisplayErrorMessage("Couldn't add this item");
                Update();
            }
        }

        public void BrowseItem()
        {
            // not implemented yet
        }

        public void DeleteItem()
        {
            try
            {
                int index = view.GetSelectedItemIndex();

                wordDAO.DeleteItem(index);
                view.DeleteItem(index);
            }
            catch
            {
                view.DisplayErrorMessage("Couldn't delete this item");
                Update();
            }
        }

        public void Update()
        {
            view.UpdateItemList(wordDAO.GetData());
        }
    }
}
