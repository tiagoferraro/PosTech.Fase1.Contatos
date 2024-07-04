using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosTech.Fase1.Contatos.Application.Result
{
    public struct ServiceResult<T>
    {
        public T? Data { get; }
        public Exception? Error { get; }
        public bool IsSuccess => Error == null;
        public ServiceResult(T data)
        {
            Data = data;
            Error = null;
        }

        public ServiceResult(Exception error)
        {
            Data = default;
            Error = error;
        }

        // operador Implicito para os dados
        public static implicit operator ServiceResult<T>(T data)
            => new ServiceResult<T>(data);

        // operador implicito para exceção
        public static implicit operator ServiceResult<T>(Exception ex)
            => new ServiceResult<T>(ex);
    }
    public struct ServiceResult
    {
        
        public Exception? Error { get; }
        public bool IsSuccess => Error == null;
        public ServiceResult()
        {
            Error = null;
        }

        public ServiceResult(Exception error)
        {
            Error = error;
        }

        public static implicit operator ServiceResult(Exception ex)
            => new ServiceResult(ex);
    }
}
