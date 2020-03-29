namespace zadanie0
{
    interface IPresenter<T> where T : class
    {
        void AddNewItem();

        void DeleteItem();

        void Update();

        void BrowseItem();

        void EditItem();

    }
}
