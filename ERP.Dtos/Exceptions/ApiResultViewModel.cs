
using System.Runtime.Serialization;

namespace ERP.Dtos.Exceptions;

[DataContract]
public class ApiResultViewModel<T>
{
    [DataMember(Name = "data")]
    public T Data { get; set; }

    [DataMember(Name = "error")]
    public ErrorViewModel Error { get; set; }

    [DataMember(Name = "meta")]
    public object Meta { get; set; }

    public ApiResultViewModel(T data)
    {
        Data = data;
    }

    public ApiResultViewModel()
    {
    }

    public static ApiResultViewModel<TData> FromData<TData>(TData data, object meta = null)
    {
        return new ApiResultViewModel<TData>
        {
            Data = data,
            Meta = meta
        };
    }

    public static ApiResultViewModel<object> FromError(ErrorViewModel error)
    {
        return new ApiResultViewModel<object>
        {
            Error = error
        };
    }
}
