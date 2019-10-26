using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;
using System.IO;
using Windows.Storage.Streams;

namespace PomodoroAssistantPlus.LocalStorage
{
    public interface IStorage
    {
        Task LoadData<T>();
        Task SaveData<T>();
        List<T> GetData<T>();
        void AddItem<T>(T item);
        void RemoveItem(int itemIndex);
        void ChangeItem<T>(T item);
        void ClearData();
    }
}
