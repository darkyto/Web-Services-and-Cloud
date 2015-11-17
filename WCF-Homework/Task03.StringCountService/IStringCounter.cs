namespace Task03.StringCountService
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IStringCounter
    {
        [OperationContract]
        int FindWordOccurance(string text, string lookingFor);
    }
}
