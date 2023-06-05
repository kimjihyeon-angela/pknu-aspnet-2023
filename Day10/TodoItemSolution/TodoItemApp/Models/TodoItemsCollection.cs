using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace TodoItemApp.Models
{
    public class TodoItemsCollection: ObservableCollection<TodoItem> 
        // ObservableCollection<TodoItem> = IList<TodoItem>, List<TodoItem>과 같음
    {
        public void CopyFrom(IEnumerable<TodoItem> todoItems)
        {
            this.Items.Clear(); 
            // ObservableCollection<TodoItem> 자체가 Items속성을 가지고 있음, 초기화(모든데이터 삭제)

            foreach (TodoItem item in todoItems)
            {
                this.Items.Add(item);
                // 하나씩 다시 추가
            }

            // 데이터 바뀐것을 알려줌 (전부 초기화)
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
