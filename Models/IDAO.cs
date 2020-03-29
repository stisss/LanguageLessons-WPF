using System.Collections;

namespace zadanie0.Models
{
    interface IDAO<T> where T : class
    {
         void AddItem(T item);

         T GetItem(int index);

         void UpdateItem(int index, T item);

         void DeleteItem(int index);

        ArrayList GetData();
        
    }
}
