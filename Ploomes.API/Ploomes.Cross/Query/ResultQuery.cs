using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Ploomes.Cross.Query
{
    public class ResultQuery
    {
        public ResultQuery()
        {
            LstError = new List<string>();
        }

        public string Message { get; set; }

        public List<string> LstError { get; set; }
    }

    public class ResultQuery<T> : ResultQuery
    {
        public ResultQuery(T data)
        {
            this.Data = data;
        }

        public T Data { get; set; }
    }

    public class ResultListQuery<T> : ResultQuery
    {
        public ResultListQuery()
        {
            this.Data = new List<T>();
        }

        public ResultListQuery(List<T> itens)
        {
            this.Data = itens;
            this.Total = itens.Count;
        }

        public List<T> Data { get; set; }
        public int Total { get; set; }
    }
}
