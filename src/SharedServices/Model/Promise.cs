namespace SharedServices.Model
{
    using System;

    public class Promise<T>
    {


        public T Result { get; set; } = default(T);

        public Exception Exception { get; set; } = null;
    }
}