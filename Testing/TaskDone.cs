using CodeGenerator.LIB.Utils.Backtracking;

public class TaskDone : ICancelable
{
    private Test _task;
    private int _value;


    public TaskDone(Test item, int value)
    {
        _task = item;
        _value = value;
    }

    public void Redo()
    {
        (_value, _task.Dat) = (_task.Dat, _value);
        Thread.Sleep(1000);
    }

    public void Undo()
    {
        (_value, _task.Dat) = (_task.Dat, _value);
        Thread.Sleep(1000);
    }
}