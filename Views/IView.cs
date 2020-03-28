using System.Collections;

namespace zadanie0.Views
{
    interface IView<T> where T : class
    {
        void DisplayErrorMessage(string message);
        void AddItemToList(T item);
        void UpdateItemList(ArrayList items);
        void DeleteItem(int index);
        int GetSelectedItemIndex();
    }
}
