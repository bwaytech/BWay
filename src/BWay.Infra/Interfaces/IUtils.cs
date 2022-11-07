namespace BWay.Infra.Interfaces
{
    public interface IUtil
    {
        Guid CriarNovoId();
        List<T> Embaralhar<T>(List<T> roleta);
    }
}
