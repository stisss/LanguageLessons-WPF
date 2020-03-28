using System.Collections;

namespace zadanie0.Models
{
    interface IDAO<T> where T : class
    {
         void AddItem(T item);

         T GetItem(int index);

         void UpdateItem(int index);

         void DeleteItem(int index);

        ArrayList GetData();
        
    }
}
