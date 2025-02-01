using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models.Contexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace CarRental.Models.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="DtoType">Dto do wyswietlania na liscie</typeparam>
    /// <typeparam name="ModelType">Model do dodania/edycji</typeparam>
    public abstract class BaseService<DtoType, ModelType>
        where ModelType : new()
    {
        public DatabaseContext DatabaseContext {  get; set; }
        public string? ColumnName { get; set; }
        public bool Descending { get; set; }
        public ObservableCollection<string>? ColumnNames;
        public string? SearchInput { get; set; }
        public BaseService()
        {
            DatabaseContext = new DatabaseContext();
        }
        public abstract List<DtoType> GetModels();
        public abstract ModelType GetModel(int id);
        public abstract void AddModel(ModelType model);
        public abstract void UpdateModel(ModelType model);
        public abstract void DeleteModel(DtoType model);
        public virtual ModelType CreateModel()
        {
            return new ModelType();
        }
        public abstract bool IsValid(ModelType model);
    }
}
