using zadanie0.Models;

namespace zadanie0.Presenters
{
    class LessonPresenter : IPresenter<Lesson>
    {
        private MainWindow view;
        private Model model;
        private LessonDAO lessonDAO;

        public LessonPresenter(MainWindow view)
        {
            this.view = view;
            this.lessonDAO = new LessonDAO();
            this.model = new Model();
            Update();
        }

        public void AddNewItem()
        {
            try
            {
                string number = view.GetNumber();
                string subject = view.GetSubject();
                Lesson lesson = new Lesson(subject, number);

                lessonDAO.AddItem(lesson);
                view.AddItemToList(lesson);
            }
            catch
            {
                view.DisplayErrorMessage("Couldn't add this item");
                Update();
            }

        }

        public void DeleteItem()
        {
            try
            {
                int index = view.GetSelectedItemIndex();
                
                lessonDAO.DeleteItem(index);
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
            view.UpdateItemList(lessonDAO.GetData());
        }

        public void BrowseItem()
        {
            try
            {
                int index = view.GetSelectedItemIndex();

            }
            catch
            {
                view.DisplayErrorMessage("Couldn't browse this item");
                Update();
            }
        }
    }
}
