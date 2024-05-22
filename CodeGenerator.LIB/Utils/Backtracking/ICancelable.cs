namespace CodeGenerator.LIB.Utils.Backtracking
{
    public interface ICancelable
    {
        void Undo();

        void Redo();
    }
}
