namespace CC.Core
{
    using System;

    public interface IExceptionHandler
    {
        T TryCatch<T>(Func<T> action);

        void TryCatch(Action action);
    }
}
