namespace Constructor5.Base.DebugCommandSystem
{
    [DebugCommand("flag")]
    public class DebugFlagCommand : DebugCommandBase
    {
        public override void Invoke(string[] parameters)
        {
            if (DebugCommandFlags.Values.Contains(parameters[0]))
            {
                DebugCommandFlags.Values.Remove(parameters[0]);
                return;
            }

            DebugCommandFlags.Values.Add(parameters[0]);
        }
    }
}