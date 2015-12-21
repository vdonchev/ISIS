namespace IsIs.Contracts
{
    public interface IOutputWriter
    {
        void Write(string line);

        void Flush();
    }
}